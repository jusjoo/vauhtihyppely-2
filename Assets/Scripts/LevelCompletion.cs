using UnityEngine;
using System.Collections;

public class LevelCompletion : MonoBehaviour {

	private GameObject exitObject;
	private SceneHandler sceneHandler;
	
	// Use this for initialization
	void Start () {
		exitObject = GameObject.Find("LevelEnd");
		sceneHandler = GameObject.Find("Player").GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == exitObject)
		{
			sceneHandler.LoadNextLevel();
		}
	}

}
