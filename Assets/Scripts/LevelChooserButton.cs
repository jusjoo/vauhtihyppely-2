using UnityEngine;
using System.Collections;

public class LevelChooserButton : MonoBehaviour {

	public int levelToLoad;
	private SceneHandler sceneHandler;
	
	// Use this for initialization
	void Start () {
		sceneHandler = this.GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log ("oon painettu. " + levelToLoad);
		sceneHandler.skipToLevel(levelToLoad);
	}
}
