using UnityEngine;
using System.Collections;

public class LevelCompletion : MonoBehaviour {

	private GameObject exitObject;

	// Use this for initialization
	void Start () {
		exitObject = GameObject.Find("LevelEnd");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == exitObject)
		{
			Application.LoadLevel(0);
		}
	}

}
