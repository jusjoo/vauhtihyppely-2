using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class CharacterMovement : MonoBehaviour {
	
	public float speed;
	public float jumpHeightMultiplier;
	public float staticSpeed;
	
	private Vector3 movement;
	private bool jumping;
	private float jumpHeight;
	
	
	private Rigidbody rigidbody;
	private AnimationStateHandler animationHandler;
	
	// Use this for initialization
	void Start () {
		rigidbody = this.GetComponent<Rigidbody>();
		if ( speed == 0 ) speed = 5;
		animationHandler = this.GetComponent<AnimationStateHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		
		// move the character statically first
		rigidbody.AddForce (staticSpeed*Time.deltaTime, 0, 0);
		
		// calculate the movement force given from controllers
		Vector3 deltaMove = new Vector3(movement.x, movement.y, movement.z) * Time.deltaTime * speed;
		rigidbody.AddForce (deltaMove);
		movement =- deltaMove;
		
		// handle jumping
		if (jumping) {
			rigidbody.AddForce (0, jumpHeight, 0);
			jumping = false;
		}		
	}
	
	public void move(float horizontalMovement) {
		
		movement.x += horizontalMovement;
	}
	
	public void jump(float jumpTimer) {
		jumpHeight = jumpTimer * jumpHeightMultiplier;
		jumping = true;

		animationHandler.activateJumpAnimation();
		
	}
}
