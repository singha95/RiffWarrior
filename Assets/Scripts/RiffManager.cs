using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiffManager : MonoBehaviour {

	public GameObject gameManager;
	public GameObject audioManager;
	
	private GameObject player;
	private GuitarNotesController guitarNotesController;
	private GameManager gameManagerScript;
	private AudioManager audioManagerScript;
	private EnemyDetection enemyDetection;
	private GameManager.Difficulty gameDifficulty;
	private Coroutine unmuteRiffTrack;
	private Coroutine muteRiffTrack;
	private List<List<NoteV2>> easyEasyRiffs;	// Easy enemy, easy game.
	private List<List<NoteV2>> easyMedRiffs;	// Easy enemy, medium game.
	private List<List<NoteV2>> easyHardRiffs;	// Easy enemy, hard game.
	private List<List<NoteV2>> medEasyRiffs;
	private List<List<NoteV2>> medMedRiffs;
	private List<List<NoteV2>> medHardRiffs;
	private List<List<NoteV2>> hardEasyRiffs;
	private List<List<NoteV2>> hardMedRiffs;
	private List<List<NoteV2>> hardHardRiffs;
	private List<List<NoteV2>> bossEasyTracks;
	private List<List<NoteV2>> bossMediumTracks;
	private List<List<NoteV2>> bossHardTracks;
	private int riffNum;
	private float offsetEasy01;
	private float offsetEasy02;
	private float offsetEasy03;
	private float offsetMed01;
	private float offsetMed02;
	private float offsetMed03;
	private float offsetMed04;
	private float offsetHard01;
	private float offsetHard02;
	private float offsetHard03;
	private float offsetHard04;
	private float offsetHard05;
	private float offsetBT1;
	
	
	private void Awake() {
		easyEasyRiffs = new List<List<NoteV2>>();
		easyMedRiffs = new List<List<NoteV2>>();
		easyHardRiffs = new List<List<NoteV2>>();
		medEasyRiffs = new List<List<NoteV2>>();
		medMedRiffs = new List<List<NoteV2>>();
		medHardRiffs = new List<List<NoteV2>>();
		hardEasyRiffs = new List<List<NoteV2>>();
		hardMedRiffs = new List<List<NoteV2>>();
		hardHardRiffs = new List<List<NoteV2>>();
		bossEasyTracks = new List<List<NoteV2>>();
		bossMediumTracks = new List<List<NoteV2>>();
		bossHardTracks = new List<List<NoteV2>>();
		SetOffsets();
		AddRiffs();
	}
	
	
	private void Start() {
		gameManagerScript = gameManager.GetComponent<GameManager>();
		audioManagerScript = audioManager.GetComponent<AudioManager>();
		player = GameObject.FindWithTag("Player");
		enemyDetection = player.GetComponent<EnemyDetection>();
		gameDifficulty = gameManagerScript.GetDifficulty();
	}
	
	
	private void SetOffsets() {
		offsetEasy01 = -0.9f;
		offsetEasy02 = -0.9f;
		offsetEasy03 = -0.9f;
		offsetMed01 = -0.9f;
		offsetMed02 = -0.9f;
		offsetMed03 = -0.9f;
		offsetMed04 = -0.9f;
		offsetHard01 = -0.9f;
		offsetHard02 = -0.9f;
		offsetHard03 = -0.9f;
		offsetHard04 = -0.9f;
		offsetHard05 = -0.9f;
		offsetBT1 = -0.9f;
	}
	
	
	// Insert all the notes for all the riffs we have.
	private void AddRiffs() {
		AddGuitarARiffEasy01Easy();
		AddGuitarARiffEasy01Med();
		AddGuitarARiffEasy01Hard();
		
		AddGuitarARiffEasy02Easy();
		AddGuitarARiffEasy02Med();
		AddGuitarARiffEasy02Hard();
		
		AddGuitarARiffEasy03Easy();
		AddGuitarARiffEasy03Med();
		AddGuitarARiffEasy03Hard();
		
		AddGuitarARiffMed01Easy();
		AddGuitarARiffMed01Med();
		AddGuitarARiffMed01Hard();
		
		AddGuitarARiffMed02Easy();
		AddGuitarARiffMed02Med();
		AddGuitarARiffMed02Hard();
		
		AddGuitarARiffMed03Easy();
		AddGuitarARiffMed03Med();
		AddGuitarARiffMed03Hard();
		
		AddGuitarARiffMed04Easy();
		AddGuitarARiffMed04Med();
		AddGuitarARiffMed04Hard();
		
		AddGuitarARiffHard01Easy();
		AddGuitarARiffHard01Med();
		AddGuitarARiffHard01Hard();
		
		AddGuitarARiffHard02Easy();
		AddGuitarARiffHard02Med();
		AddGuitarARiffHard02Hard();
		
		AddGuitarARiffHard03Easy();
		AddGuitarARiffHard03Med();
		AddGuitarARiffHard03Hard();
		
		AddGuitarARiffHard04Easy();
		AddGuitarARiffHard04Med();
		AddGuitarARiffHard04Hard();
		
		AddGuitarARiffHard05Easy();
		AddGuitarARiffHard05Med();
		AddGuitarARiffHard05Hard();
		
		AddBossTheme1Easy();
		AddBossTheme1Medium();
		AddBossTheme1Hard();
	}
	
	
	private void AddGuitarARiffEasy01Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy01, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetEasy01, true));
		riff.Add(new NoteV2(1, 4.0f + offsetEasy01, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetEasy01, true));
		 riff.Add(new NoteV2(2, 6.0f + offsetEasy01, true));
		// riff.Add(new NoteV2(1, 7.75f + offsetEasy01, true));
		riff.Add(new NoteV2(0, 8.0f + offsetEasy01, true));
		easyEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy01Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy01, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetEasy01, true));
		riff.Add(new NoteV2(1, 4.0f + offsetEasy01, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetEasy01, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy01, true));
		// riff.Add(new NoteV2(1, 7.75f + offsetEasy01, true));
		riff.Add(new NoteV2(0, 8.0f + offsetEasy01, true));
		easyMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy01Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy01, true));
		riff.Add(new NoteV2(0, 3.75f + offsetEasy01, true));
		riff.Add(new NoteV2(1, 4.0f + offsetEasy01, true));
		riff.Add(new NoteV2(1, 5.75f + offsetEasy01, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy01, true));
		riff.Add(new NoteV2(1, 7.75f + offsetEasy01, true));
		riff.Add(new NoteV2(0, 8.0f + offsetEasy01, true));
		easyHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy02Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy02, true));
		// riff.Add(new NoteV2(1, 3.5f + offsetEasy02, true));
		// riff.Add(new NoteV2(1, 5.5f + offsetEasy02, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy02, true));
		// riff.Add(new NoteV2(1, 7.5f + offsetEasy02, true));
		riff.Add(new NoteV2(0, 8.0f + offsetEasy02, true));
		easyEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy02Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy02, true));
		riff.Add(new NoteV2(1, 3.5f + offsetEasy02, true));
		riff.Add(new NoteV2(1, 5.5f + offsetEasy02, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy02, true));
		riff.Add(new NoteV2(1, 7.5f + offsetEasy02, true));
		riff.Add(new NoteV2(0, 8.0f + offsetEasy02, true));
		easyMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy02Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy02, true));
		riff.Add(new NoteV2(1, 3.5f + offsetEasy02, true));
		riff.Add(new NoteV2(1, 5.5f + offsetEasy02, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy02, true));
		riff.Add(new NoteV2(1, 7.5f + offsetEasy02, true));
		riff.Add(new NoteV2(0, 8.0f + offsetEasy02, true));
		easyHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy03Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 3.0f + offsetEasy03, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 4.0f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 5.0f + offsetEasy03, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 7.0f + offsetEasy03, true));
		// riff.Add(new NoteV2(2, 7.75f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 8.0f + offsetEasy03, true));
		easyEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy03Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 3.0f + offsetEasy03, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 4.0f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 5.0f + offsetEasy03, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 7.0f + offsetEasy03, true));
		// riff.Add(new NoteV2(2, 7.75f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 8.0f + offsetEasy03, true));
		easyMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffEasy03Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 3.0f + offsetEasy03, true));
		riff.Add(new NoteV2(0, 3.75f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 4.0f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 5.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 5.75f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 7.0f + offsetEasy03, true));
		riff.Add(new NoteV2(2, 7.75f + offsetEasy03, true));
		riff.Add(new NoteV2(1, 8.0f + offsetEasy03, true));
		easyHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed01Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 2.25f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 2.5f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 2.75f + offsetMed01, true));
		riff.Add(new NoteV2(2, 3.0f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 3.125f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 3.25f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 3.375f + offsetMed01, true));
		riff.Add(new NoteV2(0, 3.5f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 3.625f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 4.25f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 4.5f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 5.5f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.0f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 6.25f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 6.5f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 6.75f + offsetMed01, true));
		riff.Add(new NoteV2(0, 7.0f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 7.125f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 7.25f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 7.375f + offsetMed01, true));
		riff.Add(new NoteV2(1, 7.5f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 7.625f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 8.25f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 8.5f + offsetMed01, true));
		medEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed01Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 2.25f + offsetMed01, true));
		riff.Add(new NoteV2(2, 2.5f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 2.75f + offsetMed01, true));
		riff.Add(new NoteV2(2, 3.0f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 3.125f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 3.25f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 3.375f + offsetMed01, true));
		riff.Add(new NoteV2(0, 3.5f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 3.625f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 4.25f + offsetMed01, true));
		riff.Add(new NoteV2(2, 4.5f + offsetMed01, true));
		riff.Add(new NoteV2(1, 5.5f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.0f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 6.25f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.5f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 6.75f + offsetMed01, true));
		riff.Add(new NoteV2(0, 7.0f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 7.125f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 7.25f + offsetMed01, true));
		// riff.Add(new NoteV2(2, 7.375f + offsetMed01, true));
		riff.Add(new NoteV2(1, 7.5f + offsetMed01, true));
		// riff.Add(new NoteV2(1, 7.625f + offsetMed01, true));
		// riff.Add(new NoteV2(0, 8.25f + offsetMed01, true));
		riff.Add(new NoteV2(0, 8.5f + offsetMed01, true));
		medMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed01Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed01, true));
		riff.Add(new NoteV2(2, 2.25f + offsetMed01, true));
		riff.Add(new NoteV2(2, 2.5f + offsetMed01, true));
		riff.Add(new NoteV2(2, 2.75f + offsetMed01, true));
		riff.Add(new NoteV2(2, 3.0f + offsetMed01, true));
		riff.Add(new NoteV2(2, 3.125f + offsetMed01, true));
		riff.Add(new NoteV2(1, 3.25f + offsetMed01, true));
		riff.Add(new NoteV2(1, 3.375f + offsetMed01, true));
		riff.Add(new NoteV2(0, 3.5f + offsetMed01, true));
		riff.Add(new NoteV2(0, 3.625f + offsetMed01, true));
		riff.Add(new NoteV2(2, 4.25f + offsetMed01, true));
		riff.Add(new NoteV2(2, 4.5f + offsetMed01, true));
		riff.Add(new NoteV2(1, 5.5f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.0f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.25f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.5f + offsetMed01, true));
		riff.Add(new NoteV2(0, 6.75f + offsetMed01, true));
		riff.Add(new NoteV2(0, 7.0f + offsetMed01, true));
		riff.Add(new NoteV2(0, 7.125f + offsetMed01, true));
		riff.Add(new NoteV2(2, 7.25f + offsetMed01, true));
		riff.Add(new NoteV2(2, 7.375f + offsetMed01, true));
		riff.Add(new NoteV2(1, 7.5f + offsetMed01, true));
		riff.Add(new NoteV2(1, 7.625f + offsetMed01, true));
		riff.Add(new NoteV2(0, 8.25f + offsetMed01, true));
		riff.Add(new NoteV2(0, 8.5f + offsetMed01, true));
		medHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed02Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 2.25f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 2.5f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 2.875f + offsetMed02, true));
		riff.Add(new NoteV2(1, 3.0f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 3.25f + offsetMed02, true));
		riff.Add(new NoteV2(1, 6.0f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 6.125f + offsetMed02, true));
		// riff.Add(new NoteV2(2, 6.25f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 6.375f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 6.5f + offsetMed02, true));
		riff.Add(new NoteV2(0, 7.0f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 7.125f + offsetMed02, true));
		medEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed02Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 2.25f + offsetMed02, true));
		riff.Add(new NoteV2(0, 2.5f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetMed02, true));
		// riff.Add(new NoteV2(1, 2.875f + offsetMed02, true));
		riff.Add(new NoteV2(1, 3.0f + offsetMed02, true));
		riff.Add(new NoteV2(0, 3.25f + offsetMed02, true));
		riff.Add(new NoteV2(1, 6.0f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 6.125f + offsetMed02, true));
		riff.Add(new NoteV2(2, 6.25f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 6.375f + offsetMed02, true));
		riff.Add(new NoteV2(1, 6.5f + offsetMed02, true));
		riff.Add(new NoteV2(0, 7.0f + offsetMed02, true));
		// riff.Add(new NoteV2(0, 7.125f + offsetMed02, true));
		medMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed02Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed02, true));
		riff.Add(new NoteV2(1, 2.25f + offsetMed02, true));
		riff.Add(new NoteV2(0, 2.5f + offsetMed02, true));
		riff.Add(new NoteV2(1, 2.75f + offsetMed02, true));
		riff.Add(new NoteV2(1, 2.875f + offsetMed02, true));
		riff.Add(new NoteV2(1, 3.0f + offsetMed02, true));
		riff.Add(new NoteV2(0, 3.25f + offsetMed02, true));
		riff.Add(new NoteV2(1, 6.0f + offsetMed02, true));
		riff.Add(new NoteV2(0, 6.125f + offsetMed02, true));
		riff.Add(new NoteV2(2, 6.25f + offsetMed02, true));
		riff.Add(new NoteV2(0, 6.375f + offsetMed02, true));
		riff.Add(new NoteV2(1, 6.5f + offsetMed02, true));
		riff.Add(new NoteV2(0, 7.0f + offsetMed02, true));
		riff.Add(new NoteV2(0, 7.125f + offsetMed02, true));
		medHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed03Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 2.75f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.0f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 4.25f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 4.5f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 4.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.0f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 5.25f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 5.5f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetMed03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 6.75f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 7.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.0f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 8.25f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 8.5f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 8.75f + offsetMed03, true));
		riff.Add(new NoteV2(2, 9.0f + offsetMed03, true));
		// riff.Add(new NoteV2(2, 9.25f + offsetMed03, true));
		// riff.Add(new NoteV2(2, 9.5f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 9.75f + offsetMed03, true));
		medEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed03Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed03, true));
		riff.Add(new NoteV2(0, 2.75f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.0f + offsetMed03, true));
		//riff.Add(new NoteV2(0, 4.25f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.5f + offsetMed03, true));
		// riff.Add(new NoteV2(0, 4.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.0f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 5.25f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.5f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetMed03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetMed03, true));
		riff.Add(new NoteV2(0, 6.75f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 7.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.0f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 8.25f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.5f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 8.75f + offsetMed03, true));
		riff.Add(new NoteV2(2, 9.0f + offsetMed03, true));
		// riff.Add(new NoteV2(2, 9.25f + offsetMed03, true));
		riff.Add(new NoteV2(2, 9.5f + offsetMed03, true));
		// riff.Add(new NoteV2(1, 9.75f + offsetMed03, true));
		medMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed03Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetMed03, true));
		riff.Add(new NoteV2(0, 2.75f + offsetMed03, true));
		riff.Add(new NoteV2(0, 3.75f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.0f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.25f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.5f + offsetMed03, true));
		riff.Add(new NoteV2(0, 4.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.0f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.25f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.5f + offsetMed03, true));
		riff.Add(new NoteV2(1, 5.75f + offsetMed03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetMed03, true));
		riff.Add(new NoteV2(0, 6.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 7.75f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.0f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.25f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.5f + offsetMed03, true));
		riff.Add(new NoteV2(1, 8.75f + offsetMed03, true));
		riff.Add(new NoteV2(2, 9.0f + offsetMed03, true));
		riff.Add(new NoteV2(2, 9.25f + offsetMed03, true));
		riff.Add(new NoteV2(2, 9.5f + offsetMed03, true));
		riff.Add(new NoteV2(1, 9.75f + offsetMed03, true));
		medHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed04Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(1, 2.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 2.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 2.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 3.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 4.25f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 4.25f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 4.5f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 4.5f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 4.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 4.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.0f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 5.25f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 5.25f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 5.5f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 5.5f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 5.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 6.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 6.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 6.75f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 6.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 8.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 8.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 8.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 8.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 9.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 9.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 9.25f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 9.25f + offsetMed04, true));
		medEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed04Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(1, 2.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 2.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 2.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 3.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 3.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 4.25f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 4.25f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.5f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.5f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 4.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 4.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.0f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 5.25f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 5.25f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.5f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.5f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 5.75f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 5.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 6.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 6.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 6.75f + offsetMed04, true));
		// riff.Add(new NoteV2(2, 6.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 8.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 8.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 8.75f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 8.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 9.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 9.0f + offsetMed04, true));
		// riff.Add(new NoteV2(0, 9.25f + offsetMed04, true));
		// riff.Add(new NoteV2(1, 9.25f + offsetMed04, true));
		medMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffMed04Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(1, 2.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 2.0f + offsetMed04, true));
		riff.Add(new NoteV2(0, 2.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 2.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 3.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 3.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.0f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.25f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.25f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.5f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.5f + offsetMed04, true));
		riff.Add(new NoteV2(0, 4.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 4.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.25f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.25f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.5f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.5f + offsetMed04, true));
		riff.Add(new NoteV2(1, 5.75f + offsetMed04, true));
		riff.Add(new NoteV2(2, 5.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 6.0f + offsetMed04, true));
		riff.Add(new NoteV2(2, 6.0f + offsetMed04, true));
		riff.Add(new NoteV2(0, 6.75f + offsetMed04, true));
		riff.Add(new NoteV2(2, 6.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 8.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 8.0f + offsetMed04, true));
		riff.Add(new NoteV2(0, 8.75f + offsetMed04, true));
		riff.Add(new NoteV2(1, 8.75f + offsetMed04, true));
		riff.Add(new NoteV2(0, 9.0f + offsetMed04, true));
		riff.Add(new NoteV2(1, 9.0f + offsetMed04, true));
		riff.Add(new NoteV2(0, 9.25f + offsetMed04, true));
		riff.Add(new NoteV2(1, 9.25f + offsetMed04, true));
		medHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard01Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		// riff.Add(new NoteV2(0, 1.25f + offsetHard01, true));
		// riff.Add(new NoteV2(1, 1.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 1.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 1.5f + offsetHard01, true));
		// riff.Add(new NoteV2(0, 2.25f + offsetHard01, true));
		// riff.Add(new NoteV2(1, 2.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard01, true));
		// riff.Add(new NoteV2(0, 3.25f + offsetHard01, true));
		// riff.Add(new NoteV2(2, 3.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 3.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard01, true));
		// riff.Add(new NoteV2(1, 4.25f + offsetHard01, true));
		// riff.Add(new NoteV2(2, 4.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 4.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 4.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 5.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 5.5f + offsetHard01, true));
		riff.Add(new NoteV2(3, 6.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 6.5f + offsetHard01, true));
		hardEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard01Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 1.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 1.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 1.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 1.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 2.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 2.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 3.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 3.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 3.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 4.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 4.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 4.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 4.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 5.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 5.5f + offsetHard01, true));
		riff.Add(new NoteV2(3, 6.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 6.5f + offsetHard01, true));
		hardMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard01Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 1.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 1.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 1.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 1.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 2.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 2.25f + offsetHard01, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 3.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 3.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 3.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 4.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 4.25f + offsetHard01, true));
		riff.Add(new NoteV2(2, 4.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 4.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 5.5f + offsetHard01, true));
		riff.Add(new NoteV2(0, 5.5f + offsetHard01, true));
		riff.Add(new NoteV2(3, 6.5f + offsetHard01, true));
		riff.Add(new NoteV2(1, 6.5f + offsetHard01, true));
		hardHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard02Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(1, 2.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.0f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 2.251f + offsetHard02, true));
		// riff.Add(new NoteV2(0, 2.251f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetHard02, true));
		// riff.Add(new NoteV2(0, 2.75f + offsetHard02, true));
		riff.Add(new NoteV2(2, 3.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 3.0f + offsetHard02, true));
		// riff.Add(new NoteV2(2, 3.5f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 3.5f + offsetHard02, true));
		// riff.Add(new NoteV2(2, 3.625f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 3.625f + offsetHard02, true));
		riff.Add(new NoteV2(2, 4.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 4.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.0f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 6.251f + offsetHard02, true));
		// riff.Add(new NoteV2(0, 6.251f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 6.75f + offsetHard02, true));
		// riff.Add(new NoteV2(0, 6.75f + offsetHard02, true));
		riff.Add(new NoteV2(2, 7.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard02, true));
		// riff.Add(new NoteV2(2, 7.5f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 7.5f + offsetHard02, true));
		// riff.Add(new NoteV2(2, 7.625f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 7.625f + offsetHard02, true));
		riff.Add(new NoteV2(3, 8.0f + offsetHard02, true));
		// riff.Add(new NoteV2(3, 8.25f + offsetHard02, true));
		hardEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard02Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(1, 2.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 2.251f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.251f + offsetHard02, true));
		riff.Add(new NoteV2(1, 2.75f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.75f + offsetHard02, true));
		riff.Add(new NoteV2(2, 3.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 3.0f + offsetHard02, true));
		riff.Add(new NoteV2(2, 3.5f + offsetHard02, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard02, true));
		// riff.Add(new NoteV2(2, 3.625f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 3.625f + offsetHard02, true));
		riff.Add(new NoteV2(2, 4.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 4.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.251f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.251f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.75f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.75f + offsetHard02, true));
		riff.Add(new NoteV2(2, 7.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard02, true));
		riff.Add(new NoteV2(2, 7.5f + offsetHard02, true));
		riff.Add(new NoteV2(1, 7.5f + offsetHard02, true));
		// riff.Add(new NoteV2(2, 7.625f + offsetHard02, true));
		// riff.Add(new NoteV2(1, 7.625f + offsetHard02, true));
		riff.Add(new NoteV2(3, 8.0f + offsetHard02, true));
		riff.Add(new NoteV2(3, 8.25f + offsetHard02, true));
		hardMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard02Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(1, 2.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 2.251f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.251f + offsetHard02, true));
		riff.Add(new NoteV2(1, 2.75f + offsetHard02, true));
		riff.Add(new NoteV2(0, 2.75f + offsetHard02, true));
		riff.Add(new NoteV2(2, 3.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 3.0f + offsetHard02, true));
		riff.Add(new NoteV2(2, 3.5f + offsetHard02, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard02, true));
		riff.Add(new NoteV2(2, 3.625f + offsetHard02, true));
		riff.Add(new NoteV2(1, 3.625f + offsetHard02, true));
		riff.Add(new NoteV2(2, 4.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 4.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.0f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.251f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.251f + offsetHard02, true));
		riff.Add(new NoteV2(1, 6.75f + offsetHard02, true));
		riff.Add(new NoteV2(0, 6.75f + offsetHard02, true));
		riff.Add(new NoteV2(2, 7.0f + offsetHard02, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard02, true));
		riff.Add(new NoteV2(2, 7.5f + offsetHard02, true));
		riff.Add(new NoteV2(1, 7.5f + offsetHard02, true));
		riff.Add(new NoteV2(2, 7.625f + offsetHard02, true));
		riff.Add(new NoteV2(1, 7.625f + offsetHard02, true));
		riff.Add(new NoteV2(3, 8.0f + offsetHard02, true));
		riff.Add(new NoteV2(3, 8.25f + offsetHard02, true));
		hardHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard03Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(3, 2.0f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 2.25f + offsetHard03, true));
		// riff.Add(new NoteV2(1, 2.5f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 2.75f + offsetHard03, true));
		riff.Add(new NoteV2(1, 3.0f + offsetHard03, true));
		// riff.Add(new NoteV2(0, 3.25f + offsetHard03, true));
		// riff.Add(new NoteV2(1, 3.5f + offsetHard03, true));
		// riff.Add(new NoteV2(0, 3.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 5.0f + offsetHard03, true));
		riff.Add(new NoteV2(1, 5.0f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 5.5f + offsetHard03, true));
		// riff.Add(new NoteV2(1, 5.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetHard03, true));
		// riff.Add(new NoteV2(1, 6.25f + offsetHard03, true));
		// riff.Add(new NoteV2(0, 6.5f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 6.75f + offsetHard03, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 7.25f + offsetHard03, true));
		// riff.Add(new NoteV2(3, 7.5f + offsetHard03, true));
		// riff.Add(new NoteV2(1, 7.5f + offsetHard03, true));
		hardEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard03Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(3, 2.0f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 2.25f + offsetHard03, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 2.75f + offsetHard03, true));
		riff.Add(new NoteV2(1, 3.0f + offsetHard03, true));
		// riff.Add(new NoteV2(0, 3.25f + offsetHard03, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard03, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 5.0f + offsetHard03, true));
		riff.Add(new NoteV2(1, 5.0f + offsetHard03, true));
		riff.Add(new NoteV2(2, 5.5f + offsetHard03, true));
		riff.Add(new NoteV2(1, 5.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetHard03, true));
		// riff.Add(new NoteV2(1, 6.25f + offsetHard03, true));
		riff.Add(new NoteV2(0, 6.5f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 6.75f + offsetHard03, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard03, true));
		// riff.Add(new NoteV2(2, 7.25f + offsetHard03, true));
		riff.Add(new NoteV2(3, 7.5f + offsetHard03, true));
		riff.Add(new NoteV2(1, 7.5f + offsetHard03, true));
		hardMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard03Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(3, 2.0f + offsetHard03, true));
		riff.Add(new NoteV2(2, 2.25f + offsetHard03, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 2.75f + offsetHard03, true));
		riff.Add(new NoteV2(1, 3.0f + offsetHard03, true));
		riff.Add(new NoteV2(0, 3.25f + offsetHard03, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard03, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 5.0f + offsetHard03, true));
		riff.Add(new NoteV2(1, 5.0f + offsetHard03, true));
		riff.Add(new NoteV2(2, 5.5f + offsetHard03, true));
		riff.Add(new NoteV2(1, 5.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 6.0f + offsetHard03, true));
		riff.Add(new NoteV2(1, 6.25f + offsetHard03, true));
		riff.Add(new NoteV2(0, 6.5f + offsetHard03, true));
		riff.Add(new NoteV2(2, 6.75f + offsetHard03, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard03, true));
		riff.Add(new NoteV2(2, 7.25f + offsetHard03, true));
		riff.Add(new NoteV2(3, 7.5f + offsetHard03, true));
		riff.Add(new NoteV2(1, 7.5f + offsetHard03, true));
		hardHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard04Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetHard04, true));
		riff.Add(new NoteV2(3, 2.0f + offsetHard04, true));
		// riff.Add(new NoteV2(0, 2.25f + offsetHard04, true));
		// riff.Add(new NoteV2(2, 2.25f + offsetHard04, true));
		// riff.Add(new NoteV2(1, 2.5f + offsetHard04, true));
		// riff.Add(new NoteV2(0, 2.5f + offsetHard04, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 4.5f + offsetHard04, true));
		riff.Add(new NoteV2(3, 4.5f + offsetHard04, true));
		// riff.Add(new NoteV2(0, 4.75f + offsetHard04, true));
		// riff.Add(new NoteV2(2, 4.75f + offsetHard04, true));
		// riff.Add(new NoteV2(3, 5.0f + offsetHard04, true));
		// riff.Add(new NoteV2(3, 5.25f + offsetHard04, true));
		riff.Add(new NoteV2(3, 5.5f + offsetHard04, true));
		riff.Add(new NoteV2(2, 5.5f + offsetHard04, true));
		hardEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard04Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetHard04, true));
		riff.Add(new NoteV2(3, 2.0f + offsetHard04, true));
		// riff.Add(new NoteV2(0, 2.25f + offsetHard04, true));
		// riff.Add(new NoteV2(2, 2.25f + offsetHard04, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard04, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 4.5f + offsetHard04, true));
		riff.Add(new NoteV2(3, 4.5f + offsetHard04, true));
		// riff.Add(new NoteV2(0, 4.75f + offsetHard04, true));
		// riff.Add(new NoteV2(2, 4.75f + offsetHard04, true));
		riff.Add(new NoteV2(3, 5.0f + offsetHard04, true));
		// riff.Add(new NoteV2(3, 5.25f + offsetHard04, true));
		riff.Add(new NoteV2(3, 5.5f + offsetHard04, true));
		riff.Add(new NoteV2(2, 5.5f + offsetHard04, true));
		hardMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard04Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(0, 2.0f + offsetHard04, true));
		riff.Add(new NoteV2(3, 2.0f + offsetHard04, true));
		riff.Add(new NoteV2(0, 2.25f + offsetHard04, true));
		riff.Add(new NoteV2(2, 2.25f + offsetHard04, true));
		riff.Add(new NoteV2(1, 2.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard04, true));
		riff.Add(new NoteV2(1, 3.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 3.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 4.5f + offsetHard04, true));
		riff.Add(new NoteV2(3, 4.5f + offsetHard04, true));
		riff.Add(new NoteV2(0, 4.75f + offsetHard04, true));
		riff.Add(new NoteV2(2, 4.75f + offsetHard04, true));
		riff.Add(new NoteV2(3, 5.0f + offsetHard04, true));
		riff.Add(new NoteV2(3, 5.25f + offsetHard04, true));
		riff.Add(new NoteV2(3, 5.5f + offsetHard04, true));
		riff.Add(new NoteV2(2, 5.5f + offsetHard04, true));
		hardHardRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard05Easy() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 2.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 2.5f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 2.5f + offsetHard05, true));
		// riff.Add(new NoteV2(3, 2.75f + offsetHard05, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 4.125f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 4.125f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 4.375f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 4.375f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 4.5f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 4.5f + offsetHard05, true));
		// riff.Add(new NoteV2(3, 4.75f + offsetHard05, true));
		// riff.Add(new NoteV2(1, 4.75f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 6.125f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 6.125f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 6.375f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 6.375f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 6.5f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 6.5f + offsetHard05, true));
		// riff.Add(new NoteV2(3, 6.75f + offsetHard05, true));
		// riff.Add(new NoteV2(1, 6.75f + offsetHard05, true));
		riff.Add(new NoteV2(3, 7.0f + offsetHard05, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 7.25f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 7.25f + offsetHard05, true));
		hardEasyRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard05Med() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 2.0f + offsetHard05, true));
		riff.Add(new NoteV2(2, 2.5f + offsetHard05, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard05, true));
		// riff.Add(new NoteV2(3, 2.75f + offsetHard05, true));
		// riff.Add(new NoteV2(1, 2.75f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 4.125f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 4.125f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 4.375f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 4.375f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.5f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.5f + offsetHard05, true));
		// riff.Add(new NoteV2(3, 4.75f + offsetHard05, true));
		// riff.Add(new NoteV2(1, 4.75f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 6.125f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 6.125f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 6.375f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 6.375f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.5f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.5f + offsetHard05, true));
		// riff.Add(new NoteV2(3, 6.75f + offsetHard05, true));
		// riff.Add(new NoteV2(1, 6.75f + offsetHard05, true));
		riff.Add(new NoteV2(3, 7.0f + offsetHard05, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard05, true));
		// riff.Add(new NoteV2(2, 7.25f + offsetHard05, true));
		// riff.Add(new NoteV2(0, 7.25f + offsetHard05, true));
		hardMedRiffs.Add(riff);
	}
	
	
	private void AddGuitarARiffHard05Hard() {
		List<NoteV2> riff = new List<NoteV2>();
		riff.Add(new NoteV2(2, 2.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 2.0f + offsetHard05, true));
		riff.Add(new NoteV2(2, 2.5f + offsetHard05, true));
		riff.Add(new NoteV2(0, 2.5f + offsetHard05, true));
		riff.Add(new NoteV2(3, 2.75f + offsetHard05, true));
		riff.Add(new NoteV2(1, 2.75f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.0f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.125f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.125f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.375f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.375f + offsetHard05, true));
		riff.Add(new NoteV2(2, 4.5f + offsetHard05, true));
		riff.Add(new NoteV2(0, 4.5f + offsetHard05, true));
		riff.Add(new NoteV2(3, 4.75f + offsetHard05, true));
		riff.Add(new NoteV2(1, 4.75f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.0f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.0f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.125f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.125f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.375f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.375f + offsetHard05, true));
		riff.Add(new NoteV2(2, 6.5f + offsetHard05, true));
		riff.Add(new NoteV2(0, 6.5f + offsetHard05, true));
		riff.Add(new NoteV2(3, 6.75f + offsetHard05, true));
		riff.Add(new NoteV2(1, 6.75f + offsetHard05, true));
		riff.Add(new NoteV2(3, 7.0f + offsetHard05, true));
		riff.Add(new NoteV2(1, 7.0f + offsetHard05, true));
		riff.Add(new NoteV2(2, 7.25f + offsetHard05, true));
		riff.Add(new NoteV2(0, 7.25f + offsetHard05, true));
		hardHardRiffs.Add(riff);
	}
	
	
	private void AddBossTheme1Easy() {
		List<NoteV2> track = new List<NoteV2>();
		// Single 1
		track.Add(new NoteV2(2, 6.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 7.301f + offsetBT1, true));
		// track.Add(new NoteV2(2, 7.401f + offsetBT1, true));
		track.Add(new NoteV2(3, 7.508f + offsetBT1, true));
		// track.Add(new NoteV2(2, 8.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 8.227f + offsetBT1, true));
		track.Add(new NoteV2(2, 8.335f + offsetBT1, true));
		track.Add(new NoteV2(0, 8.762f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 10.001f + offsetBT1, true));
		// track.Add(new NoteV2(3, 10.634f + offsetBT1, true));
		// track.Add(new NoteV2(4, 10.735f + offsetBT1, true));
		track.Add(new NoteV2(2, 10.842f + offsetBT1, true));
		// track.Add(new NoteV2(1, 11.460f + offsetBT1, true));
		// track.Add(new NoteV2(2, 11.561f + offsetBT1, true));
		track.Add(new NoteV2(1, 11.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 12.508f + offsetBT1, true));
		// track.Add(new NoteV2(1, 12.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 13.335f + offsetBT1, true));
		// track.Add(new NoteV2(2, 13.762f + offsetBT1, true));
		track.Add(new NoteV2(1, 14.175f + offsetBT1, true));
		// track.Add(new NoteV2(2, 14.588f + offsetBT1, true));
		track.Add(new NoteV2(0, 15.001f + offsetBT1, true, true));
		
		// Gap 1 (Soundwave)
		track.Add(new NoteV2(1, 20.001f + offsetBT1, true));
		// track.Add(new NoteV2(0, 20.120f + offsetBT1, true));
		// track.Add(new NoteV2(1, 20.323f + offsetBT1, true));
		// track.Add(new NoteV2(0, 20.428f + offsetBT1, true));
		// track.Add(new NoteV2(3, 20.634f + offsetBT1, true));
		track.Add(new NoteV2(1, 20.842f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 21.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 21.787f + offsetBT1, true));
		// track.Add(new NoteV2(2, 21.990f + offsetBT1, true));
		// track.Add(new NoteV2(1, 22.095f + offsetBT1, true));
		// track.Add(new NoteV2(3, 22.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 22.508f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 23.335f + offsetBT1, true));
		track.Add(new NoteV2(4, 24.175f + offsetBT1, true));
		// track.Add(new NoteV2(2, 24.588f + offsetBT1, true));
		track.Add(new NoteV2(3, 25.428f + offsetBT1, true));
		// track.Add(new NoteV2(4, 25.634f + offsetBT1, true));
		// track.Add(new NoteV2(2, 25.735f + offsetBT1, true));
		track.Add(new NoteV2(1, 26.254f + offsetBT1, true));
		// track.Add(new NoteV2(0, 26.460f + offsetBT1, true));
		// track.Add(new NoteV2(1, 26.561f + offsetBT1, true));
		track.Add(new NoteV2(0, 26.668f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 28.335f + offsetBT1, true));
		// track.Add(new NoteV2(3, 28.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 30.428f + offsetBT1, true));
		track.Add(new NoteV2(3, 30.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 31.254f + offsetBT1, true));
		track.Add(new NoteV2(1, 31.668f + offsetBT1, true));
		// track.Add(new NoteV2(0, 32.301f + offsetBT1, true, true));
		
		// Gap 2 (Soundwave)
		track.Add(new NoteV2(2, 40.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 40.634f + offsetBT1, true));
		// track.Add(new NoteV2(2, 40.735f + offsetBT1, true));
		track.Add(new NoteV2(3, 40.842f + offsetBT1, true));
		// track.Add(new NoteV2(2, 41.460f + offsetBT1, true));
		// track.Add(new NoteV2(1, 41.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 41.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 42.095f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 43.335f + offsetBT1, true));
		// track.Add(new NoteV2(3, 43.967f + offsetBT1, true));
		// track.Add(new NoteV2(4, 44.068f + offsetBT1, true));
		track.Add(new NoteV2(2, 44.175f + offsetBT1, true));
		// track.Add(new NoteV2(1, 44.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 44.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 45.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 45.842f + offsetBT1, true));
		// track.Add(new NoteV2(1, 46.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 46.668f + offsetBT1, true));
		// track.Add(new NoteV2(2, 47.095f + offsetBT1, true));
		track.Add(new NoteV2(1, 47.508f + offsetBT1, true));
		// track.Add(new NoteV2(2, 47.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 48.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 50.001f + offsetBT1, true));
		// track.Add(new NoteV2(2, 50.120f + offsetBT1, true));
		// track.Add(new NoteV2(2, 51.460f + offsetBT1, true));
		// track.Add(new NoteV2(2, 51.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.668f + offsetBT1, true));
		// track.Add(new NoteV2(2, 51.787f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 53.335f + offsetBT1, true));
		// track.Add(new NoteV2(2, 53.454f + offsetBT1, true));
		// track.Add(new NoteV2(2, 54.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 54.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 55.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 55.120f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 56.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 58.787f + offsetBT1, true));
		// track.Add(new NoteV2(1, 58.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 58.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 58.335f + offsetBT1, true));
		// track.Add(new NoteV2(0, 58.454f + offsetBT1, true, true));
		// track.Add(new NoteV2(0, 59.175f + offsetBT1, true));
		// track.Add(new NoteV2(0, 59.282f + offsetBT1, true));
		
		// Chords 1
		track.Add(new NoteV2(0, 60.001f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 60.001f + offsetBT1, true));
		// track.Add(new NoteV2(2, 60.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 61.254f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 61.254f + offsetBT1, true));
		// track.Add(new NoteV2(2, 61.254f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 61.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 61.668f + offsetBT1, true));
		// track.Add(new NoteV2(3, 61.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 62.921f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 62.921f + offsetBT1, true));
		// track.Add(new NoteV2(3, 62.921f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.335f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 63.454f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 63.454f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 63.555f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 63.555f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 63.762f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 63.762f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 64.175f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 64.175f + offsetBT1, true));
		// track.Add(new NoteV2(2, 64.175f + offsetBT1, true));
		// track.Add(new NoteV2(3, 64.175f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 65.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 65.001f + offsetBT1, true));
		// track.Add(new NoteV2(3, 65.001f + offsetBT1, true));
		
		// Single 2
		track.Add(new NoteV2(1, 66.668f + offsetBT1, true));
		// track.Add(new NoteV2(0, 66.787f + offsetBT1, true));
		// track.Add(new NoteV2(1, 66.990f + offsetBT1, true));
		// track.Add(new NoteV2(0, 67.095f + offsetBT1, true));
		// track.Add(new NoteV2(2, 67.301f + offsetBT1, true));
		track.Add(new NoteV2(1, 67.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 68.335f + offsetBT1, true));
		// track.Add(new NoteV2(1, 68.454f + offsetBT1, true));
		// track.Add(new NoteV2(2, 68.656f + offsetBT1, true));
		// track.Add(new NoteV2(1, 68.762f + offsetBT1, true));
		// track.Add(new NoteV2(3, 68.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 69.175f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 70.001f + offsetBT1, true));
		track.Add(new NoteV2(4, 70.842f + offsetBT1, true));
		// track.Add(new NoteV2(2, 71.254f + offsetBT1, true));
		track.Add(new NoteV2(3, 72.095f + offsetBT1, true));
		// track.Add(new NoteV2(4, 72.301f + offsetBT1, true));
		// track.Add(new NoteV2(2, 72.401f + offsetBT1, true));
		track.Add(new NoteV2(1, 72.921f + offsetBT1, true));
		// track.Add(new NoteV2(0, 73.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 73.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 73.335f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 75.001f + offsetBT1, true));
		// track.Add(new NoteV2(3, 75.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 77.095f + offsetBT1, true));
		track.Add(new NoteV2(3, 77.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 77.921f + offsetBT1, true));
		track.Add(new NoteV2(1, 78.335f + offsetBT1, true));
		// track.Add(new NoteV2(2, 78.967f + offsetBT1, true, true));
		
		// Chords 2
		track.Add(new NoteV2(1, 80.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 80.001f + offsetBT1, true));
	
		track.Add(new NoteV2(1, 81.668f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 81.668f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 83.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 83.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.001f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 85.323f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 85.323f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 85.634f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 85.634f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 85.842f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.842f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 86.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 86.668f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 88.335f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 88.335f + offsetBT1, true));
		
		track.Add(new NoteV2(2, 90.001f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 90.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 91.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 91.668f + offsetBT1, true));
		
		// track.Add(new NoteV2(0, 91.990f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 91.990f + offsetBT1, true));
		
		// track.Add(new NoteV2(0, 92.301f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 92.301f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.508f + offsetBT1, true));
		
		// track.Add(new NoteV2(0, 92.816f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 92.816f + offsetBT1, true));
		
		// track.Add(new NoteV2(0, 93.127f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 93.127f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.335f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.335f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 93.656f + offsetBT1, true, true));
		// track.Add(new NoteV2(3, 93.656f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 93.967f + offsetBT1, true, true));
		// track.Add(new NoteV2(3, 93.967f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.175f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.175f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 94.483f + offsetBT1, true, true));
		// track.Add(new NoteV2(3, 94.483f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 94.793f + offsetBT1, true, true));
		// track.Add(new NoteV2(3, 94.793f + offsetBT1, true));
		
		// Single 3
		track.Add(new NoteV2(2, 95.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 95.634f + offsetBT1, true));
		// track.Add(new NoteV2(2, 95.735f + offsetBT1, true));
		track.Add(new NoteV2(3, 95.842f + offsetBT1, true));
		// track.Add(new NoteV2(2, 96.460f + offsetBT1, true));
		// track.Add(new NoteV2(1, 96.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 96.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 97.095f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 98.335f + offsetBT1, true));
		// track.Add(new NoteV2(3, 98.967f + offsetBT1, true));
		// track.Add(new NoteV2(4, 99.068f + offsetBT1, true));
		track.Add(new NoteV2(2, 99.175f + offsetBT1, true));
		// track.Add(new NoteV2(1, 99.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 99.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 100.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 100.842f + offsetBT1, true));
		// track.Add(new NoteV2(1, 101.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 101.668f + offsetBT1, true));
		// track.Add(new NoteV2(2, 102.095f + offsetBT1, true));
		track.Add(new NoteV2(1, 102.508f + offsetBT1, true));
		// track.Add(new NoteV2(2, 102.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 103.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 105.001f + offsetBT1, true));
		// track.Add(new NoteV2(2, 105.120f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 106.460f + offsetBT1, true));
		// track.Add(new NoteV2(2, 106.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 106.668f + offsetBT1, true));
		// track.Add(new NoteV2(2, 106.787f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 108.335f + offsetBT1, true));
		// track.Add(new NoteV2(2, 108.454f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 109.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 109.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 110.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 110.120f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 111.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 111.787f + offsetBT1, true, true));
		// track.Add(new NoteV2(1, 113.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 113.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 113.335f + offsetBT1, true));
		// track.Add(new NoteV2(0, 113.454f + offsetBT1, true, true));
		track.Add(new NoteV2(0, 114.175f + offsetBT1, true));
		// track.Add(new NoteV2(0, 114.282f + offsetBT1, true));
		
		// Chords 3
		track.Add(new NoteV2(0, 115.001f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 115.001f + offsetBT1, true));
		// track.Add(new NoteV2(2, 115.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 116.254f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 116.254f + offsetBT1, true));
		// track.Add(new NoteV2(2, 116.254f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 116.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 116.668f + offsetBT1, true));
		// track.Add(new NoteV2(3, 116.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 117.921f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 117.921f + offsetBT1, true));
		// track.Add(new NoteV2(3, 117.921f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.335f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 118.454f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 118.454f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 118.555f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 118.555f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 118.762f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 118.762f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 119.175f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 119.175f + offsetBT1, true));
		// track.Add(new NoteV2(2, 119.175f + offsetBT1, true));
		// track.Add(new NoteV2(3, 119.175f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 120.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 120.001f + offsetBT1, true));
		// track.Add(new NoteV2(3, 120.001f + offsetBT1, true));
		
		// Single 4
		track.Add(new NoteV2(1, 121.668f + offsetBT1, true));
		// track.Add(new NoteV2(0, 121.787f + offsetBT1, true));
		// track.Add(new NoteV2(1, 121.990f + offsetBT1, true));
		// track.Add(new NoteV2(0, 122.095f + offsetBT1, true));
		// track.Add(new NoteV2(2, 122.301f + offsetBT1, true));
		track.Add(new NoteV2(1, 122.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 123.335f + offsetBT1, true));
		// track.Add(new NoteV2(1, 123.454f + offsetBT1, true));
		// track.Add(new NoteV2(2, 123.656f + offsetBT1, true));
		// track.Add(new NoteV2(1, 123.762f + offsetBT1, true));
		// track.Add(new NoteV2(3, 123.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 124.175f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 125.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 125.842f + offsetBT1, true));
		// track.Add(new NoteV2(2, 126.254f + offsetBT1, true));
		track.Add(new NoteV2(3, 127.095f + offsetBT1, true));
		// track.Add(new NoteV2(4, 127.301f + offsetBT1, true));
		// track.Add(new NoteV2(2, 127.401f + offsetBT1, true));
		track.Add(new NoteV2(1, 127.921f + offsetBT1, true));
		// track.Add(new NoteV2(0, 128.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 128.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 128.335f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 130.001f + offsetBT1, true));
		// track.Add(new NoteV2(3, 130.634f + offsetBT1, true));
		
		// Chords 4
		track.Add(new NoteV2(1, 132.095f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 132.095f + offsetBT1, true));
		
		track.Add(new NoteV2(2, 132.508f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 132.508f + offsetBT1, true));
		
		// Single 5
		track.Add(new NoteV2(3, 132.921f + offsetBT1, true));
		track.Add(new NoteV2(4, 133.333f + offsetBT1, true, true));
		bossEasyTracks.Add(track);
	}
	
	
	private void AddBossTheme1Medium() {
		List<NoteV2> track = new List<NoteV2>();
		// Single 1
		track.Add(new NoteV2(2, 6.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 7.301f + offsetBT1, true));
		// track.Add(new NoteV2(2, 7.401f + offsetBT1, true));
		track.Add(new NoteV2(3, 7.508f + offsetBT1, true));
		// track.Add(new NoteV2(2, 8.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 8.227f + offsetBT1, true));
		track.Add(new NoteV2(2, 8.335f + offsetBT1, true));
		track.Add(new NoteV2(0, 8.762f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 10.001f + offsetBT1, true));
		// track.Add(new NoteV2(3, 10.634f + offsetBT1, true));
		// track.Add(new NoteV2(4, 10.735f + offsetBT1, true));
		track.Add(new NoteV2(2, 10.842f + offsetBT1, true));
		// track.Add(new NoteV2(1, 11.460f + offsetBT1, true));
		// track.Add(new NoteV2(2, 11.561f + offsetBT1, true));
		track.Add(new NoteV2(1, 11.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 12.508f + offsetBT1, true));
		track.Add(new NoteV2(1, 12.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 13.335f + offsetBT1, true));
		track.Add(new NoteV2(2, 13.762f + offsetBT1, true));
		track.Add(new NoteV2(1, 14.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 14.588f + offsetBT1, true));
		track.Add(new NoteV2(0, 15.001f + offsetBT1, true, true));
		
		// Gap 1 (Soundwave)
		track.Add(new NoteV2(1, 20.001f + offsetBT1, true));
		// track.Add(new NoteV2(0, 20.120f + offsetBT1, true));
		track.Add(new NoteV2(1, 20.323f + offsetBT1, true));
		// track.Add(new NoteV2(0, 20.428f + offsetBT1, true));
		track.Add(new NoteV2(3, 20.634f + offsetBT1, true));
		track.Add(new NoteV2(1, 20.842f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 21.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 21.787f + offsetBT1, true));
		track.Add(new NoteV2(2, 21.990f + offsetBT1, true));
		// track.Add(new NoteV2(1, 22.095f + offsetBT1, true));
		track.Add(new NoteV2(3, 22.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 22.508f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 23.335f + offsetBT1, true));
		track.Add(new NoteV2(4, 24.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 24.588f + offsetBT1, true));
		track.Add(new NoteV2(3, 25.428f + offsetBT1, true));
		// track.Add(new NoteV2(4, 25.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 25.735f + offsetBT1, true));
		track.Add(new NoteV2(1, 26.254f + offsetBT1, true));
		// track.Add(new NoteV2(0, 26.460f + offsetBT1, true));
		// track.Add(new NoteV2(1, 26.561f + offsetBT1, true));
		track.Add(new NoteV2(0, 26.668f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 28.335f + offsetBT1, true));
		track.Add(new NoteV2(3, 28.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 30.428f + offsetBT1, true));
		track.Add(new NoteV2(3, 30.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 31.254f + offsetBT1, true));
		track.Add(new NoteV2(1, 31.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 32.301f + offsetBT1, true, true));
		
		// Gap 2 (Soundwave)
		track.Add(new NoteV2(2, 40.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 40.634f + offsetBT1, true));
		// track.Add(new NoteV2(2, 40.735f + offsetBT1, true));
		track.Add(new NoteV2(3, 40.842f + offsetBT1, true));
		// track.Add(new NoteV2(2, 41.460f + offsetBT1, true));
		// track.Add(new NoteV2(1, 41.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 41.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 42.095f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 43.335f + offsetBT1, true));
		// track.Add(new NoteV2(3, 43.967f + offsetBT1, true));
		// track.Add(new NoteV2(4, 44.068f + offsetBT1, true));
		track.Add(new NoteV2(2, 44.175f + offsetBT1, true));
		// track.Add(new NoteV2(1, 44.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 44.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 45.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 45.842f + offsetBT1, true));
		track.Add(new NoteV2(1, 46.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 46.668f + offsetBT1, true));
		track.Add(new NoteV2(2, 47.095f + offsetBT1, true));
		track.Add(new NoteV2(1, 47.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 47.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 48.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 50.001f + offsetBT1, true));
		// track.Add(new NoteV2(2, 50.120f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.460f + offsetBT1, true));
		// track.Add(new NoteV2(2, 51.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.668f + offsetBT1, true));
		// track.Add(new NoteV2(2, 51.787f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 53.335f + offsetBT1, true));
		// track.Add(new NoteV2(2, 53.454f + offsetBT1, true));
		track.Add(new NoteV2(2, 54.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 54.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 55.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 55.120f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 56.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 58.787f + offsetBT1, true));
		track.Add(new NoteV2(1, 58.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 58.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 58.335f + offsetBT1, true));
		// track.Add(new NoteV2(0, 58.454f + offsetBT1, true, true));
		track.Add(new NoteV2(0, 59.175f + offsetBT1, true));
		// track.Add(new NoteV2(0, 59.282f + offsetBT1, true));
		
		// Chords 1
		track.Add(new NoteV2(0, 60.001f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 60.001f + offsetBT1, true));
		track.Add(new NoteV2(2, 60.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 61.254f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 61.254f + offsetBT1, true));
		track.Add(new NoteV2(2, 61.254f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 61.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 61.668f + offsetBT1, true));
		track.Add(new NoteV2(3, 61.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 62.921f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 62.921f + offsetBT1, true));
		track.Add(new NoteV2(3, 62.921f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.335f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 63.454f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 63.454f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.555f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.555f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 63.762f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 63.762f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 64.175f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 64.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 64.175f + offsetBT1, true));
		// track.Add(new NoteV2(3, 64.175f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 65.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 65.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 65.001f + offsetBT1, true));
		
		// Single 2
		track.Add(new NoteV2(1, 66.668f + offsetBT1, true));
		// track.Add(new NoteV2(0, 66.787f + offsetBT1, true));
		track.Add(new NoteV2(1, 66.990f + offsetBT1, true));
		// track.Add(new NoteV2(0, 67.095f + offsetBT1, true));
		track.Add(new NoteV2(2, 67.301f + offsetBT1, true));
		track.Add(new NoteV2(1, 67.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 68.335f + offsetBT1, true));
		// track.Add(new NoteV2(1, 68.454f + offsetBT1, true));
		track.Add(new NoteV2(2, 68.656f + offsetBT1, true));
		// track.Add(new NoteV2(1, 68.762f + offsetBT1, true));
		track.Add(new NoteV2(3, 68.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 69.175f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 70.001f + offsetBT1, true));
		track.Add(new NoteV2(4, 70.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 71.254f + offsetBT1, true));
		track.Add(new NoteV2(3, 72.095f + offsetBT1, true));
		// track.Add(new NoteV2(4, 72.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 72.401f + offsetBT1, true));
		track.Add(new NoteV2(1, 72.921f + offsetBT1, true));
		// track.Add(new NoteV2(0, 73.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 73.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 73.335f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 75.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 75.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 77.095f + offsetBT1, true));
		track.Add(new NoteV2(3, 77.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 77.921f + offsetBT1, true));
		track.Add(new NoteV2(1, 78.335f + offsetBT1, true));
		track.Add(new NoteV2(2, 78.967f + offsetBT1, true, true));
		
		// Chords 2
		track.Add(new NoteV2(1, 80.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 80.001f + offsetBT1, true));
	
		track.Add(new NoteV2(1, 81.668f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 81.668f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 83.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 83.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.001f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.323f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.323f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.634f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.634f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 85.842f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.842f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 86.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 86.668f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 88.335f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 88.335f + offsetBT1, true));
		
		track.Add(new NoteV2(2, 90.001f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 90.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 91.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 91.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 91.990f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 91.990f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.301f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.301f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.508f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.816f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.816f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 93.127f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 93.127f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.335f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.656f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.656f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.967f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.967f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.175f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.175f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.483f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.483f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.793f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.793f + offsetBT1, true));
		
		// Single 3
		track.Add(new NoteV2(2, 95.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 95.634f + offsetBT1, true));
		// track.Add(new NoteV2(2, 95.735f + offsetBT1, true));
		track.Add(new NoteV2(3, 95.842f + offsetBT1, true));
		// track.Add(new NoteV2(2, 96.460f + offsetBT1, true));
		// track.Add(new NoteV2(1, 96.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 96.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 97.095f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 98.335f + offsetBT1, true));
		// track.Add(new NoteV2(3, 98.967f + offsetBT1, true));
		// track.Add(new NoteV2(4, 99.068f + offsetBT1, true));
		track.Add(new NoteV2(2, 99.175f + offsetBT1, true));
		// track.Add(new NoteV2(1, 99.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 99.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 100.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 100.842f + offsetBT1, true));
		track.Add(new NoteV2(1, 101.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 101.668f + offsetBT1, true));
		track.Add(new NoteV2(2, 102.095f + offsetBT1, true));
		track.Add(new NoteV2(1, 102.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 102.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 103.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 105.001f + offsetBT1, true));
		// track.Add(new NoteV2(2, 105.120f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 106.460f + offsetBT1, true));
		// track.Add(new NoteV2(2, 106.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 106.668f + offsetBT1, true));
		// track.Add(new NoteV2(2, 106.787f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 108.335f + offsetBT1, true));
		// track.Add(new NoteV2(2, 108.454f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 109.793f + offsetBT1, true));
		// track.Add(new NoteV2(2, 109.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 110.001f + offsetBT1, true));
		// track.Add(new NoteV2(1, 110.120f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 111.668f + offsetBT1, true));
		// track.Add(new NoteV2(1, 111.787f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 113.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 113.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 113.335f + offsetBT1, true));
		// track.Add(new NoteV2(0, 113.454f + offsetBT1, true, true));
		track.Add(new NoteV2(0, 114.175f + offsetBT1, true));
		// track.Add(new NoteV2(0, 114.282f + offsetBT1, true));
		
		// Chords 3
		track.Add(new NoteV2(0, 115.001f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 115.001f + offsetBT1, true));
		track.Add(new NoteV2(2, 115.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 116.254f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 116.254f + offsetBT1, true));
		track.Add(new NoteV2(2, 116.254f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 116.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 116.668f + offsetBT1, true));
		track.Add(new NoteV2(3, 116.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 117.921f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 117.921f + offsetBT1, true));
		track.Add(new NoteV2(3, 117.921f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.335f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 118.454f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 118.454f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.555f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.555f + offsetBT1, true));
		
		// track.Add(new NoteV2(1, 118.762f + offsetBT1, true, true));
		// track.Add(new NoteV2(2, 118.762f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 119.175f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 119.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 119.175f + offsetBT1, true));
		// track.Add(new NoteV2(3, 119.175f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 120.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 120.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 120.001f + offsetBT1, true));
		
		// Single 4
		track.Add(new NoteV2(1, 121.668f + offsetBT1, true));
		// track.Add(new NoteV2(0, 121.787f + offsetBT1, true));
		track.Add(new NoteV2(1, 121.990f + offsetBT1, true));
		// track.Add(new NoteV2(0, 122.095f + offsetBT1, true));
		track.Add(new NoteV2(2, 122.301f + offsetBT1, true));
		track.Add(new NoteV2(1, 122.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 123.335f + offsetBT1, true));
		// track.Add(new NoteV2(1, 123.454f + offsetBT1, true));
		track.Add(new NoteV2(2, 123.656f + offsetBT1, true));
		// track.Add(new NoteV2(1, 123.762f + offsetBT1, true));
		track.Add(new NoteV2(3, 123.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 124.175f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 125.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 125.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 126.254f + offsetBT1, true));
		track.Add(new NoteV2(3, 127.095f + offsetBT1, true));
		// track.Add(new NoteV2(4, 127.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 127.401f + offsetBT1, true));
		track.Add(new NoteV2(1, 127.921f + offsetBT1, true));
		// track.Add(new NoteV2(0, 128.127f + offsetBT1, true));
		// track.Add(new NoteV2(1, 128.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 128.335f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 130.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 130.634f + offsetBT1, true));
		
		// Chords 4
		track.Add(new NoteV2(1, 132.095f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 132.095f + offsetBT1, true));
		
		track.Add(new NoteV2(2, 132.508f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 132.508f + offsetBT1, true));
		
		// Single 5
		track.Add(new NoteV2(3, 132.921f + offsetBT1, true));
		track.Add(new NoteV2(4, 133.333f + offsetBT1, true, true));
		bossMediumTracks.Add(track);
	}
	
	
	private void AddBossTheme1Hard() {
		List<NoteV2> track = new List<NoteV2>();
		// Single 1
		track.Add(new NoteV2(2, 6.668f + offsetBT1, true));
		track.Add(new NoteV2(1, 7.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 7.401f + offsetBT1, true));
		track.Add(new NoteV2(3, 7.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 8.127f + offsetBT1, true));
		track.Add(new NoteV2(1, 8.227f + offsetBT1, true));
		track.Add(new NoteV2(2, 8.335f + offsetBT1, true));
		track.Add(new NoteV2(0, 8.762f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 10.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 10.634f + offsetBT1, true));
		track.Add(new NoteV2(4, 10.735f + offsetBT1, true));
		track.Add(new NoteV2(2, 10.842f + offsetBT1, true));
		track.Add(new NoteV2(1, 11.460f + offsetBT1, true));
		track.Add(new NoteV2(2, 11.561f + offsetBT1, true));
		track.Add(new NoteV2(1, 11.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 12.508f + offsetBT1, true));
		track.Add(new NoteV2(1, 12.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 13.335f + offsetBT1, true));
		track.Add(new NoteV2(2, 13.762f + offsetBT1, true));
		track.Add(new NoteV2(1, 14.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 14.588f + offsetBT1, true));
		track.Add(new NoteV2(0, 15.001f + offsetBT1, true, true));
		
		// Gap 1 (Soundwave)
		track.Add(new NoteV2(1, 20.001f + offsetBT1, true));
		track.Add(new NoteV2(0, 20.120f + offsetBT1, true));
		track.Add(new NoteV2(1, 20.323f + offsetBT1, true));
		track.Add(new NoteV2(0, 20.428f + offsetBT1, true));
		track.Add(new NoteV2(3, 20.634f + offsetBT1, true));
		track.Add(new NoteV2(1, 20.842f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 21.668f + offsetBT1, true));
		track.Add(new NoteV2(1, 21.787f + offsetBT1, true));
		track.Add(new NoteV2(2, 21.990f + offsetBT1, true));
		track.Add(new NoteV2(1, 22.095f + offsetBT1, true));
		track.Add(new NoteV2(3, 22.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 22.508f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 23.335f + offsetBT1, true));
		track.Add(new NoteV2(4, 24.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 24.588f + offsetBT1, true));
		track.Add(new NoteV2(3, 25.428f + offsetBT1, true));
		track.Add(new NoteV2(4, 25.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 25.735f + offsetBT1, true));
		track.Add(new NoteV2(1, 26.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 26.460f + offsetBT1, true));
		track.Add(new NoteV2(1, 26.561f + offsetBT1, true));
		track.Add(new NoteV2(0, 26.668f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 28.335f + offsetBT1, true));
		track.Add(new NoteV2(3, 28.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 30.428f + offsetBT1, true));
		track.Add(new NoteV2(3, 30.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 31.254f + offsetBT1, true));
		track.Add(new NoteV2(1, 31.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 32.301f + offsetBT1, true, true));
		
		// Gap 2 (Soundwave)
		track.Add(new NoteV2(2, 40.001f + offsetBT1, true));
		track.Add(new NoteV2(1, 40.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 40.735f + offsetBT1, true));
		track.Add(new NoteV2(3, 40.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 41.460f + offsetBT1, true));
		track.Add(new NoteV2(1, 41.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 41.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 42.095f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 43.335f + offsetBT1, true));
		track.Add(new NoteV2(3, 43.967f + offsetBT1, true));
		track.Add(new NoteV2(4, 44.068f + offsetBT1, true));
		track.Add(new NoteV2(2, 44.175f + offsetBT1, true));
		track.Add(new NoteV2(1, 44.793f + offsetBT1, true));
		track.Add(new NoteV2(2, 44.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 45.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 45.842f + offsetBT1, true));
		track.Add(new NoteV2(1, 46.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 46.668f + offsetBT1, true));
		track.Add(new NoteV2(2, 47.095f + offsetBT1, true));
		track.Add(new NoteV2(1, 47.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 47.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 48.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 50.001f + offsetBT1, true));
		track.Add(new NoteV2(2, 50.120f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.460f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.668f + offsetBT1, true));
		track.Add(new NoteV2(2, 51.787f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 53.335f + offsetBT1, true));
		track.Add(new NoteV2(2, 53.454f + offsetBT1, true));
		track.Add(new NoteV2(2, 54.793f + offsetBT1, true));
		track.Add(new NoteV2(2, 54.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 55.001f + offsetBT1, true));
		track.Add(new NoteV2(1, 55.120f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 56.668f + offsetBT1, true));
		track.Add(new NoteV2(1, 58.787f + offsetBT1, true));
		track.Add(new NoteV2(1, 58.127f + offsetBT1, true));
		track.Add(new NoteV2(1, 58.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 58.335f + offsetBT1, true));
		track.Add(new NoteV2(0, 58.454f + offsetBT1, true, true));
		track.Add(new NoteV2(0, 59.175f + offsetBT1, true));
		track.Add(new NoteV2(0, 59.282f + offsetBT1, true));
		
		// Chords 1
		track.Add(new NoteV2(0, 60.001f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 60.001f + offsetBT1, true));
		track.Add(new NoteV2(2, 60.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 61.254f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 61.254f + offsetBT1, true));
		track.Add(new NoteV2(2, 61.254f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 61.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 61.668f + offsetBT1, true));
		track.Add(new NoteV2(3, 61.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 62.921f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 62.921f + offsetBT1, true));
		track.Add(new NoteV2(3, 62.921f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.454f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.454f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.555f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.555f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 63.762f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 63.762f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 64.175f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 64.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 64.175f + offsetBT1, true));
		track.Add(new NoteV2(3, 64.175f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 65.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 65.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 65.001f + offsetBT1, true));
		
		// Single 2
		track.Add(new NoteV2(1, 66.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 66.787f + offsetBT1, true));
		track.Add(new NoteV2(1, 66.990f + offsetBT1, true));
		track.Add(new NoteV2(0, 67.095f + offsetBT1, true));
		track.Add(new NoteV2(2, 67.301f + offsetBT1, true));
		track.Add(new NoteV2(1, 67.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 68.335f + offsetBT1, true));
		track.Add(new NoteV2(1, 68.454f + offsetBT1, true));
		track.Add(new NoteV2(2, 68.656f + offsetBT1, true));
		track.Add(new NoteV2(1, 68.762f + offsetBT1, true));
		track.Add(new NoteV2(3, 68.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 69.175f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 70.001f + offsetBT1, true));
		track.Add(new NoteV2(4, 70.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 71.254f + offsetBT1, true));
		track.Add(new NoteV2(3, 72.095f + offsetBT1, true));
		track.Add(new NoteV2(4, 72.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 72.401f + offsetBT1, true));
		track.Add(new NoteV2(1, 72.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 73.127f + offsetBT1, true));
		track.Add(new NoteV2(1, 73.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 73.335f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 75.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 75.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 77.095f + offsetBT1, true));
		track.Add(new NoteV2(3, 77.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 77.921f + offsetBT1, true));
		track.Add(new NoteV2(1, 78.335f + offsetBT1, true));
		track.Add(new NoteV2(2, 78.967f + offsetBT1, true, true));
		
		// Chords 2
		track.Add(new NoteV2(1, 80.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 80.001f + offsetBT1, true));
	
		track.Add(new NoteV2(1, 81.668f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 81.668f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 83.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 83.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.001f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.323f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.323f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 85.634f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.634f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 85.842f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 85.842f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 86.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 86.668f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 88.335f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 88.335f + offsetBT1, true));
		
		track.Add(new NoteV2(2, 90.001f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 90.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 91.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 91.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 91.990f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 91.990f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.301f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.301f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.508f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 92.816f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 92.816f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 93.127f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 93.127f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.335f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.656f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.656f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 93.967f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 93.967f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.175f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.175f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.483f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.483f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 94.793f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 94.793f + offsetBT1, true));
		
		// Single 3
		track.Add(new NoteV2(2, 95.001f + offsetBT1, true));
		track.Add(new NoteV2(1, 95.634f + offsetBT1, true));
		track.Add(new NoteV2(2, 95.735f + offsetBT1, true));
		track.Add(new NoteV2(3, 95.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 96.460f + offsetBT1, true));
		track.Add(new NoteV2(1, 96.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 96.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 97.095f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 98.335f + offsetBT1, true));
		track.Add(new NoteV2(3, 98.967f + offsetBT1, true));
		track.Add(new NoteV2(4, 99.068f + offsetBT1, true));
		track.Add(new NoteV2(2, 99.175f + offsetBT1, true));
		track.Add(new NoteV2(1, 99.793f + offsetBT1, true));
		track.Add(new NoteV2(2, 99.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 100.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 100.842f + offsetBT1, true));
		track.Add(new NoteV2(1, 101.254f + offsetBT1, true));
		track.Add(new NoteV2(0, 101.668f + offsetBT1, true));
		track.Add(new NoteV2(2, 102.095f + offsetBT1, true));
		track.Add(new NoteV2(1, 102.508f + offsetBT1, true));
		track.Add(new NoteV2(2, 102.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 103.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 105.001f + offsetBT1, true));
		track.Add(new NoteV2(2, 105.120f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 106.460f + offsetBT1, true));
		track.Add(new NoteV2(2, 106.561f + offsetBT1, true));
		track.Add(new NoteV2(2, 106.668f + offsetBT1, true));
		track.Add(new NoteV2(2, 106.787f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 108.335f + offsetBT1, true));
		track.Add(new NoteV2(2, 108.454f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 109.793f + offsetBT1, true));
		track.Add(new NoteV2(2, 109.894f + offsetBT1, true));
		track.Add(new NoteV2(1, 110.001f + offsetBT1, true));
		track.Add(new NoteV2(1, 110.120f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 111.668f + offsetBT1, true));
		track.Add(new NoteV2(1, 111.787f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 113.127f + offsetBT1, true));
		track.Add(new NoteV2(1, 113.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 113.335f + offsetBT1, true));
		track.Add(new NoteV2(0, 113.454f + offsetBT1, true, true));
		track.Add(new NoteV2(0, 114.175f + offsetBT1, true));
		track.Add(new NoteV2(0, 114.282f + offsetBT1, true));
		
		// Chords 3
		track.Add(new NoteV2(0, 115.001f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 115.001f + offsetBT1, true));
		track.Add(new NoteV2(2, 115.001f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 116.254f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 116.254f + offsetBT1, true));
		track.Add(new NoteV2(2, 116.254f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 116.668f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 116.668f + offsetBT1, true));
		track.Add(new NoteV2(3, 116.668f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 117.921f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 117.921f + offsetBT1, true));
		track.Add(new NoteV2(3, 117.921f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.335f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.335f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.454f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.454f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.555f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.555f + offsetBT1, true));
		
		track.Add(new NoteV2(1, 118.762f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 118.762f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 119.175f + offsetBT1, true, true));
		track.Add(new NoteV2(1, 119.175f + offsetBT1, true));
		track.Add(new NoteV2(2, 119.175f + offsetBT1, true));
		track.Add(new NoteV2(3, 119.175f + offsetBT1, true));
		
		track.Add(new NoteV2(0, 120.001f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 120.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 120.001f + offsetBT1, true));
		
		// Single 4
		track.Add(new NoteV2(1, 121.668f + offsetBT1, true));
		track.Add(new NoteV2(0, 121.787f + offsetBT1, true));
		track.Add(new NoteV2(1, 121.990f + offsetBT1, true));
		track.Add(new NoteV2(0, 122.095f + offsetBT1, true));
		track.Add(new NoteV2(2, 122.301f + offsetBT1, true));
		track.Add(new NoteV2(1, 122.508f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 123.335f + offsetBT1, true));
		track.Add(new NoteV2(1, 123.454f + offsetBT1, true));
		track.Add(new NoteV2(2, 123.656f + offsetBT1, true));
		track.Add(new NoteV2(1, 123.762f + offsetBT1, true));
		track.Add(new NoteV2(3, 123.967f + offsetBT1, true));
		track.Add(new NoteV2(2, 124.175f + offsetBT1, true, true));
		track.Add(new NoteV2(2, 125.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 125.842f + offsetBT1, true));
		track.Add(new NoteV2(2, 126.254f + offsetBT1, true));
		track.Add(new NoteV2(3, 127.095f + offsetBT1, true));
		track.Add(new NoteV2(4, 127.301f + offsetBT1, true));
		track.Add(new NoteV2(2, 127.401f + offsetBT1, true));
		track.Add(new NoteV2(1, 127.921f + offsetBT1, true));
		track.Add(new NoteV2(0, 128.127f + offsetBT1, true));
		track.Add(new NoteV2(1, 128.227f + offsetBT1, true));
		track.Add(new NoteV2(0, 128.335f + offsetBT1, true, true));
		track.Add(new NoteV2(4, 130.001f + offsetBT1, true));
		track.Add(new NoteV2(3, 130.634f + offsetBT1, true));
		
		// Chords 4
		track.Add(new NoteV2(1, 132.095f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 132.095f + offsetBT1, true));
		
		track.Add(new NoteV2(2, 132.508f + offsetBT1, true, true));
		track.Add(new NoteV2(3, 132.508f + offsetBT1, true));
		
		// Single 5
		track.Add(new NoteV2(3, 132.921f + offsetBT1, true));
		track.Add(new NoteV2(4, 133.333f + offsetBT1, true, true));
		bossHardTracks.Add(track);
	}
	
	
	public void SetGuitarNotesController(GuitarNotesController gnc) {
		guitarNotesController = gnc;
	}
	
	
	public IEnumerator StartRiffs(GameObject target) {
		// Get enemy's difficulty;
		EnemyController enemyController = target.GetComponent<EnemyController>();
		EnemyController.Difficulty enemyDifficulty = enemyController.GetDifficulty();
		
		// Keep sending riffs while the target is still alive.
		while (enemyController.GetHealth() > 0) {
			
			// Grab a random riff depending on difficulty.
			List<NoteV2> riff = GetRandomRiff(enemyDifficulty);
			
			// Play respective tracks.
			audioManagerScript.PlayRiffTrack(enemyDifficulty, riffNum);
			audioManagerScript.PlayDrumTrack(enemyDifficulty, riffNum);
			
			/* // Testing a specific riff.
			List<NoteV2> riff = easyHardRiffs[2];
			audioManagerScript.PlayRiffTrack(enemyDifficulty, 2);
			audioManagerScript.PlayDrumTrack(enemyDifficulty, 2); */
			
			// Send the riff's notes down the lanes.
			float currentTime = 0.0f;
			int noteIndex = 0;
			// Keep going while there are notes left.
			while (noteIndex < riff.Count) {
				// Only send a note when it is the right time.
				while (currentTime < riff[noteIndex].time) {
					currentTime += Time.deltaTime;
					yield return null;
				}
				guitarNotesController.GenerateNote(riff[noteIndex].laneNum, riff[noteIndex]);
				noteIndex++;
			}
			
			// Wait until drum track finishes.
			while (audioManagerScript.IsDrumTrackPlaying()) {
				yield return null;
			}
		}
	}
	
	
	// Returns a random riff based on game and enemy difficulty.
	private List<NoteV2> GetRandomRiff(EnemyController.Difficulty enemyDifficulty) {
		List<NoteV2> riff;
		if (enemyDifficulty == EnemyController.Difficulty.Easy && gameDifficulty == GameManager.Difficulty.Easy) {
			riffNum = Random.Range(0, easyEasyRiffs.Count);
			riff = easyEasyRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Easy && gameDifficulty == GameManager.Difficulty.Medium) {
			riffNum = Random.Range(0, easyMedRiffs.Count);
			riff = easyMedRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Easy && gameDifficulty == GameManager.Difficulty.Hard) {
			riffNum = Random.Range(0, easyHardRiffs.Count);
			riff = easyHardRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Medium && gameDifficulty == GameManager.Difficulty.Easy) {
			riffNum = Random.Range(0, medEasyRiffs.Count);
			riff = medEasyRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Medium && gameDifficulty == GameManager.Difficulty.Medium) {
			riffNum = Random.Range(0, medMedRiffs.Count);
			riff = medMedRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Medium && gameDifficulty == GameManager.Difficulty.Hard) {
			riffNum = Random.Range(0, medHardRiffs.Count);
			riff = medHardRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Hard && gameDifficulty == GameManager.Difficulty.Easy) {
			riffNum = Random.Range(0, hardEasyRiffs.Count);
			riff = hardEasyRiffs[riffNum];
		} else if (enemyDifficulty == EnemyController.Difficulty.Hard && gameDifficulty == GameManager.Difficulty.Medium) {
			riffNum = Random.Range(0, hardMedRiffs.Count);
			riff = hardMedRiffs[riffNum];
		} else {
			riffNum = Random.Range(0, hardHardRiffs.Count);
			riff = hardHardRiffs[riffNum];
		}
		return riff;
	}
	
	
	public IEnumerator StartBossTrack() {
		// Get a random track.

		int trackNum = Random.Range(0, bossHardTracks.Count);
		
		// Get the track version based on difficulty.
		List<NoteV2> track = new List<NoteV2>();
		if (gameDifficulty == GameManager.Difficulty.Easy)
			track = bossEasyTracks[trackNum];
		else if (gameDifficulty == GameManager.Difficulty.Medium)
			track = bossMediumTracks[trackNum];
		else
			track = bossHardTracks[trackNum];
		
		// Play respective tracks.
		audioManagerScript.PlayGuitarTrack(trackNum);
		audioManagerScript.PlayBackingTrack(trackNum);
		
		// Send the riff's notes down the lanes.
		float currentTime = 0.0f;
		int noteIndex = 0;
		// Keep going while there are notes left.
		while (noteIndex < track.Count) {
			// Only send a note when it is the right time.
			while (currentTime < track[noteIndex].time) {
				currentTime += Time.deltaTime;
				yield return null;
			}
			guitarNotesController.GenerateNote(track[noteIndex].laneNum, track[noteIndex]);
			noteIndex++;
		}
		
		// Wait until drum track finishes.
		while (audioManagerScript.IsBackingTrackPlaying()) {
			yield return null;
		}
		// Boss is dead.
		enemyDetection.EndCombat();
	}
	
}
