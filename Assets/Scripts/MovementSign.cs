using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovementSign : MonoBehaviour {

	// Use this for initialization
	public GameObject playerUI; 
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			playerUI.GetComponent<Image>().enabled = false;
        }
	}
	void OnTriggerExit(Collider other){

	}
}
