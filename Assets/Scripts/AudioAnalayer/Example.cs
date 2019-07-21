/*
 * Copyright (c) 2015 Allan Pichardo
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;

public class Example : MonoBehaviour
{
	AudioSource source;
	List<Note> notes; 
	float previousnote = 0; 

	void Start ()
	{
		source = gameObject.GetComponent<AudioSource>();
		notes = new List<Note> (); 
		//Select the instance of AudioProcessor and pass a reference
		//to this object
		AudioProcessor processor = FindObjectOfType<AudioProcessor> ();
		processor.onBeat.AddListener (onOnbeatDetected);
		processor.onSpectrum.AddListener (onSpectrum);
	}

	void Update(){
		if (!source.isPlaying) {
			Debug.Log ("Compiling MusicNotes");
			MusicNotes ms = new MusicNotes (notes); 
			MusicNotesSerialization.Serialize (String.Format ("{0}.bin", source.clip.name), ms); 
		}
	}

	//this event will be called every time a beat is detected.
	//Change the threshold parameter in the inspector
	//to adjust the sensitivity
	void onOnbeatDetected ()
	{
		float time = source.time;
		if (time - previousnote > 0.5) {
			previousnote = time;
			float[] samples = new float[128];
			source.GetSpectrumData (samples, 0, FFTWindow.BlackmanHarris);
			//source.GetOutputData(samples, 1);
			float max = samples.Max (); 
			//float min = samples.Min ();
			//float final = Math.Abs (max) > Math.Abs (min) ? max : min; 
			int index = samples.ToList ().IndexOf (max);

			Debug.Log ("Beat!!! " + source.isPlaying + " " + time + " "
			+ index);
			notes.Add (new Note (index, time));
			notes.Add (new Note (index, time + 1));
		}
	}

	//This event will be called every frame while music is playing
	void onSpectrum (float[] spectrum)
	{
		//The spectrum is logarithmically averaged
		//to 12 bands

		for (int i = 0; i < spectrum.Length; ++i) {
			Vector3 start = new Vector3 (i, 0, 0);
			Vector3 end = new Vector3 (i, spectrum [i], 0);
			Debug.DrawLine (start, end);
		}
	}
}
