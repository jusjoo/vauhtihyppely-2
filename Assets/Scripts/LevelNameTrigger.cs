using UnityEngine;
using System.Collections;

public class LevelNameTrigger : MonoBehaviour {


    public GameObject message;
    public bool destroyOnTrigger = true;

    private GameObject playerObject;
	private SceneHandler sceneHandler;


	// Use this for initialization
	void Start () {
	    playerObject = GameObject.Find("Player");
		sceneHandler = this.GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider c) {
        if(c.gameObject == playerObject) {
            trigger();
        }

    }

    private void trigger() {
		if ( sceneHandler.isPlayingLevelForFistTime() ) {
	        GameObject.Instantiate(message);
		}

        if (destroyOnTrigger)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
