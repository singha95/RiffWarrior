using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public float volumeChangeAmount;
	public float volumeMuteAmount;
	public float crossfadeYieldTime;
	public float pauseYieldTime;
	public float muteChangeAmount;
	public int startingAmbientTrackIndex;
	public AudioClip[] ambientTracks;
	public AudioClip[] easyRiffTracks;	// For normal enemies.
	public AudioClip[] easyDrumTracks;	// For normal enemies.
	public AudioClip[] medRiffTracks;
	public AudioClip[] medDrumTracks;
	public AudioClip[] hardRiffTracks;
	public AudioClip[] hardDrumTracks;
	public AudioClip[] guitarTracks;	// For bosses.
	public AudioClip[] backingTracks;	// For bosses.
	public AudioClip[] endingTracks; 

	private AudioSource[] audioSources;
	private AudioSource ambientTrack1;
	private AudioSource ambientTrack2;
	private AudioSource currentPlayingSource;
	private AudioSource riffTrack;
	private AudioSource drumTrack;
	private AudioSource errorTrack;
	private AudioSource guitarTrack;
	private AudioSource backingTrack;
	private AudioSource guitarAcqTrack;
	private AudioSource endAmbientTrack;
	private int currentAmbientTrack;
	private IEnumerator fadeRiffTrackEnum;
	private IEnumerator fadeDrumTrackEnum;
	
	
	private void Awake() {
		audioSources = GetComponentsInChildren<AudioSource>();
		ambientTrack1 = audioSources[0];
		ambientTrack2 = audioSources[1];
		riffTrack = audioSources[2];
		drumTrack = audioSources[3];
		errorTrack = audioSources[4];
		guitarTrack = audioSources[5];
		backingTrack = audioSources[6];
		guitarAcqTrack = audioSources[7];
		endAmbientTrack = audioSources[8];
		currentAmbientTrack = startingAmbientTrackIndex;
		fadeRiffTrackEnum = FadeRiffTrackEnum();
		fadeDrumTrackEnum = FadeDrumTrackEnum();
		PlayFirstAmbientTrack();
	}
	
	
	public void PlayFirstAmbientTrack() {
		ambientTrack1.clip = ambientTracks[currentAmbientTrack];
		ambientTrack1.Play();
		currentPlayingSource = ambientTrack1;
	}
	
	
	public void ProgressAmbientTrack() {
		currentAmbientTrack++;
		
		// Check which ambient track is playing.
		// If one ambient track is playing, stop it, and play the other.
		if (ambientTrack1.isPlaying) {
			ambientTrack2.clip = ambientTracks[currentAmbientTrack];
			ambientTrack2.volume = 0.0f;
			ambientTrack2.Play();
			currentPlayingSource = ambientTrack2;
			StartCoroutine(Crossfade1To2());
		} else if (ambientTrack2.isPlaying){
			ambientTrack1.clip = ambientTracks[currentAmbientTrack];
			ambientTrack1.volume = 0.0f;
			ambientTrack1.Play();
			currentPlayingSource = ambientTrack1;
			StartCoroutine(Crossfade2To1());
		}
	}
	
	
	private IEnumerator Crossfade1To2() {
		// Decrease the volume of track one, while increasing the volume of
		// track two.
		while (ambientTrack1.isPlaying) {
			ambientTrack1.volume -= volumeChangeAmount;
			ambientTrack2.volume += volumeChangeAmount;
			if (ambientTrack1.volume == 0.0f) {
				ambientTrack1.Stop();
				ambientTrack2.volume = 1.0f;
			}
			yield return new WaitForSecondsRealtime(crossfadeYieldTime);
		}
		yield break;
	}
	
	
	private IEnumerator Crossfade2To1() {		
		// Decrease the volume of track two, while increasing the volume of
		// track one.
		while (ambientTrack2.isPlaying) {
			ambientTrack2.volume -= volumeChangeAmount;
			ambientTrack1.volume += volumeChangeAmount;
			if (ambientTrack2.volume == 0.0f) {
				ambientTrack2.Stop();
				ambientTrack1.volume = 1.0f;
			}
			yield return new WaitForSecondsRealtime(crossfadeYieldTime);
		}
		yield break;
	}
	
	
	// You must stop ResumeAmbientTrack coroutine before calling this.
	public IEnumerator PauseAmbientTrack() {
		while (currentPlayingSource.isPlaying) {
			currentPlayingSource.volume -= volumeMuteAmount;
			if (currentPlayingSource.volume == 0.0f)
				currentPlayingSource.Pause();
			yield return new WaitForSecondsRealtime(pauseYieldTime);
		}
	}
	
	
	// You must stop PauseAmbientTrack coroutine before calling this.
	public IEnumerator ResumeAmbientTrack() {
		currentPlayingSource.UnPause();
		while (currentPlayingSource.volume != 1.0f) {
			currentPlayingSource.volume += volumeChangeAmount;
			yield return new WaitForSecondsRealtime(pauseYieldTime);
		}
	}
	
	
	public void PlayRiffTrack(EnemyController.Difficulty difficulty, int index) {
		StopCoroutine(fadeRiffTrackEnum);
		riffTrack.volume = 1.0f;
		switch (difficulty) {
			case EnemyController.Difficulty.Easy:
				riffTrack.clip = easyRiffTracks[index];
				break;
			case EnemyController.Difficulty.Medium:
				riffTrack.clip = medRiffTracks[index];
				break;
			case EnemyController.Difficulty.Hard:
				riffTrack.clip = hardRiffTracks[index];
				break;
		}
		riffTrack.Play();
	}	
	
	
	public void PlayDrumTrack(EnemyController.Difficulty difficulty, int index) {
		StopCoroutine(fadeDrumTrackEnum);
		drumTrack.volume = 1.0f;
		switch (difficulty) {
			case EnemyController.Difficulty.Easy:
				drumTrack.clip = easyDrumTracks[index];
				break;
			case EnemyController.Difficulty.Medium:
				drumTrack.clip = medDrumTracks[index];
				break;
			case EnemyController.Difficulty.Hard:
				drumTrack.clip = hardDrumTracks[index];
				break;
		}
		drumTrack.Play();
	}
	
	
	public void StopRiffTrack() {
		riffTrack.Stop();
	}
	
	
	public void StopDrumTrack() {
		drumTrack.Stop();
	}
	
	
	public void PlayGuitarTrack(int index) {
		guitarTrack.volume = 1.0f;
		guitarTrack.clip = guitarTracks[index];
		guitarTrack.Play();
	}

	public void PlayGuitarAcqTrack() {
		guitarAcqTrack.clip = endingTracks[0];
		guitarAcqTrack.Play ();
	}
	
	
	public void PlayBackingTrack(int index) {
		backingTrack.volume = 1.0f;
		backingTrack.clip = backingTracks[index];
		backingTrack.Play();
	}
	
	
	// You must stop MuteGuitarTrack coroutine before calling this.
	public IEnumerator UnmuteGuitarTrack() {
		while (guitarTrack.volume < 1.0f) {
			guitarTrack.volume += muteChangeAmount;
			yield return null;
		}
	}
	
	
	// You must stop UnmuteGuitarTrack coroutine before calling this.
	public IEnumerator MuteGuitarTrack() {
		while (guitarTrack.volume > 0.0f) {
			guitarTrack.volume -= muteChangeAmount;
			yield return null;
		}
	}
	
	
	public void PlayErrorTrack() {
			errorTrack.Play();
	}
	
	
	public bool IsDrumTrackPlaying() {
		return drumTrack.isPlaying;
	}
	
	
	public bool IsBackingTrackPlaying() {
		return backingTrack.isPlaying;
	}
	
	
	public IEnumerator MuteRiffTrack() {
		while (riffTrack.volume > 0.0f) {
			riffTrack.volume -= muteChangeAmount;
			yield return null;
		}
	}
	
	
	public IEnumerator UnmuteRiffTrack() {
		while (riffTrack.volume < 1.0f) {
			riffTrack.volume += muteChangeAmount;
			yield return null;
		}
	}
	
	
	public void FadeRiffTrack() {
		fadeRiffTrackEnum =  FadeRiffTrackEnum();
		StartCoroutine(fadeRiffTrackEnum);
	}
	
	
	private IEnumerator FadeRiffTrackEnum() {
		while (riffTrack.volume > 0.0f) {
			riffTrack.volume -= volumeMuteAmount;
			yield return null;
		}
	}
	
	
	public void FadeDrumTrack() {
		fadeDrumTrackEnum = FadeDrumTrackEnum();
		StartCoroutine(fadeDrumTrackEnum);
	}
	
	
	private IEnumerator FadeDrumTrackEnum() {
		while (drumTrack.volume > 0.0f) {
			drumTrack.volume -= volumeMuteAmount;
			yield return null;
		}
	}
	
	
	public void FadeGuitarTrack() {
		StartCoroutine(FadeGuitarTrackEnum());
	}
	
	
	private IEnumerator FadeGuitarTrackEnum() {
		while (guitarTrack.volume > 0.0f) {
			guitarTrack.volume -= volumeMuteAmount;
			yield return null;
		}
	}
	
	
	public void FadeBackingTrack() {
		StartCoroutine(FadeBackingTrackEnum());
	}
	
	
	private IEnumerator FadeBackingTrackEnum() {
		while (backingTrack.volume > 0.0f) {
			backingTrack.volume -= volumeMuteAmount;
			yield return null;
		}
	}
	
	
	public float GetRiffTrackVolume() {
		return riffTrack.volume;
	}
	
	
	public float GetGuitarTrackVolume() {
		return guitarTrack.volume;
	}
	
	
	public void PlayEndAmbientTrack() {
		StartCoroutine(PlayEndAmbientTrackCoroutine());
	}
	
	
	private IEnumerator PlayEndAmbientTrackCoroutine() {
		endAmbientTrack.Play();
		while (endAmbientTrack.volume < 1.0f) {
			endAmbientTrack.volume += volumeChangeAmount;
			yield return new WaitForSecondsRealtime(crossfadeYieldTime);
		}
	}
	
}
