using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class MusicNotes
{
	public float deltaDelay = 1; 
	public int numLanes = 5;

	private Queue<Note> notes; 
	private float totalLenght;


	public MusicNotes (List<Note> notes)
	{
		this.notes = new Queue<Note>();
		for (int i = 0; i < notes.Count; i++) {
			addNote (notes [i]);
		}
	}

	public void addNote(Note note){
		
		if (note.Pitch < 5 && note.Pitch >= 0) {
			this.notes.Enqueue (note);
		} else {
			throw new Exception ();
		}
	}
	

	public float AvgFreq(){
		float sum = notes.Sum (x => x.Pitch);
		return sum/(float)this.notes.Count;  
	}

	/*
	 * Takes a time and returns the closest music note for the given time in a given range. Returns null
	 * if there is no note in the given range. 
	 * 
	 * Input:
	 * time - float representation of the tiem in the song.
	 * 
	 * Return: 
	 * Note - A note object representation of the time and freqency of the note. The pitch component will contain 
	 * the lane in which the note must spawn. 
	 */
	public List<Note> GetNotesAtTime(float time){
		List<Note> timenotes = new List<Note> ();
		if (notes.Count != 0) {
			bool hasNotes = true; 
			while (hasNotes) {
				if (notes.Count > 0) {
					Note currentNote = notes.Peek();
					if ((currentNote.Time - time) < deltaDelay) {
						currentNote = notes.Dequeue ();
						timenotes.Add(new Note (currentNote.Pitch % numLanes, currentNote.Time));
					}else {
						return timenotes; 
					}
				} else {
					hasNotes = false;
				}

			}
		}
		return timenotes; 
	}


}


