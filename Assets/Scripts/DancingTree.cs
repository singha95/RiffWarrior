using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingTree : MonoBehaviour {

	// Use this for initialization
	private GameObject player; 
	private AudioListener Listener;
	private int num;  
	private Vector3 scale; 

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		Listener = player.GetComponent<AudioListener>();
		num = 0; //Random.Range(0, 4);
		scale = transform.localScale; 
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float [1024]; 
		AudioListener.GetOutputData(spectrum, 0);

		float c1 = spectrum[2] + spectrum[3] + spectrum[4]; 
		float c2 = spectrum[11] + spectrum[12]  + spectrum[13];
		float c3 = spectrum[21] + spectrum[22]  + spectrum[23];
		float c4 = spectrum[44] + spectrum[45]  + spectrum[46] + spectrum[47] + spectrum[48]  + spectrum[49];

		switch (num)
		{
			case 0: 
				transform.localScale = scale + new Vector3(0, Mathf.Max(c1, 3f), 0); 
				break; 
			case 1: 
				transform.localScale = scale + new Vector3(0, Mathf.Max(c2, 0.5f), 0); 
				break; 
			case 2: 
				transform.localScale = scale +  new Vector3(0, Mathf.Max(c3, 0.5f), 0); 
				break; 
			case 3: 
				transform.localScale = scale + new Vector3(0, Mathf.Max(c4, 0.5f), 0); 
				break; 
			default:
				transform.localScale = scale + new Vector3(0, Mathf.Max(c4, 0.5f), 0); 
				break; 
		}

		Debug.Log(c1);
	}
}
