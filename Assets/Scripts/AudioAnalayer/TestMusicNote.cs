using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class TestMusicNote: MonoBehaviour {
	public Text text; 
	public Text text2; 

	void Start(){
		//text.text = Application.dataPath;
		List<Note> notes = new List<Note> ();
		for (int i = 1; i < 21; i++) {
			notes.Add(new Note(4, 1.0f * i));
			notes.Add(new Note(0, 1.0f * i));
		}
		MusicNotes ms = new MusicNotes (notes);

		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, ms);
		stream.Close();


		//text2.text = String.Format("{0}", ms2.AvgFreq());



		Debug.Log(String.Format("{0}", ms.AvgFreq()));
	}

	void Update(){

	}

}

