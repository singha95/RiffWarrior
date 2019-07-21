using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject
{
    public GameObject Note;
    public float TimeTravelling;
    public int Lane;
}

public class GuitarNotesController : MonoBehaviour
{
    public GameObject note;
    public float time;
    public float fadeAmount;
    public float highlightAmount;
	public float noteYOffset;
	public float noteFadeSpeed;
	public float disableStrumTime;
	public Quaternion noteRotation;

    public bool testing;

    private GameObject[] lanes;
    private GameObject[] laneSpawns;
    private GameObject[] laneEnds;
	private Transform player;
    private Vector3 travelDirection;
    private float[] lastSpawnedTimePerLane;
	private ParticleSystem[] noteExplosions;
    private List<NoteObject> notes;
    private PlayerHealth healthScript;
	private PlayerController playerController;
	private GameObject enemy;
	private StatsManager statsManager;
	private RiffManager riffManager;
	private AudioManager audioManager;
	private Coroutine startRiffs;
	private Coroutine unmuteGuitarTrack;
	private Coroutine muteGuitarTrack;
	private Coroutine enemyTakeDamage;
	private Coroutine unmuteRiffTrack;
	private Coroutine muteRiffTrack;
	private Coroutine bossTrack;
	private EnemyController enemyController;

    private enum Colours
    {
        GREEN = 0,
        RED = 1,
        YELLOW = 2,
        BLUE = 3,
        ORANGE = 4
    }

    void Awake()
    {
        // Initialize arrays
        lanes = new GameObject[5];              // All the lanes to be help
        laneSpawns = new GameObject[5];         // All the lane spawn points
        laneEnds = new GameObject[5];           // All the lane end points
        lastSpawnedTimePerLane = new float[5];  // Times last note was spawned on each lane to block overproduction
        notes = new List<NoteObject>();         // Notes generated using pool instead of creating new ones every time
		noteExplosions = GetComponentsInChildren<ParticleSystem>();
		player = transform.parent;
		playerController = player.gameObject.GetComponent<PlayerController>();
		statsManager = GameObject.FindWithTag("StatsManager").GetComponent<StatsManager>();
		riffManager = GameObject.FindWithTag("RiffManager").GetComponent<RiffManager>();
		audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
		
        // Lanes r constant and are loaded at start
        foreach (Transform child in transform)
        {
            string name = child.name;

            if (name.Equals("GreenLane"))
            {
                lanes[(int)Colours.GREEN] = child.gameObject;
            }
            else if (name.Equals("RedLane"))
            {
                lanes[(int)Colours.RED] = child.gameObject;
            }
            else if (name.Equals("YellowLane"))
            {
                lanes[(int)Colours.YELLOW] = child.gameObject;
            }
            else if (name.Equals("BlueLane"))
            {
                lanes[(int)Colours.BLUE] = child.gameObject;
            }
            else if (name.Equals("OrangeLane"))
            {
                lanes[(int)Colours.ORANGE] = child.gameObject;
            }
            else if (name.Equals("SpawnPoints"))
            {
                foreach (Transform grandchild in child.transform)
                {
                    name = grandchild.name;
                    if (name.Equals("GreenSpawn"))
                    {
                        laneSpawns[(int)Colours.GREEN] = grandchild.gameObject;
                    }
                    else if (name.Equals("RedSpawn"))
                    {
                        laneSpawns[(int)Colours.RED] = grandchild.gameObject;
                    }
                    else if (name.Equals("YellowSpawn"))
                    {
                        laneSpawns[(int)Colours.YELLOW] = grandchild.gameObject;
                    }
                    else if (name.Equals("BlueSpawn"))
                    {
                        laneSpawns[(int)Colours.BLUE] = grandchild.gameObject;
                    }
                    else if (name.Equals("OrangeSpawn"))
                    {
                        laneSpawns[(int)Colours.ORANGE] = grandchild.gameObject;
                    }
                }
            }
            else if (name.Equals("EndPoints"))
            {
                foreach (Transform grandchild in child.transform)
                {
                    name = grandchild.name;
                    if (name.Equals("GreenEnd"))
                    {
                        laneEnds[(int)Colours.GREEN] = grandchild.gameObject;
                    }
                    else if (name.Equals("RedEnd"))
                    {
                        laneEnds[(int)Colours.RED] = grandchild.gameObject;
                    }
                    else if (name.Equals("YellowEnd"))
                    {
                        laneEnds[(int)Colours.YELLOW] = grandchild.gameObject;
                    }
                    else if (name.Equals("BlueEnd"))
                    {
                        laneEnds[(int)Colours.BLUE] = grandchild.gameObject;
                    }
                    else if (name.Equals("OrangeEnd"))
                    {
                        laneEnds[(int)Colours.ORANGE] = grandchild.gameObject;
                    }
                }
            }
        }

        // Gets health script for damaging player when note missed
        var parent = transform.parent;
        while (parent != null && parent.CompareTag("Player"))
        {
            parent = parent.transform.parent;
        }
    }

