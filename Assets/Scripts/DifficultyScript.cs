using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour {

	private string difficulty;
	
	
	public void SetDifficulty(string difficulty) {
		this.difficulty = difficulty;
	}
	
	
	public string GetDifficulty() {
		return difficulty;
	}
	
}
