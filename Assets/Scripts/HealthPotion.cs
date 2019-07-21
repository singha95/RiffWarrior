using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour {

	public float healthRecovery;
	public float rotationSpeed;
	public float pulseDuration;
	public Color pulseColourStart;
	public Color pulseColourEnd;
	
	private Image recoveryImage;
	private MeshRenderer meshRenderer;
	
	
	private void Awake() {
		meshRenderer = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
	}
	
	
	private void Update() {
		Pulse();
	}
	
	
	private void FixedUpdate() {
		// Rotate();
	}
	
	
	private void Pulse() {
		meshRenderer.material.color = Color.Lerp(
			pulseColourStart, 
			pulseColourEnd,
			Mathf.PingPong(Time.time, pulseDuration));
	}
	
	
	private void Rotate() {
		gameObject.transform.Rotate (
			Vector3.up *
			rotationSpeed * 
			Time.deltaTime
		);
	}
	
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {	
			PlayerController pc = other.GetComponent<PlayerController>();
			pc.DrinkPotion(gameObject);
		}
	}
	
	
	public float GetHealthRecovery() {
		return healthRecovery;
	}
	
}
