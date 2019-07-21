using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StatsManager : MonoBehaviour {
	
	public int pointsPerNote;
	public int maxScoreMultiplier;
	public int notesToHitForNextMultiplier;
	public float pulseSpeed;
	public Text scoreText;
	public Text multiplierText;
	public Text stats;
	public Slider multiplierSlider;
	public Image multiplierSliderFill;
	public Color maxMultiplierColour;
	public GameObject statsPanel;
	public GameObject gameManager;
	
	private int score;
	private int scoreMultiplier;
	private int difficultyMultiplier;
	private int multiplierProgress;
	private int hitCounter;
	private int missCounter;
	private bool isMultiplierMax;
	private Color defaultMultiplierFillColour;
	private PlayerHealth playerHealth;
	private GameManager gameManagerScript;
	
	
	private void Awake() {
		score = 0;
		scoreMultiplier = 1;
		multiplierProgress = 0;
		hitCounter = 0;
		missCounter = 0;
		isMultiplierMax = false;
		defaultMultiplierFillColour = multiplierSliderFill.color;
	}
	
	
	private void Start() {
		GameObject player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		gameManagerScript = gameManager.GetComponent<GameManager>();
		SetDifficultyMultiplier();
	}
	
	
	private void Update() {
		PulseMaxMultiplier();
		// DebugPointSystem();
	}
	
	
	private void SetDifficultyMultiplier() {
		GameManager.Difficulty difficulty = gameManagerScript.GetDifficulty();
		switch (difficulty) {
			case GameManager.Difficulty.Easy:
				difficultyMultiplier = 1;
				break;
			case GameManager.Difficulty.Medium:
				difficultyMultiplier = 2;
				break;
			case GameManager.Difficulty.Hard:
				difficultyMultiplier = 4;
				break;
			default:
				difficultyMultiplier = 0;
				break;
		}
	}
	
	
	private void PulseMaxMultiplier() {
		if (isMultiplierMax) {
			multiplierSliderFill.color = Color.Lerp(
				defaultMultiplierFillColour, 
				maxMultiplierColour, 
				Mathf.PingPong(Time.time, pulseSpeed)
			);
		} else {
			multiplierSliderFill.color = defaultMultiplierFillColour;
		}
	}
	
	
	// This function is called when a note is hit.
	public void ReportHit() {
		AddPoints();
		IncreaseMultiplierProgress();
		UpdateMultiplierSlider();
	}
	
	
	// This function is called when a note is missed.
	public void ReportMiss() {
		scoreMultiplier = 1;
		isMultiplierMax = false;
		UpdateMultiplierText();
		ResetMultiplierProgress();
		UpdateMultiplierSlider();
	}
	
	
	private void AddPoints() {
		score += pointsPerNote * scoreMultiplier * difficultyMultiplier;
		scoreText.text = score.ToString("#,#");
	}
	
	
	private void IncreaseMultiplierProgress() {
		multiplierProgress++;
		// Check if the notes required to advance to the next multiplier level
		// is satisfied.
		if (multiplierProgress >= notesToHitForNextMultiplier) {
			// Check the current score multiplier level. If it is below the max,
			// increase the score multiplier.
			if (scoreMultiplier < maxScoreMultiplier) {
				scoreMultiplier++;
				// If it is max, keep the multiplier progress full, and use
				// particle system.
				if (scoreMultiplier >= maxScoreMultiplier) {
					scoreMultiplier = maxScoreMultiplier;
					// If player was not at max combo, regain health.
					if (!isMultiplierMax)
						playerHealth.AddHealthFromCombo();
					isMultiplierMax = true;
				} else {
					ResetMultiplierProgress();
				}
			}
			UpdateMultiplierText();
		}
		UpdateMultiplierSlider();
	}
	
	
	private void ResetMultiplierProgress() {
		multiplierProgress = 0;
	}
	
	
	private void UpdateMultiplierText() {
		multiplierText.text = "x" + scoreMultiplier.ToString();
	}
	
	
	private void UpdateMultiplierSlider() {
		multiplierSlider.value = multiplierProgress;
	}
	
	
	public void IncreaseHitCounter() {
		hitCounter++;
	}
	
	
	public void IncreaseMissCounter() {
		missCounter++;
	}
	
	
	public void DisplayStats(float time) {
		float accuracy = hitCounter / (float) (hitCounter + missCounter) * 100;
		string minutes = Mathf.Floor(time / 60).ToString("0");
		string seconds = (time % 60).ToString("00");
		string timeComplete = minutes + ":" + seconds;
		string statsText;
		
		// For some reason, it won't show 0 if missCounter is 0.
		if (missCounter == 0) {
			statsText = String.Format("Time: {0}\nScore: {1:#,#}\nNotes hit: {2:#,#}\nNotes missed: 0\nAccuracy: {3:#.##}%",
			timeComplete, score, hitCounter, accuracy);
		} else {
			statsText = String.Format("Time: {0}\nScore: {1:#,#}\nNotes hit: {2:#,#}\nNotes missed: {3:#,#}\nAccuracy: {4:#.##}%",
			timeComplete, score, hitCounter, missCounter, accuracy);
		}
		
		stats.text = statsText;
		statsPanel.SetActive(true);
	}
	
	
	private void DebugPointSystem() {
		if (Input.GetKeyDown(KeyCode.Q))
			ReportHit();
		if (Input.GetKeyDown(KeyCode.W))
			ReportMiss();
	}
	
}
