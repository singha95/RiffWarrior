using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetection : MonoBehaviour
{
	public float radius;                // Radius around player to collide with enemies
	public float rotationSpeed;         // Roation speed at which to rotate towards the monster
    public bool inBattle;
	public GameObject currentTarget;   // Current enemy being targetted
    public GameObject PopText;

    private GameObject guitarNotes;     // Note lanes object
	private PlayerController playerController;   // Player controller containing current state
	private MusicController musicController; // Music controller to generate notes
	private Coroutine pauseAmbientTrack;
	private Coroutine resumeAmbientTrack;
	private AudioManager audioManager;
	private EnemyController enemyController;
    public LayerMask sightLayer;
    private Animator PopUpAni;
   
    private float EnemyDetectRange;


	private void Start()
	{
		// No current target
		currentTarget = null;
        //get the PopUpText info
        PopUpAni = GameObject.FindGameObjectWithTag("PopUp").GetComponent<Animator>();
        PopText = GameObject.FindGameObjectWithTag("PopUpParent");
        // Get necessary objects/scripts
        playerController = GetComponent<PlayerController>();
		guitarNotes = transform.Find("GuitarNotes").gameObject;
		// musicController = guitarNotes.GetComponent<MusicController>();
		audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        //init Detctct range for enemy
        EnemyDetectRange = 70.0f;
        inBattle = false;
	}

	private void Update()
	{
		// Search for new target if none locked on right now
		switch (playerController.CurrentState)
		{
		case PlayerController.State.WALK:
			FindClosestEnemyInRange();
			break;
		case PlayerController.State.COMBAT:
			// Constantly lock on to enemy
			TurnTowardsEnemy();
			break;
		default:
			break;
		}
		
		if (currentTarget) {
			if (enemyController.GetHealth() <= 0)
				EndCombat();
		}
	}

	/// <summary>
	/// Check distance to all enemies and select closest enemy within set radius
	/// </summary>
	private void FindClosestEnemyInRange()
	{
		// Get all enemies
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        
		if (enemies.Length > 0)
		{
			// Using vector2 of player to compare distance on flat plane (without height)
			Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
            // Keep track of closest enemy
            GameObject closestEnemy = enemies[0];
			float closestDistance = Vector2.Distance(playerPos, new Vector2(enemies[0].transform.position.x, enemies[0].transform.position.z));

			float tempDistance;
			for (int i = 1; i < enemies.Length; i++)
			{
				// Find closest enemy
				tempDistance = Vector2.Distance(playerPos, new Vector2(enemies[i].transform.position.x, enemies[i].transform.position.z));
				if (tempDistance < closestDistance)
				{
					closestEnemy = enemies[i];
					closestDistance = tempDistance;
				}
			}
            Vector3 WorldPos = closestEnemy.transform.position;
            WorldPos.y = 10.0f;
            Vector3 PopPos = Camera.main.WorldToScreenPoint(WorldPos);
            //if in enemy's detect range
            if (closestDistance <= EnemyDetectRange && Physics.Linecast(transform.position, closestEnemy.transform.position,sightLayer) == false)
            {
                PopText.transform.position = PopPos;
                PopUpAni.SetBool("InRange", true);
            }
            if (closestDistance > EnemyDetectRange || Physics.Linecast(transform.position, closestEnemy.transform.position,sightLayer))
            {
                PopText.transform.position = PopPos;
                PopUpAni.SetBool("InRange", false);
            }
            // If within attacking range
            if (closestDistance < radius && Physics.Linecast(transform.position, closestEnemy.transform.position,sightLayer) == false)
			{
                inBattle = true;
                PopText.transform.position = PopPos;
                PopUpAni.SetBool("InRange", false);
                TargetEnemy(closestEnemy);
				
				// Pause ambient track.
				if (resumeAmbientTrack != null) {
					StopCoroutine(resumeAmbientTrack);
				}
				pauseAmbientTrack = StartCoroutine(audioManager.PauseAmbientTrack());
			}
		}
	}

	/// <summary>
	/// Sets target to closest enemy and activates guitar lanes
	/// </summary>
	/// <param name="enemy">Enemy gameobject to be targetted</param>
	private void TargetEnemy(GameObject enemy)
	{
		currentTarget = enemy;
		enemyController = currentTarget.GetComponent<EnemyController>();
		playerController.CurrentState = PlayerController.State.COMBAT;
		enemyController.InitiateCombat ();
		guitarNotes.GetComponent<GuitarNotesController> ().SetTargetEnemey (currentTarget);
		EnableGuitarNotes();
		playerController.Animator.SetBool("isInCombat", true);
	}

	/// <summary>
	/// Rotating function to look towards enemy
	/// </summary>
	private void TurnTowardsEnemy()
	{
		Quaternion neededRotationForEnemy = Quaternion.LookRotation
			(transform.position - currentTarget.transform.parent.position
			);
		Quaternion neededRotation = Quaternion.LookRotation
			(
				currentTarget.transform.position - transform.position
			);
		neededRotation.z = 0;
		neededRotation.x = 0;
		neededRotationForEnemy.z = 0;
		neededRotationForEnemy.x = 0;
		transform.rotation = Quaternion.Slerp
			(
				transform.rotation,
				neededRotation,
				Time.deltaTime *
				rotationSpeed
			);
		currentTarget.transform.parent.rotation = Quaternion.Slerp
			(
				currentTarget.transform.parent.rotation,
				neededRotationForEnemy,
				Time.deltaTime *
				rotationSpeed
			);
		currentTarget.GetComponent<EnemyController>().canMove = false;
	}

	private void EnableGuitarNotes()
	{
		// musicController.source = currentTarget.GetComponent<AudioSource>();
		// musicController.FileName = musicController.source.clip.name + ".bin";
		guitarNotes.SetActive(true);
	}

	public void EndCombat()
	{
		StartCoroutine(currentTarget.GetComponent<EnemyController>().Death());
		
		if (currentTarget.layer == 10) {
			audioManager.PlayEndAmbientTrack ();
			playerController.GetComponent<PlayerController>().SetWinBoss();
		}
		
		// Resume ambient track.
		if (currentTarget.layer != 10) {
			StopCoroutine(pauseAmbientTrack);
			resumeAmbientTrack = StartCoroutine(audioManager.ResumeAmbientTrack());
		}
		
		currentTarget = null;
		playerController.Animator.SetBool("isInCombat", false);
		playerController.CurrentState = PlayerController.State.WALK;
		
		// Pause for a short while.
		StartCoroutine(PauseAfterKill());
	}
	
	
	private IEnumerator PauseAfterKill() {
		playerController.DisableInput();
		yield return new WaitForSecondsRealtime(1.0f);
		guitarNotes.SetActive(false);
		playerController.EnableInput();
	}
}

