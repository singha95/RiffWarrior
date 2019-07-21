using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public Vector3 cameraOffset;
	public float combatYOffset;
	public float xRotation;
	public float xCombatRotation;
	public float rotationSpeed;

	private Transform target;
	private PlayerController playerController;
	
	
	private void Start() {
		GameObject player = GameObject.FindWithTag("Player");
		SetTarget(player.transform);
		playerController = target.GetComponent<PlayerController>();
	}
	
	
	private void FixedUpdate() {
		MoveCamera();
		LookAtTarget();
	}
	
	
	public void SetTarget(Transform target) {
		this.target = target;
	}
	
	
	private void MoveCamera() {
		Vector3 destination = target.position +
			target.right * cameraOffset.x +
			target.up * cameraOffset.y +
			target.forward * cameraOffset.z;
			
		// Check collisions.
		RaycastHit hit;
		if (Physics.Linecast(target.position, destination, out hit)) {
			if (playerController.GetState() == "combat")
				destination = hit.point + new Vector3(0.0f, combatYOffset, 0.0f);
			else
				destination = hit.point;
		}
		
		transform.position = Vector3.Lerp(
			transform.position,
			destination,
			rotationSpeed * Time.deltaTime
		);
	}
	
	
	private void LookAtTarget() {	
		Vector3 destination = target.position +
			target.right * cameraOffset.x +
			target.up * cameraOffset.y +
			target.forward * cameraOffset.z;
			
		// Check collisions.
		RaycastHit hit;
		if (Physics.Linecast(target.position, destination, out hit)) {
			if (playerController.GetState() == "combat")
				transform.rotation = Quaternion.Euler(
					xCombatRotation,
					target.eulerAngles.y,
					0.0f
				);
			else
				transform.rotation = Quaternion.Euler(
					xRotation,
					target.eulerAngles.y,
					0.0f
				);
		} else
			transform.rotation = Quaternion.Euler(
				xRotation,
				target.eulerAngles.y,
				0.0f
			);
	}

}
