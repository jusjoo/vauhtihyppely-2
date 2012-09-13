using UnityEngine;
using System.Collections;

public class LevelChooserButton : MonoBehaviour {

	public int sceneNumberToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Application.LoadLevel(sceneNumberToLoad);
	}
}
