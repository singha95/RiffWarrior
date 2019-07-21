using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTransition : MonoBehaviour {

	LightManager lightManager;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			//GameObject parent = transform.parent.gameObject;
			lightManager = GameObject.FindGameObjectWithTag("LightManager").GetComponent<LightManager>();
			if (gameObject.CompareTag("ProgressionStage")) {
				lightManager.ProgressLight ();
				Destroy (gameObject);
			}
		}
	}

	
}
