using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGO : MonoBehaviour {

	private bool lastNote;
	private bool damageNote;
	
	
	public void SetLastNote(bool isLastNote) {
		lastNote = isLastNote;
	}
	
	
	public void SetDamageNote(bool isDamageNote) {
		damageNote = isDamageNote;
	}
	
	
	public bool IsLastNote() {
		return lastNote;
	}
	
	
	public bool IsDamageNote() {
		return damageNote;
	}
	
}
