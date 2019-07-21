using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientTrackTransition : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			GameObject parent = transform.parent.gameObject;
			AudioManager audioManager = parent.GetComponent<AudioManager>();
			audioManager.ProgressAmbientTrack();
			Destroy(gameObject);
		}
	}
	
}
