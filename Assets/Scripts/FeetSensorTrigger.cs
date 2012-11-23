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
		this.HandleCollision(collision);
	}
	
	void OnCollisionStay(Collision collision)
	{
		this.HandleCollision(collision);
	}

	void OnCollisionExit(Collision collision)
	{
		movement.setFeetOnGround(false);
	}

	void HandleCollision(Collision collision) {
		float objCenterY = collision.collider.transform.position.y;
		Vector3 objScale = collision.collider.transform.localScale;
		float objHeight = objScale.y;
		
		float objTopY = objCenterY + objHeight / 2;
		
		movement.tryToLand(objTopY);
	}
	

}
