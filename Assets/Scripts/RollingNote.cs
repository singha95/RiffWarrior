using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingNote : MonoBehaviour {
	private List<float> notes = new List<float> ();
	private int curr = 0;
	public bool timerReset;
	public Transform noteObj;
	private float xPos;
	public Transform line;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 100; i++) {
			notes.Add(Random.Range(1, 5));
		}
		/*
		for (int i = 0; i < 5; i++) {
			Instantiate (line, new Vector3(i*4+2, gameObject.transform.localPosition.y+3, transform.localScale.z/2), line.rotation);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (timerReset)
		{
			StartCoroutine (spawnFixedNotes ());
			timerReset = false;
		}
	}
	/*
	IEnumerator spawnNote()
	{

		yield return new WaitForSeconds (1);
		//xPos = notes [curr] * 4 + 2;
		if (notes [curr] == 1) {
			xPos = 2.8f;
		}
		if (notes [curr] == 2) {
			xPos = 6.01f;
		}
		if (notes [curr] == 3) {
			xPos = 9.82f;
		}
		if (notes [curr] == 4) {
			xPos = 13.39f;
		}
		if (notes [curr] == 5) {
			xPos = 17.15f;
		}
		curr++;
		timerReset = true;
		//Instantiate (noteObj, new Vector3 (xPos, transform.localPosition.y+3, transform.localScale.z/2), noteObj.rotation);
		Instantiate (noteObj, new Vector3 (xPos, 4.94f, 13.84f), noteObj.rotation);

	}
	*/
	IEnumerator spawnFixedNotes()
	{

		yield return new WaitForSeconds (1);
		//xPos = notes [curr] * 4 + 2;
		if (notes [curr] == 1) {
			xPos = transform.position.x - 6.9f;
		}
		if (notes [curr] == 2) {
			xPos = transform.position.x - 3.69f;
		}
		if (notes [curr] == 3) {
			xPos = transform.position.x + 0.12f;
		}
		if (notes [curr] == 4) {
			xPos = transform.position.x + 3.69f;
		}
		if (notes [curr] == 5) {
			xPos = transform.position.x + 7.45f;
		}
		curr++;
		timerReset = true;
		//Instantiate (noteObj, new Vector3 (xPos, transform.localPosition.y+3, transform.localScale.z/2), noteObj.rotation);
		Instantiate (noteObj, new Vector3 (xPos, 4.94f, 13.84f), noteObj.rotation);

	}

	void SpawnNote(int note){
		if (notes [curr] == 1) {
			xPos = transform.position.x - 6.9f;
		}
		if (notes [curr] == 2) {
			xPos = transform.position.x - 3.69f;
		}
		if (notes [curr] == 3) {
			xPos = transform.position.x + 0.12f;
		}
		if (notes [curr] == 4) {
			xPos = transform.position.x + 3.69f;
		}
		if (notes [curr] == 5) {
			xPos = transform.position.x + 7.45f;
		}
	}
}
