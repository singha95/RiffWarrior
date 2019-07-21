using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPotion : MonoBehaviour {
	 public Camera cameraToLookAt;
	 public GameObject canvas;

	// Use this for initialization
	void Start () {
		canvas = gameObject.transform.Find("Canvas").gameObject;
		canvas.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = cameraToLookAt.transform.position - transform.position;
		v.x = v.z = 0.0f;
		canvas.transform.LookAt( cameraToLookAt.transform.position - v ); 
		canvas.transform.Rotate(0,180,0);
		
	}
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			canvas.SetActive(true);
        }
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
			canvas.SetActive(false);
		}
	}
}
