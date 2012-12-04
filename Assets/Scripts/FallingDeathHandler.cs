using UnityEngine;
using System.Collections;

public class FallingDeathHandler : MonoBehaviour {

	public float yThreshold;
	private SceneHandler sceneHandler;
	
	// Use this for initialization
	void Start () {
		sceneHandler = this.GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < yThreshold)
		{
			die();
		}
	}

	public void die()
	{
		sceneHandler.LoadDeathScene();
	}
}
