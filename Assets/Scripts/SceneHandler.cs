using UnityEngine;
using System.Collections;

public class SceneHandler : MonoBehaviour {
	
	/**
	 * Number of the current level = 1...6
	 * Actually the index of the level starts from 2, but
	 * we will add +1 to it.
	 */
	private static int currentLevelNumber = 2;
	
	private int lastSceneNumber;	
	/*
	 * The offset in Build Settings from the Level 1 to the index of the level.
	 * For examle, currently Level 1 has the index 2 
	 * => offset = 1.
	 */
	private int offsetFromFirstLevel = 1;
	
	/* */
	private int deathScene;
	
	private int mainMenuScene;
	
	// Use this for initialization
	void Start () {
		deathScene = 1;
		//currentLevelNumber = 1;
		mainMenuScene = 0;
		lastSceneNumber = 3;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("currentlevelnumber from update " + currentLevelNumber);
	}
	
	/**
	 */
	public void LoadNextLevel() {
		Debug.Log ("load next level ");
		
		currentLevelNumber++;
		
		if ( currentLevelNumber <= lastSceneNumber ) {
			LoadCurrentLevel();
		} else {
			// TODO peli pelattu onnellisesti loppuun scene
			Debug.Log ("peli pelattu läpi");
			Application.LoadLevel(mainMenuScene);			
		}
	}
	
	public void LoadCurrentLevel() {
		Debug.Log("load level with index " + (currentLevelNumber + offsetFromFirstLevel) );		
		Application.LoadLevel( currentLevelNumber + offsetFromFirstLevel );
	}
	
	public void LoadDeathScene() {
		Debug.Log ("load death scene");
		Application.LoadLevel(deathScene);
	}
	
	/**
	 * When game is started for the first time 
	 */
	public void GameStart() {
		Debug.Log("game start from scene handler");
		currentLevelNumber = 1;
		Application.LoadLevel( (currentLevelNumber + offsetFromFirstLevel) );
	}
}
