using UnityEngine;
using System.Collections;

public class FeetSensorTrigger : MonoBehaviour {
	CharacterMovement movement;
	
	// Use this for initialization
	void Start () {
		movement = this.GetComponent<CharacterMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		Debug.Log("land");
		movement.land();
	}


	void OnCollisionExit(Collision collision)
	{
		movement.setFeetOnGround(false);
	}

	void OnCollisionStay(Collision collision)
	{
		movement.land();
	}
	

}
