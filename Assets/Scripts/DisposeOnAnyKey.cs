using UnityEngine;
using System.Collections;

public class DisposeOnAnyKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.anyKeyDown)
        {
            GameObject.DestroyObject(this.gameObject);
        }
	}
}
