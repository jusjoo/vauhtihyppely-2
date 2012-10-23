using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class CharacterMovement : MonoBehaviour {
	
	public float horizontalMultiplier;
	public float verticalMultiplier;
	public float airMovementFactor;

	// Amount (in pixels) in vertical drag, that is ignored,
	// to prevent unwanted jumps.
	// Refactor this to use an angle instead of distance.
	public float yDeadZone;
	
	public float maxSpeedX;
	public float maxSpeedY;	
	
	private Vector3 movement;

	private bool jumping;
	private bool isFeetOnGround;

	private Rigidbody rigidbody;
    private HUDJumpBooster guiText;
	private AnimationStateHandler animationHandler;

	void Start () {
		rigidbody = this.GetComponent<Rigidbody>();
        guiText = GameObject.Find("JumpBooster").GetComponent<HUDJumpBooster>();
		animationHandler = this.GetComponent<AnimationStateHandler>();
	}

	void Update () {
		
		// calculate the movement force given from controllers
		Vector3 deltaMove = new Vector3(movement.x, movement.y, movement.z) * Time.deltaTime ;
		rigidbody.AddForce (deltaMove);
		movement =- deltaMove;
	
		// Turn player's face to the direction where it is moving
        animationHandler.flip(rigidbody.velocity.x < 0);
		animationHandler.setRunFactor(rigidbody.velocity.x / maxSpeedX );
		
		if ( ! isOnGround() ) {
			animationHandler.activateJumpAnimation();
		}
	}
	
	public void move(float horizontalMovement, float verticalMovement) {

		// To prevent unwanted jumps
		if ( Mathf.Abs(verticalMovement) < yDeadZone ) {
			verticalMovement = 0;
		}
		
		if ( isOnGround() ) {
			// Player is on the ground. Normal controls
			movement.x += horizontalMultiplier*horizontalMovement;
			movement.y += verticalMultiplier*verticalMovement;

		} else {
			// Player is in the air, can only slow down x-speed.
			// Not possible to jump.
			if ( (horizontalMovement > 0 && rigidbody.velocity.x < 0) ||
				 (horizontalMovement < 0 && rigidbody.velocity.x > 0) ) {
				Debug.Log("I'm braking in the air");
				movement.x += airMovementFactor*horizontalMultiplier*horizontalMovement;			
			}
		}
		
    	checkMovementBoundaries();
		//Debug.Log("x_speed: " + movement.x + " y_speed: " + movement.y);

	}

	/*public void jump(float jumpTimer) {

		if (feetOnGround)
		{
			jumpHeight = jumpTimer * jumpHeightMultiplier;
			jumping = true;
			
			// update gui and animation
			guiText.setJumpingDone(true);
			animationHandler.activateJumpAnimation();
		}
	}*/

	public void land() {
		isFeetOnGround = true;
		animationHandler.deactivateJumpAnimation();
	}

	public void setFeetOnGround(bool b) {
		isFeetOnGround = b;
	}
	
	/*
	 * Returns true if the players feet are on ground.
	 * Used to be named "getJumpingAllowed".
	 */
	public bool isOnGround() {
		return isFeetOnGround;
	}
	
	/*
	 * Prevents the player from going faster than wanted
	 */
	private void checkMovementBoundaries() {
		if (rigidbody.velocity.x > maxSpeedX && movement.x > 0) {
			movement.x = 0;
		} else if (rigidbody.velocity.x < -maxSpeedX && movement.x < 0) {
			movement.x = 0;		
		}
		
		if (movement.y > maxSpeedY) {
			movement.y = maxSpeedY;
		} else if (movement.y < -maxSpeedY) {
			movement.y = -maxSpeedY;
		}
	}
}
