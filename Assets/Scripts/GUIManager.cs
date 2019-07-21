using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {
	
	public GameObject loading;
	public GameObject difficultyGameObject;
	public GameObject audioManager;
	public GameObject[] menus;
	public GameObject[] mainMenuButtons;
	public GameObject[] difficultyButtons;
	
	private float strumValue;
	private int mainMenuIndex;
	private int diffButtonIndex;
	private EventSystem eventSystem;
	private DifficultyScript difficultyScript;
	private MainMenuAudioManager audioManagerScript;
	
	
	private void Awake() {
		strumValue = 0.0f;
		eventSystem = GetComponent<EventSystem>();
		difficultyScript = difficultyGameObject.GetComponent<DifficultyScript>();
		audioManagerScript = audioManager.GetComponent<MainMenuAudioManager>();
		LoadMainMenu();
	}
	
	
	private void Update() {
		GetInput();
	}
	
	
	private void LoadMainMenu() {
		ClearMenus();
		menus[0].SetActive(true);
		mainMenuIndex = 0;
		eventSystem.SetSelectedGameObject(mainMenuButtons[mainMenuIndex]);
	}
	
	
	private void LoadDifficultyMenu() {
		ClearMenus();
		menus[1].SetActive(true);
		diffButtonIndex = 0;
		eventSystem.SetSelectedGameObject(difficultyButtons[diffButtonIndex]);
	}
	
	
	private void ClearMenus() {
		foreach (GameObject menu in menus) {
			menu.SetActive(false);
		}
	}
	
	
	private void GetInput() {
		// In the main menu.
		if (menus[0].activeSelf) {
			
			// Navigation
			if (Input.GetButtonDown("RBGreen") || Input.GetKeyDown(KeyCode.LeftArrow)) {
				if (mainMenuIndex > 0) {
					mainMenuIndex--;
					eventSystem.SetSelectedGameObject(mainMenuButtons[mainMenuIndex]);
				}
			}
			if (Input.GetButtonDown("RBRed") || Input.GetKeyDown(KeyCode.RightArrow)) {
				if (mainMenuIndex < mainMenuButtons.Length - 1) {
					mainMenuIndex++;
					eventSystem.SetSelectedGameObject(mainMenuButtons[mainMenuIndex]);
				}
			}
			
			// Selection
			if (Input.GetAxisRaw("RBStrum") != 0.0f || Input.GetKeyDown(KeyCode.Return)) {
				strumValue = Input.GetAxisRaw("RBStrum");
				switch (mainMenuIndex) {
					case 0:
						LoadDifficultyMenu();
						break;
					case 1:
						SelectTutorial();
						break;
					case 2:
						break;
					default:
						break;
				}
			}
			
		// In the difficulty menu.
		} else if (menus[1].activeSelf) {
			
			// Navigation
			if (Input.GetButtonDown("RBGreen") || Input.GetKeyDown(KeyCode.LeftArrow)) {
				if (diffButtonIndex > 0) {
					diffButtonIndex--;
					eventSystem.SetSelectedGameObject(difficultyButtons[diffButtonIndex], null);
				}
			}
			if (Input.GetButtonDown("RBRed") || Input.GetKeyDown(KeyCode.RightArrow)) {
				if (diffButtonIndex < difficultyButtons.Length - 1) {
					diffButtonIndex++;
					eventSystem.SetSelectedGameObject(difficultyButtons[diffButtonIndex], null);
				}
			}
			
			// Back
			if (Input.GetButtonDown("RBYellow") || Input.GetKeyDown(KeyCode.Escape)) {
				LoadMainMenu();
			}
			
			// Selection
			if (Input.GetAxisRaw("RBStrum") != 0.0f) {
				if (Input.GetAxisRaw("RBStrum") != strumValue) {
					SelectDifficulty();
				}
			} else if (Input.GetKeyDown(KeyCode.Return)) {
				SelectDifficulty();
			} else {
				strumValue = 0.0f;
			}
		}
	}
	
	
	private void SelectTutorial() {
		ClearMenus();
		loading.SetActive(true);
		audioManagerScript.FadeTrack();
		difficultyScript.SetDifficulty("easy");
		StartCoroutine(LoadSceneAsync(2));
	}
	
	
	private void SelectDifficulty() {
		// Set difficulty setting.
		switch (diffButtonIndex) {
			case 0:
				difficultyScript.SetDifficulty("easy");
				break;
			case 1:
				difficultyScript.SetDifficulty("medium");
				break;
			case 2:
				difficultyScript.SetDifficulty("hard");
				break;
			default:
				break;
		}
		
		// Load next scene with difficulty setting.
		ClearMenus();
		loading.SetActive(true);
		audioManagerScript.FadeTrack();
		StartCoroutine(LoadSceneAsync(1));
	}
	
	
	private IEnumerator LoadSceneAsync(int sceneNum) {
		DontDestroyOnLoad(difficultyGameObject);
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneNum);
		while (!asyncLoad.isDone) {
			yield return null;
		}
	}

}
