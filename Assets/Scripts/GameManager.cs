using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public static Difficulty difficulty;

	public Vector3 spawnPoint;
	public float playerYRotation;
	public GameObject player;
	public GameObject inventoryController;
	public GameObject treasureChest;
	public GameObject HUD;
	public GameObject enemyGenerator;
	public GameObject displayCamera;
	public GameObject statsManager;
	public GameObject superPortal;
	public bool isGameFinished;
	public enum Difficulty {Easy, Medium, Hard};
	
	private Vector3 playerSpawnPoint;
	private LootController lootController;
	private InventoryUI inventoryUI;
	private PlayerController playerController;
	private float startTime;
	private StatsManager statsManagerScript;

	private void Awake() {
		SpawnPlayer(
			spawnPoint,
			Quaternion.Euler(0.0f, playerYRotation, 0.0f)
		);
        SpawnInventoryController();
		SetInventoryControllers();
        inventoryUI.invPanel = HUD.transform.GetChild(2).gameObject;
		statsManagerScript = statsManager.GetComponent<StatsManager>();
		isGameFinished = false;
		
		// Log start time for stats manager.
		startTime = Time.time;
		
		GetDifficultyFromMain();
    }

	
	private void Update() {
		if (isGameFinished) {
			GameObject destroyDifficulty = GameObject.FindWithTag("Difficulty");
			if (destroyDifficulty != null) {
				Destroy(destroyDifficulty);
			}
			if (Input.anyKeyDown) {
				SceneManager.LoadScene (0);
			}
		}
		if (playerController.WonBoss()) {
			GameObject.FindGameObjectWithTag ("LightManager").GetComponent<LightManager> ().TransitionReset ();
		}
	}


    private void SpawnPlayer(Vector3 spawnPoint, Quaternion rotation) {
		player = Instantiate(player, spawnPoint, rotation);
		playerController = player.GetComponent<PlayerController>();
    }
	
	
	private void SpawnInventoryController() {
		inventoryController = Instantiate(inventoryController);
	}
	
	
	private void SetInventoryControllers() {
		inventoryUI = HUD.GetComponent<InventoryUI>();
		inventoryUI.SetInventoryController(inventoryController);
		playerController.SetInventoryController(inventoryController);
	}
	
	
	private void SpawnChest(Vector3 position) {
		treasureChest = Instantiate(
			treasureChest, 
			position, 
			Quaternion.AngleAxis(90, Vector3.forward)
		);
		lootController = treasureChest.GetComponent<LootController>();
		lootController.SetInventoryController(inventoryController);
		
	}
	
	
	private void SpawnEnemyGenerator() {
		enemyGenerator = Instantiate(enemyGenerator);
	}
	
	
	public void EndGame() {
		statsManagerScript.DisplayStats(Time.time - startTime);
		Input.ResetInputAxes();
		playerController.DisableInput();
		isGameFinished = true;
	}
	
	
	public Difficulty GetDifficulty() {
		return difficulty;
	}
	
	
	// Gets difficulty from the main menu scene.
	private void GetDifficultyFromMain() {
		GameObject difficultyGameObject = GameObject.FindWithTag("Difficulty");
		if (difficultyGameObject != null) {
			DifficultyScript difficultyScript = difficultyGameObject.GetComponent<DifficultyScript>();
			switch (difficultyScript.GetDifficulty()) {
				case "easy":
					difficulty = Difficulty.Easy;
					break;
				case "medium":
					difficulty = Difficulty.Medium;
					break;
				case "hard":
					difficulty = Difficulty.Hard;
					break;
				default:
					difficulty = Difficulty.Easy;
					break;
			}
		} else {
			difficulty = Difficulty.Easy;
		}
	}
		

}
