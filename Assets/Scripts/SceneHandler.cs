using UnityEngine;
using System.Collections;

public class SceneHandler : MonoBehaviour {
	
	/**
	 * Number of the current level = 1...6
	 * Actually the index of the level starts from 2, but
	 * we will add +1 to it.
	 */
	private static int currentLevelNumber = 2;
	
	/**
	 * How many levels do we have?
	 * At the moments 3 levels, but aiming for 6.
	 */
	private int lastLevelNumber;

	/*
	 * The offset in Build Settings from the Level 1 to the index of the level.
	 * For examle, currently Level 1 has the index 3 
	 * => offset = 2.
	 */
	private int offsetFromFirstLevel = 2;
	
	private int deathScene;
	private int mainMenuScene;
	private int gameFinishedScene;
	
	// Use this for initialization
	void Start () {
		mainMenuScene = 0;		
		deathScene = 1;
		gameFinishedScene = 2;
		lastLevelNumber = 5;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	/**
	 */
	public void LoadNextLevel() {	
		currentLevelNumber++;
		
		if ( currentLevelNumber <= lastLevelNumber ) {
			LoadCurrentLevel();
		} else {
			// TODO peli pelattu onnellisesti loppuun scene
			Application.LoadLevel(gameFinishedScene);			
		}
	}
	
	public void LoadCurrentLevel() {	
		Application.LoadLevel( currentLevelNumber + offsetFromFirstLevel );
	}
	
	public void LoadDeathScene() {
		Application.LoadLevel(deathScene);
	}
	
	/**
	 * When game is started for the first time 
	 */
	public void GameStart() {
		currentLevelNumber = 1;
		Application.LoadLevel( (currentLevelNumber + offsetFromFirstLevel) );
	}
	
	public void LoadMainMenu() {
		Application.LoadLevel (mainMenuScene);
	}
}