    private void Start()
    {
        healthScript = transform.parent.GetComponent<PlayerHealth>();
    }
	
	
	private void OnEnable() {
		// Get the riff manager to start sending riffs.
		riffManager.SetGuitarNotesController(this);
		if (enemy.layer == 10)
			bossTrack = StartCoroutine(riffManager.StartBossTrack());
		else
			startRiffs = StartCoroutine(riffManager.StartRiffs(enemy));
	}
	

    void OnDisable()
    {
        // Clear old data
        for (int i = notes.Count - 1; i >= 0; i--)
        {
            Destroy(notes[i].Note);
        }
        notes.Clear();
		playerController.EnableInput();
    }

    void FixedUpdate()
    {
        // Testing purposes create random note on enable
        if (testing)
        {
            GenerateNote(Random.Range(1, 6));
        }

        travelDirection = (laneEnds[0].transform.position + 
			new Vector3(0.0f, noteYOffset, 0.0f)) - 
			(laneSpawns[0].transform.position +
			new Vector3(0.0f, noteYOffset, 0.0f));

        foreach (var note in notes)
        {
            note.TimeTravelling += Time.deltaTime;
            note.Note.transform.SetPositionAndRotation(
				laneSpawns[note.Lane].transform.position + 
				new Vector3(0.0f, noteYOffset, 0.0f) +
				(travelDirection * note.TimeTravelling / time),
				player.rotation
			);
        }
    }

    /// <summary>
    /// Generates a note on a given lane
    /// </summary>
    /// <param name="lane">the lane index (0-4) for the new note to be spawned in</param>
    /// <returns>bool of whether the note was successfully created</returns>
    public bool GenerateNote(int lane, NoteV2 noteV2 = default(NoteV2))
    {
        // Generate note object at top of lane
        NoteObject newNote = new NoteObject();
        newNote.Note = Instantiate(note);
		NoteGO noteGO = newNote.Note.GetComponent<NoteGO>();
		noteGO.SetLastNote(noteV2.lastNote);
		noteGO.SetDamageNote(noteV2.damageNote);
        newNote.Note.transform.position = laneSpawns[lane].transform.position +
			new Vector3(0.0f, noteYOffset, 0.0f);
        newNote.Lane = lane;
        newNote.TimeTravelling = 0.0f;
        notes.Add(newNote);

        lastSpawnedTimePerLane[lane] = Time.realtimeSinceStartup;

        return true;
    }

    /// <summary>
    /// Removes a note from the game
    /// </summary>
    /// <param name="endNote">Note to be removed</param>
    /// <param name="hit">whether the player hit the note</param>
    public void RemoveNote(GameObject endNote, bool hit)
    {
        int i = 0;
        for (; i < notes.Count; i++)
        {
            if (notes[i].Note == endNote)
            {
                break;
            }
        }

        if (i == notes.Count)
        {
            Debug.Log("Attempted to delete unknown note");
        }
        else
        {
            notes.RemoveAt(i);
            Destroy(endNote);
			
			// This block is for when a note reaches the end, and is not hit.
            if (!hit)
            {
                PlayerTakesDamage();
				statsManager.ReportMiss();
				statsManager.IncreaseMissCounter();
				
				// Check if enemy is a boss.
				if (enemy.layer == 10) {
					StopUnmuteGuitarTrack();
					muteGuitarTrack = StartCoroutine(audioManager.MuteGuitarTrack());
					if (audioManager.GetGuitarTrackVolume() > 0.0f) {
						audioManager.PlayErrorTrack();
					}
				} else {
					StopUnmuteRiffTrack();
					muteRiffTrack = StartCoroutine(audioManager.MuteRiffTrack());
					if (audioManager.GetRiffTrackVolume() > 0.0f) {
						audioManager.PlayErrorTrack();
					}
				}
            }
        }
    }

