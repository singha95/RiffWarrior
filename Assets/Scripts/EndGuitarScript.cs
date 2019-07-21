using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGuitarScript : MonoBehaviour {
	
	//public Camera camera;
	public GameObject gm;
	private Vector3 MovingDirection;
	// Use this for initialization
	void Start () {
		MovingDirection = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(MovingDirection * Time.smoothDeltaTime);

		if(gameObject.transform.position.y > 17){
			MovingDirection = Vector3.down;
		}else if (gameObject.transform.position.y < 16) {
			MovingDirection = Vector3.up;
		}
	}
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			GameObject parent = transform.parent.gameObject;
			AudioManager audioManager = GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<AudioManager>();
			audioManager.PlayGuitarAcqTrack ();
			Destroy (gameObject);
			gm.GetComponent<GameManager>().EndGame();
		}
	}
}
