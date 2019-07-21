using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (gameObject.CompareTag("EndPortal")) {
			other.transform.position = GameObject.FindGameObjectWithTag ("EndPortalExit").transform.position;
		} 

		if (gameObject.CompareTag ("TutorialPortal")) {
			//Progression stage
			other.transform.position = new Vector3 (273, other.transform.position.y, 199);

			//Pedestal
			//other.transform.position = GameObject.FindGameObjectWithTag ("EndPortalExit").transform.position;

		}

	}
}
