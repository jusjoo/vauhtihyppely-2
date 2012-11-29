using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class CharacterMovement : MonoBehaviour {
	
	private float multiplierX = 0.6f;
	private float multiplierY = 1f;
	
	private float airMovementFactor = 0.4f;

	private float maxSpeedX = 10f;
	private float maxSpeedY = 27f;	
	
	private bool jumping;
	private bool isFeetOnGround;
	private bool doubleJumpAvailable;
	
	private Vector3 deltaMove;
	
	private Rigidbody player;
	private AnimationStateHandler animationHandler;
	private PowerUpStateHandler powerUpStateHandler;

	void Start () {
		player = this.GetComponent<Rigidbody>();
		animationHandler = this.GetComponent<AnimationStateHandler>();
		powerUpStateHandler = this.GetComponent<PowerUpStateHandler>();
		doubleJumpAvailable = false;
	}

	void Update () {

		// Turn player's face to the direction where it is moving
        animationHandler.flip(player.velocity.x < 0);
		animationHandler.setRunFactor(player.velocity.x / maxSpeedX );
		
		if ( ! isOnGround() ) {
			animationHandler.activateJumpAnimation();
		}
		if ( powerUpStateHandler.isPowerUpOn("BlackCoffee") )
			activateBlackCoffee();
		
		if ( powerUpStateHandler.isPowerUpOn("IrishCoffee") ) {
			player.AddForce( new Vector3(4, 30, 0)*Time.deltaTime/Time.timeScale );
		}
	}
	
	/**
	 * @params
	 *  - deltaX = 0..1
	 *	- deltaY = 0..1
	 *	
	 *	Required that deltaX^2 + deltaY^2 <= 1
	 */
	public void move(float deltaX, float deltaY) {
		
		if ( powerUpStateHandler.isPowerUpOn("IrishCoffee") ) {
			// Don't allow player controls because the player might end up in wrong places
			return;
		}
		
		deltaMove = new Vector3(0,0,0);
		
		if ( isOnGround() || doubleJumpActive()) {
			Debug.Log ("hyppyh");
			// Player is on the ground. Normal controls
			deltaMove.x = deltaX*multiplierX*maxSpeedX;
			deltaMove.y = deltaY*multiplierY*maxSpeedY;

		} else if ( isTryingToReduceSpeed(deltaX) ) {
			deltaMove.x = deltaX*airMovementFactor*multiplierX*maxSpeedX;
		}
		
    	checkMovementBoundaries();

		// To normalize with time
		player.AddForce (deltaMove);
	}
	
	private bool isTryingToReduceSpeed(float deltaX) {
		bool trying = (deltaX > 0 && player.velocity.x < 0) ||
				 (deltaX < 0 && player.velocity.x > 0);	
		return trying;
	}
	
	public void tryToLand(Collision collision) {
		
		float objCenterY = collision.transform.position.y;
		float objScaleY = collision.transform.localScale.y;
		float objHeightY = objScaleY;
		float objTopY = objCenterY + 0.5f * objHeightY;
		
		if ( objTopY < player.position.y ) {
			// The object is actually below the player, it's safe to land
			land ();
		} else if ( Mathf.Abs(collision.transform.rotation.z) < 0.20f ) {
			// Land because the obj is rotated less than 20 degrees
			Debug.Log ("land on a rotated " + collision.transform.rotation.z );
			land ();
		}
			
	}
	
	public void land() {

		isFeetOnGround = true;
		animationHandler.deactivateJumpAnimation();
		doubleJumpAvailable = true;
	}

	public void setFeetOnGround(bool b) {
		isFeetOnGround = b;
	}
	
	public bool isOnGround() {
		return isFeetOnGround;
	}

	private bool doubleJumpActive() {
		if(powerUpStateHandler.isPowerUpOn("DoubleEspresso")){
			if (doubleJumpAvailable) {
				doubleJumpAvailable = false;
                //animationHandler.createDoubleJumpEffect();
				return true;
			}
		}
		return false;
	}

	private void activateBlackCoffee(){
		Time.timeScale = 0.2f;
	}
	
	/*
	 * Prevents the player from going faster than wanted
	 */
	private void checkMovementBoundaries() {
		if ( player.velocity.x > maxSpeedX && isAddingSpeedToRight() ) {
			deltaMove.x = 0;	
		} else if ( player.velocity.x < maxSpeedX && ! isAddingSpeedToRight() ) {
			deltaMove.x = 0;
		}
	}
	
	private bool isAddingSpeedToRight() {
		return deltaMove.x > 0;	
	}
	
}
