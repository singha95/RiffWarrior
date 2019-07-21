using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject[] enemies;
	
	
	private void Awake() {
		// Right now it is just spawning set locations. Use GenerateEnemy()
		// for map generator. The function will probably need to be expanded
		// upon to select from a tier of enemies
		/* GenerateEnemy(new Vector3(-200.0f, 10.0f, 30.0f));
		GenerateEnemy(new Vector3(-400.0f, 10.0f, 350.0f));
		GenerateEnemy(new Vector3(90.0f, 10.0f, 350.0f));
		GenerateEnemy(new Vector3(200.0f, 10.0f, 50.0f));
		GenerateEnemy(new Vector3(210.0f, 10.0f, -160.0f));
		GenerateEnemy(new Vector3(-110.0f, 10.0f, -260.0f));
		GenerateEnemy(new Vector3(105.0f, 10.0f, 140.0f));
		GenerateEnemy(new Vector3(2.0f, 10.0f, 140.0f));
		GenerateEnemy(new Vector3(-97.0f, 10.0f, 140.0f));
		GenerateEnemy(new Vector3(-188.0f, 10.0f, 140.0f));
		GenerateEnemy(new Vector3(-105.0f, 10.0f, -150.0f));
		GenerateEnemy(new Vector3(0.0f, 10.0f, -250.0f));
		GenerateEnemy(new Vector3(107.0f, 10.0f, -250.0f));
		GenerateEnemy(new Vector3(220.0f, 10.0f, -250.0f));
		GenerateEnemy(new Vector3(300.0f, 10.0f, -250.0f));
		GenerateEnemy(new Vector3(300.0f, 10.0f, -160.0f));
		GenerateEnemy(new Vector3(105.0f, 10.0f, 60.0f));
		GenerateEnemy(new Vector3(105.0f, 10.0f, -45.0f));
		GenerateEnemy(new Vector3(107.0f, 10.0f, -144.0f));		
		GenerateEnemy(new Vector3(200.0f, 10.0f, -50.0f));
		GenerateEnemy(new Vector3(-320.0f, 10.0f, -29.0f)); */
	}
	
	
	public void GenerateEnemy(Vector3 position) {
		int randomMonster = Random.Range(0, enemies.Length);
		Instantiate(enemies[randomMonster], position, Quaternion.identity);
	}
	
}
