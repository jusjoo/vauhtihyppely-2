using UnityEngine;
using System.Collections;

public class GUIMessageTrigger : MonoBehaviour {


    public GameObject message;
    public bool destroyOnTrigger = true;

    private GameObject playerObject;


	// Use this for initialization
	void Start () {
	    playerObject = GameObject.Find("Player");
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
        GameObject.Instantiate(message);

        if (destroyOnTrigger)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
