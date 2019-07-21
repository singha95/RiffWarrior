using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

	public float transitionDuration;
	public Color dayLight;
	public Color nightLight;
	public new Light light;
	
	private void Start() {
		light.color = dayLight;
	}
	
	
	public void ProgressLight() {
		StartCoroutine(TransitionDayToNight());
	}
	
	
	private IEnumerator TransitionDayToNight() {
		float time = 0.0f;
		while (time < 1.0f) {
			light.color = Color.Lerp(dayLight, nightLight, time);
			time += Time.deltaTime / transitionDuration;
			yield return null;
		}
	}

	private IEnumerator TransitionNightToDay() {
		float time = 0.0f;
		while (time < 1.0f) {
			light.color = Color.Lerp(nightLight, dayLight, time);
			time += Time.deltaTime / 10;
			yield return null;
		}
	}

	public void TransitionReset() {
		StartCoroutine (TransitionNightToDay ());
	}

	public void ResetLight() {
		light.color = dayLight;
	}
}
