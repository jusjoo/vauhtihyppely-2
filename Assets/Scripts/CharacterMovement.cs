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
	private bool doubleJumpAvailable;

	private Rigidbody rigidbody;
    private HUDJumpBooster guiText;
	private AnimationStateHandler animationHandler;
	private PowerUpStateHandler powerUpStateHandler;

	void Start () {
		rigidbody = this.GetComponent<Rigidbody>();
        guiText = GameObject.Find("JumpBooster").GetComponent<HUDJumpBooster>();
		animationHandler = this.GetComponent<AnimationStateHandler>();
		powerUpStateHandler = this.GetComponent<PowerUpStateHandler>();
		doubleJumpAvailable = true;
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
		
		if ( isOnGround() || doubleJumpActive()) {
			// Player is on the ground. Normal controls
			movement.x += horizontalMultiplier*horizontalMovement;
			movement.y += verticalMultiplier*verticalMovement;

		} else {
			// Player is in the air, can only slow down x-speed.
			// Not possible to jump.
			if ( (horizontalMovement > 0 && rigidbody.velocity.x < 0) ||
				 (horizontalMovement < 0 && rigidbody.velocity.x > 0) ) {
				movement.x += airMovementFactor*horizontalMultiplier*horizontalMovement;			
			}
		}
		
    	checkMovementBoundaries();

	}

	public void land() {
		isFeetOnGround = true;
		animationHandler.deactivateJumpAnimation();
		doubleJumpAvailable = true;
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

	private bool doubleJumpActive() {
		if(powerUpStateHandler.isPowerUpOn("DoubleJump")){
			if (doubleJumpAvailable) {
				doubleJumpAvailable = false;
				return true;
			}
		}
		return false;
	}

	
	/*
	 * Prevents the player from going faster than wanted
	 */
	private void checkMovementBoundaries() {
		// We can't set the movement.x value directly,
		// for example movement.x = 300 won't work.
		// Because of this we use a workaround.
		
		if (rigidbody.velocity.x > maxSpeedX && movement.x > 0) {
			// Workaround: With this added amount the movement.x
			// will be equal to maxSpeedX.
			movement.x = maxSpeedX - rigidbody.velocity.x;
		} else if (rigidbody.velocity.x < -maxSpeedX && movement.x < 0) {
			// Workaround
			movement.x = -(maxSpeedX - rigidbody.velocity.x);
		}
		
		if (movement.y > maxSpeedY) {
			movement.y = maxSpeedY;
		} else if (movement.y < -maxSpeedY) {
			movement.y = -maxSpeedY;
		}
	}

}
