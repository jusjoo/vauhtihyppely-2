using UnityEngine;
using System.Collections;

public class DeathSceneScript : MonoBehaviour {

    public int sceneNumberToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(sceneNumberToLoad);
        }
	}
}