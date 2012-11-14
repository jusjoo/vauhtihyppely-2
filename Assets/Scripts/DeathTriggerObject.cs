using UnityEngine;
using System.Collections;

public class DeathTriggerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Player")
        {
            Debug.Log("Kuolemaa");
            c.gameObject.GetComponent<FallingDeathHandler>().die();
        }

    }
}
