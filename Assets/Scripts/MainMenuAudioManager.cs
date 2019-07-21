using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioManager : MonoBehaviour {
	
	public float fadeAmount;
	
	private AudioSource menuTrack;
	private IEnumerator trackUnfader;
	
	
	private void Awake() {
		menuTrack = GetComponentInChildren<AudioSource>();
		trackUnfader = UnfadeTrackCoroutine(menuTrack);
		StartCoroutine(trackUnfader);
	}
	
	
	private IEnumerator UnfadeTrackCoroutine(AudioSource track) {
		while (track.volume < 1.0f) {
			track.volume += fadeAmount;
			yield return null;
		}
	}
	
	
	private IEnumerator FadeTrackCoroutine(AudioSource track) {
		while (track.volume > 0.0f) {
			track.volume -= fadeAmount;
			yield return null;
		}
	}
	

	public void FadeTrack() {
		StopCoroutine(trackUnfader);
		StartCoroutine(FadeTrackCoroutine(menuTrack));
	}
	
}
