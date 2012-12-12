using UnityEngine;
using System.Collections;

public class LevelWarp : MonoBehaviour {
	
	private SceneHandler sceneHandler;
	
	// Use this for initialization
	void Start () {
		sceneHandler = this.GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
			// Offset of one, because I don't count practice level as a level
		
		if ( Input.GetKey(KeyCode.Space) ) {
			sceneHandler.LoadNextLevel();
			
		} else if ( Input.GetKey("0")) {
			sceneHandler.skipToLevel(1);
	
		} else if ( Input.GetKey("1")) {
			sceneHandler.skipToLevel(2);
			
		} else if ( Input.GetKey("2")) {
			sceneHandler.skipToLevel(3);
			
		} else if ( Input.GetKey("3")) {
			sceneHandler.skipToLevel(4);
			
		} else if ( Input.GetKey("4")) {
			sceneHandler.skipToLevel(5);
			
		} else if ( Input.GetKey("5")) {
			sceneHandler.skipToLevel(6);
			
		} else if ( Input.GetKey("6")) {
			sceneHandler.skipToLevel(7);
			
		} else if ( Input.GetKey("7")) {
			sceneHandler.skipToLevel(8);
			
		} else if ( Input.GetKey("8")) {
			sceneHandler.skipToLevel(9);
			
		} else if ( Input.GetKey("9")) {
			sceneHandler.skipToLevel(10);

		}
	}
}
