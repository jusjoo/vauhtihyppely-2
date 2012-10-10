using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovement))]

public class VectorCharacterControl : MonoBehaviour {


	private bool clicking;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			clicking = true;
		}
	}
}
