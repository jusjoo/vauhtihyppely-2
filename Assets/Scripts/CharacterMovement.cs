using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class CharacterMovement : MonoBehaviour {
	
	private float multiplierX = 0.6f;
	private float multiplierY = 1f;
	
	private float airMovementFactor = 0.4f;

	private float maxSpeedX = 14f;
	private float maxSpeedY = 27f;	
	
	private bool jumping;
	private bool isFeetOnGround;
	private bool doubleJumpAvailable;
	
	private Vector3 airDrag;
	
	private Vector3 deltaMove;
	
	private Rigidbody player;
	private AnimationStateHandler animationHandler;
	private PowerUpStateHandler powerUpStateHandler;
    private AudioEffects audioEffects;

	void Start () {
		player = this.GetComponent<Rigidbody>();
		animationHandler = this.GetComponent<AnimationStateHandler>();
		powerUpStateHandler = this.GetComponent<PowerUpStateHandler>();
        audioEffects = GameObject.Find("AudioEffects").GetComponent<AudioEffects>();
		doubleJumpAvailable = false;
		airDrag = new Vector3(12f, 0f, 0f);
	}

	void Update () {

		// Turn player's face to the direction where it is moving
        animationHandler.flip(player.velocity.x < 0);
		animationHandler.setRunFactor(player.velocity.x / maxSpeedX );
		
		// When player is on air, we need to add air drag
		if ( ! isOnGround() ) {
			animationHandler.activateJumpAnimation();
			addAirDragIfNecessary();
		}
		
		if ( powerUpStateHandler.isPowerUpOn("BlackCoffee") )
			activateBlackCoffee();
		
		if ( powerUpStateHandler.isPowerUpOn("IrishCoffee") ) {
			player.AddForce( new Vector3(13f, 30f, 0f) *Time.deltaTime/Time.timeScale );
		}
		
		// On slow speeds, stop completely
		// Minimum values set, because otherwise the speed will underflow
		// and turn the player's face from left to right
		if ( ( player.velocity.x > 0.05 && player.velocity.x < 0.8 )
			|| ( player.velocity.x < -0.05 && player.velocity.x > -0.8 )
			) {
			player.velocity = new Vector3(player.velocity.x*0.9f, player.velocity.y, 0f);
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
		
		{
			// Some magic code...
			float tempX = Mathf.Sqrt( Mathf.Abs(deltaX) );
			float tempY = Mathf.Sqrt( Mathf.Abs(deltaY) );
			
			if ( deltaX < 0 ) {
				deltaX = tempX*(-1);
			} else {
				deltaX = tempX;	
			}
			
			if ( deltaY < 0 ) {
				deltaY = tempY*(-1);
			} else {
				deltaY = tempY;	
			}		
		}
			
		if ( powerUpStateHandler.isPowerUpOn("IrishCoffee") ) {
			// Don't allow player controls because the player might end up in wrong places
			return;
		}
		
		deltaMove = new Vector3(0,0,0);
		
		if ( isOnGround() || doubleJumpActive()) {
			// Player is on the ground. Normal controls
			deltaMove.x = deltaX*multiplierX*maxSpeedX;
			deltaMove.y = deltaY*multiplierY*maxSpeedY;
			
			// If the player wants to jump to complete new direction,
			// then make it easier
			/*if ( Mathf.Abs(deltaY) > 0.001 && wantsToChangeDirection() ) {
				player.velocity = new Vector3(0, player.velocity.y, 0);	
			}*/

            if (deltaMove.y > 0) audioEffects.play("jump");

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
		
		
		// 3 is a magic number, because won't land on flag pole otherwise...
		if ( objTopY < player.position.y + 3 ) {
			// The object is actually below the player, it's safe to land
			land ();
		} else if ( Mathf.Abs(collision.transform.rotation.z) < 0.20f
				&& Mathf.Abs(collision.transform.rotation.z) > 0.01f ) {
			// Land because the obj is rotated less than 20 degrees
			// but it's rotated atleast 1 degree (otherwise it could be a wall)
			Debug.Log ("land on a rotated " + collision.transform.rotation.z );
			land ();
		} else {
			// we can't stop here. this is bat country.
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
                animationHandler.createDoubleJumpEffect();
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
		} else if ( player.velocity.x < -maxSpeedX && ! isAddingSpeedToRight() ) {
			deltaMove.x = 0;
		}
	}
	
	private void addAirDragIfNecessary() {
		float percent = player.velocity.x / maxSpeedX;
		percent = Mathf.Abs( percent );
		
		if ( isMovingRight() ) {
			player.AddForce( -airDrag * percent * Time.deltaTime / Time.timeScale);
		} else if ( isMovingLeft() ) {
			player.AddForce( airDrag * percent * Time.deltaTime / Time.timeScale);
		}	
	}
	
	private bool isMovingRight() {
		return player.velocity.x > 0.1;	
	}
	
	private bool isMovingLeft() {
		return player.velocity.x < -0.1;	
	}

	
	private bool isAddingSpeedToRight() {
		return deltaMove.x > 0;	
	}
	
	private bool wantsToChangeDirection() {
		return (deltaMove.x < 0.5 && player.velocity.x > 0 || deltaMove.x > 0.5 && player.velocity.x < 0);
	}
}
