using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class CharacterMovement : MonoBehaviour {
	
	private float multiplierX = 6;
	private float multiplierY = 14;
	
	private float airMovementFactor = 0.7f;

	private float maxSpeedX = 10f;
	private float maxSpeedY = 10f;	
	
	private bool jumping;
	private bool isFeetOnGround;
	private bool doubleJumpAvailable;
	private bool blackCoffeeAvailable;
	
	private Vector3 deltaMove;
	
	private Rigidbody player;
    private HUDJumpBooster guiText;
	private AnimationStateHandler animationHandler;
	private PowerUpStateHandler powerUpStateHandler;

	void Start () {
		player = this.GetComponent<Rigidbody>();
        guiText = GameObject.Find("JumpBooster").GetComponent<HUDJumpBooster>();
		animationHandler = this.GetComponent<AnimationStateHandler>();
		powerUpStateHandler = this.GetComponent<PowerUpStateHandler>();
		doubleJumpAvailable = true;
		blackCoffeeAvailable = true;
	}

	void Update () {
		
		//Debug.Log ("speedX " + rigidbody.velocity.x + " speedY " + rigidbody.velocity.y);
		
		// Turn player's face to the direction where it is moving
        animationHandler.flip(player.velocity.x < 0);
		animationHandler.setRunFactor(player.velocity.x / maxSpeedX );
		
		if ( ! isOnGround() ) {
			animationHandler.activateJumpAnimation();
		}
		if (blackCoffeeActive())
			activateBlackCoffee();
		
		if ( powerUpStateHandler.isPowerUpOn("IrishCoffee") ) {
			player.AddForce( new Vector3(9, 35, 0)*Time.deltaTime/Time.timeScale );
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
		
		deltaMove = new Vector3(0,0,0);

		if ( isOnGround() || doubleJumpActive()) {
			// Player is on the ground. Normal controls
			deltaMove.x = deltaX*multiplierX;
			deltaMove.y = deltaY*multiplierY;

		} else if ( isTryingToReduceSpeed(deltaX) ) {
			deltaMove.x = deltaX*airMovementFactor*multiplierX;
		}

		applySpeedLimits();
		player.AddForce(deltaMove);
	}
	
	private bool isTryingToReduceSpeed(float deltaX) {
		bool trying = (deltaX > 0 && player.velocity.x < 0) ||
				 (deltaX < 0 && player.velocity.x > 0);	
		return trying;
	}
	
	public void tryToLand(Collision collision) {

		float objCenterY = collision.collider.transform.position.y;
		float objHeight = collision.collider.transform.localScale.y;
		float objTopY = objCenterY + objHeight / 2;

		if ( collision.collider.transform.rotation.z != 0 ) {
			// Don't land on rotated objects
		} else if ( objTopY < player.position.y ) {
			// Land because the collision object is below our player
			land ();
		} else {
			//Debug.Log ("don't land -- it's a wall");
		}
			
	}
	
	public void land() {
		//Debug.Log ("land here");
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
		if(powerUpStateHandler.isPowerUpOn("Espresso")){
			if (doubleJumpAvailable) {
				doubleJumpAvailable = false;
				return true;
			}
		}
		return false;
	}

	private bool blackCoffeeActive(){
		if (powerUpStateHandler.isPowerUpOn("BlackCoffee")){
			if (blackCoffeeAvailable){
				blackCoffeeAvailable = false;
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
	private void applySpeedLimits() {

		if (player.velocity.x > maxSpeedX && isAddingSpeedToRight() )
		{
			deltaMove.x = 0;
		}
		else if (player.velocity.x < -maxSpeedX && ! isAddingSpeedToRight() )
		{
			deltaMove.x = 0;
		}
	}
	
	private bool isAddingSpeedToRight() {
		return deltaMove.x > 0;	
	}
	
}
