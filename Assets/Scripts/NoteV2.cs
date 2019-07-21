using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NoteV2 {
	
	public NoteV2(int laneNum, float time, bool lastNote, bool damageNote = false) {
		this.laneNum = laneNum;
		this.time = time;
		this.lastNote = lastNote;
		this.damageNote = damageNote;
	}

	public int laneNum;
	public float time;
	public bool lastNote;
	public bool damageNote;
	
}
