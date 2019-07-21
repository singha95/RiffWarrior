using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


public static class MusicNotesSerialization
{

	public static void Serialize(string path, MusicNotes notes){
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, notes);
		stream.Close();
	}

	public static MusicNotes Deserialize(string path){
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		MusicNotes ms2 = (MusicNotes) formatter.Deserialize(stream);
		return ms2;
	}
}



