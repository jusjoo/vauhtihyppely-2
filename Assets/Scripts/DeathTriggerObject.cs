using UnityEngine;
using System.Collections;

public class DeathTriggerObject : MonoBehaviour {
	
	private SceneHandler sceneHandler;
	
	// Use this for initialization
	void Start () {
		sceneHandler = GameObject.Find("Player").GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Player")
        {
			sceneHandler.LoadDeathScene();
        }
    }
}
