using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayerController : MonoBehaviour
{
    #region Movement Variables
    public int walkSpeed;           // Walking speed
    public int rotationSpeed;       // Rotating speed
	private ParticleSystem[] walkingParticles;
    #endregion Movement Variables

    #region Combat Variables
    public int numLanes;            // Number of active lanes

    private float currentStrum;     // Current frame's strum value
    private float previousStrum;    // Previous value of strum to check for single strums
    private GuitarNotesController guitarNotes;  // Guitar note controller
    #endregion Combat Variables

    #region Inventory Variables
    private GameObject inventoryController;
    private InventoryController ic;
    private PlayerHealth playerHealth;
    #endregion Inventory Variables
	
	private bool inputDisabled;

    private Animator animator;
	private bool wonBoss; 
	private bool tutorialMode;
	private bool onGrass;

    public Animator Animator
    {
        get { return animator; }
    }

    private State currentState;     // Current mode the player is in
    public State CurrentState
    {
        get { return currentState; }
        set
        {
            currentState = value;
            if (currentState == State.COMBAT)
            {
                PlayerStrummed();
            }
        }
    }
    public enum State
    {
        WALK,
        COMBAT,
        MENU
    }

    public Controller controller;   // Which controller is being used
    public enum Controller
    {
        GUITARHERO,
        ROCKBAND,
        KEYBOARD
    }
	
	private void Awake()
	{
		walkingParticles = GetComponentsInChildren<ParticleSystem>();
		inputDisabled = false;
	}

    private void Start()
    {
        // Start player always in free mode (walking)
        currentState = State.WALK;

        // Get necessary scripts/gameobjects
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        guitarNotes = transform.Find("GuitarNotes").gameObject.GetComponent<GuitarNotesController>();
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case State.WALK:
                UpdateMovement();
                break;
            case State.COMBAT:
                UpdateCombat();
                break;
            case State.MENU:
                break;
        }
    }
    
    #region Movement

    private void UpdateMovement()
    {
        switch (controller)
        {
            case Controller.KEYBOARD:
                StrumWalkKeyboard();
                break;
            case Controller.GUITARHERO:
                StrumWalkGuitar("GH");
                break;
            case Controller.ROCKBAND:
                StrumWalkGuitar("RB");
                break;
        }
    }

    /// <summary>
    /// Special walking control mapping for keyboard
    /// </summary>
    private void StrumWalkKeyboard()
    {
        if (Input.GetButton("Up"))
        {
            FreeWalk(1);
        }
        else if (Input.GetButton("Down"))
        {
            FreeWalk(-1);
        }
        else
        {
            FreeWalk(0);
        }

        if (Input.GetButton("Right"))
        {
            FreeRotate(1);
        }
        else if (Input.GetButton("Left"))
        {
            FreeRotate(-1);
        }
    }

    /// <summary>
    /// Input reader mapping movement to buttons
    /// </summary>
    /// <param name="prefix">"GH" for GuitarHero controller, "RB" for RockBand controller</param>
    private void StrumWalkGuitar(string prefix)
    {
        // Rotate Left
        if (Input.GetButton(prefix + "Green"))
        {
            FreeRotate(-1);
        }
        // Rotate Right
        else if (Input.GetButton(prefix + "Red"))
        {
            FreeRotate(1);
        }

        // Forward/Backward Movement
		if (!inputDisabled)
			FreeWalk(-Input.GetAxis(prefix + "Strum"));
		else
			FreeWalk(0.0f);
    }

    /// <summary>
    /// Function to rotate player
    /// </summary>
    /// <param name="direction">Value from -1 to 1 of intensity</param>
    public void FreeRotate(float direction)
    {
		if(inputDisabled == false) {
			transform.Rotate(Vector3.up * direction * Time.deltaTime * rotationSpeed);
			PlayWalkingParticles();
		}
    }

    /// <summary>
    /// Function to move player forward and backward
    /// </summary>
    /// <param name="direction">Value from -1 to 1 of intensity</param>
    public void FreeWalk(float direction)
    {
        // Short circuit when no walking occurs
        if (direction != 0)
        {
            transform.Translate
            (
                Vector3.forward *
                direction *
                walkSpeed *
                Time.deltaTime
            );
			PlayWalkingParticles();
        }
		animator.SetFloat("forward", direction);
    }

    #endregion Movement

    #region Combat

    private void UpdateCombat()
    {
        bool[] selectedNotes = SelectedNotes();

        guitarNotes.HighlightLanes(selectedNotes);

        if (PlayerStrummed())
        {
            guitarNotes.PlayNotes(selectedNotes);
			animator.SetTrigger("attack");
		}
    }

    /// <summary>
    /// Checks whether the player has strummed the guitar or not
    /// </summary>
    /// <returns>Whether the player strummer up or down on guitar</returns>
    private bool PlayerStrummed()
    {
        // Get new strum value
		if (!inputDisabled) {
			switch (controller)
			{
				case Controller.KEYBOARD:
					currentStrum = Input.GetAxisRaw("KeyboardStrum");
					break;
				case Controller.GUITARHERO:
					currentStrum = Input.GetAxisRaw("GHStrum");
					break;
				case Controller.ROCKBAND:
					currentStrum = Input.GetAxisRaw("RBStrum");
					break;
			}
		}

        // Check if strum changed
        if (currentStrum != previousStrum)
        {
            // Save new value of strum as previous
            previousStrum = currentStrum;
            
            // Check if strum wasn't simply released
            if (currentStrum != 0)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Checks what combination of notes were pressed
    /// </summary>
    /// <returns>bool array, representing green to orange, where true means pressed</returns>
    private bool[] SelectedNotes()
    {
        string prefix = "";
        switch (controller)
        {
            case Controller.KEYBOARD:
                prefix = "Keyboard";
                break;
            case Controller.GUITARHERO:
                prefix = "GH";
                break;
            case Controller.ROCKBAND:
                prefix = "RB";
                break;
        }

        return new bool[]
        {
            Input.GetButton(prefix + "Green"),
            Input.GetButton(prefix + "Red"),
            Input.GetButton(prefix + "Yellow"),
            Input.GetButton(prefix + "Blue"),
            Input.GetButton(prefix + "Orange")
        };
    }

    #endregion Combat

    #region Inventory

    public void SetInventoryController(GameObject ic)
    {
        inventoryController = ic;
        this.ic = inventoryController.GetComponent<InventoryController>();
    }

    public void AddItemToInventory(GameObject item)
    {
        ic.AddItemToInventory(item);
    }

    public void DrinkPotion(GameObject potion)
    {
        playerHealth.AddHealthFromPotion(potion);
    }

    #endregion Inventory
	
	#region Particle Systems

	private void PlayWalkingParticles() {
		if (onGrass) {
			foreach (ParticleSystem ps in walkingParticles) {
				ps.Play();
			}
		}
	}
	
	#endregion Particle Systems
	
	public string GetState() {
		switch(currentState) {
			case State.COMBAT:
				return "combat";
			default:
				return "null";
		}
	}
	
	
	public void DisableInput() {
		inputDisabled = true;
	}
	
	
	public void EnableInput() {
		inputDisabled = false;
	}

	public void SetWinBoss() {
		wonBoss = true;
	}

	public bool WonBoss() {
		return wonBoss;
	}
	public void SetTutorialMode() {
		tutorialMode = true;
	}
	public bool InTutorial() {
		return tutorialMode;
	}
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			onGrass = true;
		}
	}
	
	
	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			onGrass = false;
		}
	}
	
}
