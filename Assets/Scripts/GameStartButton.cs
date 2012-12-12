using UnityEngine;
using System.Collections;

public class GameStartButton : MonoBehaviour {

	private SceneHandler sceneHandler;
	
	// Use this for initialization
	void Start () {
		sceneHandler = this.GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		sceneHandler.GameStart();
	}
}
