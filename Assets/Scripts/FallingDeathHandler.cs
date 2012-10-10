using UnityEngine;
using System.Collections;

public class FallingDeathHandler : MonoBehaviour {

	public float yThreshold;

	// Use this for initialization
	void Start () {
	
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
		Application.LoadLevel(3);
	}
}
