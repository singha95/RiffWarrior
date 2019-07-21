using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMusicNotes : MonoBehaviour {
	private List<Note> notes = new List<Note>(); 

	// Use this for initialization
	void Start () {
		//RhythmDemoPatternNormal();
		//RhythmDemoPatternEasy ();
		//IAmEvil ();
		BossThemePattern();
		//TempPattern();
		Debug.Log ("Outputing MusicSheet");
		MusicNotesSerialization.Serialize ("Boss Theme 1.bin", new MusicNotes (notes));
		Debug.Log ("Testing");
		MusicNotes music = MusicNotesSerialization.Deserialize ("Boss Theme 1.bin");
		Debug.Log (music.AvgFreq());

	}
	void AddNote(int lane, float time){
		notes.Add (new Note (lane, time));
	}
		

	void AlternateNotes(int note1, int note2, float start, float end, float interval){
		for (float i = start; i < end; i=i+interval) {
			if (i % 2 == 0) {
				notes.Add (new Note (note1, i));
			} else {
				notes.Add (new Note (note2, i));
			}
						
		}
	}

	void AlternateNotes5(int note1, int note2, float start, float end){
		for (float i = start; i < end; i=i+0.5f) {
			if (i % 1 == 0) {
				notes.Add (new Note (note1, i));
			} else {
				notes.Add (new Note (note2, i));
			}

		}
	}

	void GroupDoubles(int note1, int note2, float start, float end, float interval){
		for (float i = start; i < end;  i=i+interval) {
			notes.Add (new Note (note1, i));
			notes.Add (new Note (note2, i));
		}
	}
	void AddSingles(int note, float start, float end, float interval){
		for (float i = start; i < end;  i=i+interval) {
			notes.Add (new Note (note, i));
		}
	}

	MusicNotes RhythmDemoPatternNormal(){
		notes = new List<Note> ();
		AlternateNotes5(1,2, 6f, 9f);
		AddNote (0, 10f);
		AddNote (0, 12.2f);
		AddNote (4, 15f);
		AddNote (2, 16f);
		AddNote (1, 16f); 
		AddNote (4, 18f);
		AddNote (3, 19f);
		AddNote (2, 21f);
		AddNote (2, 22f);
		AddNote (3, 22.5f);
		AddNote (4, 24f);
		AddNote (3, 24f);
		return new MusicNotes (notes);
	}

	MusicNotes RhythmDemoPatternEasy(){
		notes = new List<Note> ();
		AddSingles (0, 6f, 10f, 1f);
		AddNote (4, 12.5f);
		AddNote (4, 15f);
		AddNote (3, 18f);
		AddNote (4, 18f);
		AddNote (2, 19f);
		AddNote (3, 20.5f); 
		AddNote (4, 21f);
		AddNote (3, 24f);
		AddNote (4, 24f);
		return new MusicNotes (notes);
	}

	MusicNotes TempPattern(){
		notes = new List<Note> ();
		AlternateNotes5 (2, 3, 2.5f, 10.5f); 
		AlternateNotes5 (1, 2, 10.5f, 26.3f);
		AddSingles (0, 26.5f, 33f, 1f);
		return new MusicNotes (notes);
	}

	MusicNotes IAmEvil(){
		notes = new List<Note> ();
		AddNote (2, 7f);
		AddNote (2, 10f);
		AddNote (2, 12.2f);
		AddNote (3, 14.5f);
		AlternateNotes5(2,3, 16.5f, 19f);
		AlternateNotes5(2,3, 19.5f, 22f);
		AlternateNotes5(2,3, 19.5f, 22f);
		AlternateNotes5(2,3, 23f, 25f);
		AlternateNotes5(2,3, 26f, 28f);
		return new MusicNotes (notes);
	}



	MusicNotes BossThemePattern(){
		notes = new List<Note> ();
		AddNote(3, 6.6f);
		AddNote(3, 7.1f);
		AddNote(2, 7.5f);
		AddNote(3, 7.9f);
		AddNote(3, 8.5f);
		AddNote(3, 8.7f);
		AddNote(3, 10f);
		AddNote(2, 10.8f);
		AddNote(4, 11.2f);


		AddNote(4, 12.5f); 
		AddNote(4, 13f); 

		AddNote(4, 13.4f); 
		AddNote(3, 13.6f);
		AddNote(2, 14.1f);
		AddNote(1, 14.5f);
		AddNote(0, 15f);

		AddNote(3, 20f);
		AddNote(3, 20.3f);
		AddNote(3, 20.6f);

		AddNote(3, 21.6f);
		AddNote(3, 21.9f);
		AddNote(3, 22.2f);

		AddNote (3, 23.2f);
		AddNote (4, 24.1f);
		AddNote(4, 25.4f); 

		AddNote (1, 26.2f);
		AddNote (2, 26.5f);
		AddNote (1, 26.8f);

		AddNote (3, 28.3f);
		AddNote(2, 29.1f);

		AddNote (2, 30.4f);
		AddNote (3, 30.6f);
		AddNote (2, 31.2f);
		AddNote(3, 31.6f);
		AddNote(2, 32.5f);
	
		AddNote(1, 40f);
		AddNote(0, 40.5f);
		AddNote(1, 40.7f);
		AddNote(0, 41.4f);
		AddNote(1, 41.6f);

		AddNote(2, 43.3f);
		AddNote(1, 43.7f);
		AddNote(2, 44.2f);
		AddNote(1, 44.6f);
		AddNote(2, 45f);
		
		AddNote(3, 45.7f);
		AddNote(4, 46.2f);
		AddNote(3, 46.6f);
		AddNote(2, 47.1f);
		AddNote(1, 47.5f);
		AddNote(0, 48f);
		AddNote(1, 48.3f);

		AddNote (1, 50f);
		AddNote (1, 52f);
		AddNote (1, 53.4f);
		AddNote (1, 55f);
		AddNote (1, 56.5f);
		AddNote (1, 58.2f);

		AddSingles(0, 60f, 66.6f, 0.5f);

		AddNote(3, 66.7f);
		AddNote(2, 67.1f);
		AddNote(3, 67.5f);

		AddNote(2, 68f);
		AddNote(1, 68.3f);
		AddNote(2, 68.8f);

		AddNote (2, 70.8f);
		AddNote (2, 71.2f);
		AddNote(3, 72.1f);
		AddNote(2, 72.5f);
		AddNote(3, 72.8f);
		AddNote(4, 73.1f);
		AddNote(3, 73.4f);

		AddNote(4, 75f);
		AddNote(3, 75.8f);
		AddNote(2, 77f);
		AddNote(3, 77.5f);
		AddNote(2, 77.9f);
		AddNote(3, 78.2f);
		AddNote(4, 79.2f);

		AddSingles(0, 80f, 81.2f, 0.5f);
		AddNote(1, 81.8f);
		AddSingles(0, 82f, 85f, 0.5f);
		AddNote(0, 85.3f);
		AddNote(1, 85.3f);

		AddNote(0, 85.6f);
		AddNote(1, 85.6f);

		AddNote(0, 85.9f);
		AddNote(1, 85.9f);

		AddSingles(0, 86.7f, 88.3f, 0.5f);
		AddSingles(1, 90f, 91.7f, 0.5f);
		
		GroupDoubles(0, 1, 91.7f, 93.1f, 0.5f);
		GroupDoubles(2, 3, 93.3f, 95f, 0.5f);

		AddNote(4, 95.5f);
		AddNote(3, 95.8f);

		AddNote(2, 96.4f);
		AddNote(1, 95.7f);
		AddNote(3,97.1f);
		AddNote(3,97.5f);
		AddNote(3,98f);

		AddNote(4, 98.9f);
		AddNote(3,99.2f);

		AddNote(4, 99.8f);
		AddNote(3, 100f);

		AddNote(4, 101f);
		AddNote(3, 101.4f);
		AddNote(2, 101.9f);
		AddNote(1, 102.3f);
		AddNote(0, 102.8f);
		AddNote(1, 103.1f);

		AddNote(0, 105f);
		AddNote(1, 105f);
		AddNote(0, 105.3f);
		AddNote(1, 105.3f);
				
		AddNote(0, 106.4f);
		AddNote(1, 106.4f);
		AddNote(0, 106.7f);
		AddNote(1, 106.7f);

		AddNote(0, 108.3f);
		AddNote(1, 108.3f);
		AddNote(0, 108.6f);
		AddNote(1, 108.6f);

		AddNote(1, 109.8f);
		AddNote(2, 109.8f);
		AddNote(1, 110.1f);
		AddNote(2, 110.1f);

		AddNote(1, 111.7f);
		AddNote(2, 111.7f);
		AddNote(1, 112f);
		AddNote(2, 112f);

		AddNote(0, 113.1f);
		AddNote(1, 113.1f);
		AddNote(0, 113.4f);
		AddNote(1, 113.4f);

		AddNote(1, 114.1f);
		AddNote(0, 114.1f);

		AddSingles(1, 115f, 120f, 0.5f);

		AddNote(3, 121.7f);
		AddNote(3, 122.2f);
		AddNote(2, 122.6f);
		AddNote(3, 123f);
		AddNote(3, 123.6f);
		AddNote(3, 123.8f);
		AddNote(2, 124.1f);
		AddNote(3, 124.9f);
		AddNote(4, 125.3f);

		AddNote(4, 125.9f);
		AddNote(4, 126.4f);

		AddNote(3, 126.8f);
		AddNote(2, 127.3f);

		AddNote(3, 128.2f);
		AddNote(2, 128.5f);
		AddNote(3, 128.8f);

		AddNote(4, 129.9f);
		AddNote(3, 130.6f);

		AddNote(1, 132.1f);
		AddNote(2, 132.6f);
		AddNote(3, 132.9f);
		AddNote(4, 133.4f);

		return new MusicNotes (notes);
	}

}