    /// <summary>
    /// Increases delta of the lane to make it brighter when the colour is selected
    /// </summary>
    /// <param name="selectedLanes">booleans representing each lane and whether they were pressed</param>
    public void HighlightLanes(bool[] selectedLanes)
    {
        for (int i = 0; i < 5; i++)
        {
            MeshRenderer laneMesh = lanes[i].GetComponent<MeshRenderer>();

            if (selectedLanes[i])
            {
                Color newColour = laneMesh.material.color;
                newColour.a = highlightAmount;
                laneMesh.material.color = newColour;
            }
            else
            {
                Color newColour = laneMesh.material.color;
                newColour.a = fadeAmount;
                laneMesh.material.color = newColour;
            }
        }
    }

    /// <summary>
    /// Attempts to hit all the selected notes
    /// </summary>
    /// <param name="selectedNotes">which notes were selected in form of bool array</param>
    public void PlayNotes(bool[] selectedNotes) {
		
        // Check to see if empty strum
        bool pressedSomething = false;

        for (int i = 0; i < 5; i++)
        {
            if (selectedNotes[i])
            {
                pressedSomething = true;

                var noteToHit = laneEnds[i].GetComponent<GuitarNoteEndController>().triggerHitNote;

				// Check if the player hit the wrong note.
                if (noteToHit == null)
                {
					PlayerTakesDamage();
					statsManager.ReportMiss();
					
					// Check if the enemy is a boss.
					if (enemy.layer == 10) {
						StopUnmuteGuitarTrack();
						muteGuitarTrack = StartCoroutine(audioManager.MuteGuitarTrack());
					} else {
						StopUnmuteRiffTrack();
						muteRiffTrack = StartCoroutine(audioManager.MuteRiffTrack());
					}
					audioManager.PlayErrorTrack();
                }
                else
                {
					StopMuteRiffTrack();
					unmuteRiffTrack = StartCoroutine(audioManager.UnmuteRiffTrack());
					StopMuteGuitarTrack();
					unmuteGuitarTrack = StartCoroutine(audioManager.UnmuteGuitarTrack());
					enemyController.DecrementHealth();
					CheckEnemyStatus();
					EnemyTakeDamage();
                    RemoveNote(noteToHit, true);
					noteExplosions[i].Play();
					statsManager.ReportHit();
					statsManager.IncreaseHitCounter();
                }
            }
        }

        if (!pressedSomething)
        {
			PlayerTakesDamage();
			statsManager.ReportMiss();
			
			// Check if enemy is a boss.
			if (enemy.layer == 10) {
				StopUnmuteGuitarTrack();
				muteGuitarTrack = StartCoroutine(audioManager.MuteGuitarTrack());
			} else {
				StopUnmuteRiffTrack();
				muteRiffTrack = StartCoroutine(audioManager.MuteRiffTrack());
			}
			audioManager.PlayErrorTrack();
        }
    }
	
	
	public void SetTargetEnemey(GameObject enemy) {
		this.enemy = enemy;
		enemyController = enemy.GetComponent<EnemyController>();
	}
	
	
	private void PlayerTakesDamage() {
		StartCoroutine(enemyController.Attack());
		healthScript.TakeDamage(1);
	}
	
	
	private void CheckEnemyStatus() {
		if (enemyController.GetHealth() <= 0) {
			StopEnemyRiffs();
			audioManager.FadeRiffTrack();
			audioManager.FadeDrumTrack();
			audioManager.FadeGuitarTrack();
			audioManager.FadeBackingTrack();
			ClearNotesOnLanes();
		}
	}
	
	
	private void StopUnmuteGuitarTrack() {
		if (unmuteGuitarTrack != null) {
			StopCoroutine(unmuteGuitarTrack);
		}
	}
	
	
	private void StopUnmuteRiffTrack() {
		if (unmuteRiffTrack != null) {
			StopCoroutine(unmuteRiffTrack);
		}
	}
	
	
	private void StopMuteGuitarTrack() {
		if (muteGuitarTrack != null)
			StopCoroutine(muteGuitarTrack);
	}
	
	
	private void StopMuteRiffTrack() {
		if (muteRiffTrack != null)
			StopCoroutine(muteRiffTrack);
	}
	
	
	private void StopEnemyRiffs() {
		if (startRiffs != null)
			StopCoroutine(startRiffs);
		if (bossTrack != null)
			StopCoroutine(bossTrack);
	}
	
	
	private void ClearNotesOnLanes() {
		for (int k = notes.Count - 1; k >= 0; k--)
			Destroy(notes[k].Note);
		notes.Clear();
	}
	
	
	private void EnemyTakeDamage() {
		if (enemyTakeDamage != null)
			StopCoroutine(enemyTakeDamage);
		enemyController.ResetMaterialColour();
		enemyTakeDamage = StartCoroutine(enemyController.TakeDamage());
	}
	
}
