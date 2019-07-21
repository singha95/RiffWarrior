using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private float timer;
	private GameObject player;				// Reference to player.
    private PlayerHealth playerHealth;      // Reference to the player's health.

	private Animator playerAnimator;		// Reference to player's animator.
    private Animator anim;                          // Reference to the animator component.

    void Start()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>() as PlayerHealth;
		playerAnimator = player.GetComponent<Animator>();
        timer = 5;
    }

    void Update()
    {
        // If the player has run out of health...
        //print(playerHealth.currentHealth);
        if (playerHealth.currentHealth <= 0)
        {
			playerAnimator.SetBool("isDead", true);
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
