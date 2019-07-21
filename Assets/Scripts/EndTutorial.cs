using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour {

	// Use this for initialization

	bool detected = false;
	private GameObject player;				// Reference to player.

	private Animator playerAnimator;		// Reference to player's animator.
    private Animator anim; 
	private float timer = 3;
	void Start () {
		anim =  GameObject.FindGameObjectWithTag("HUD").GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
		if (detected){
			// playerAnimator.SetBool("isDead", true);
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
			timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("Main");
            }

		}
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			// player = other.transform.parent.gameObject;
			// playerAnimator = player.GetComponent<Animator>();
			detected = true;
        }
	}
		
		
		
		
}
