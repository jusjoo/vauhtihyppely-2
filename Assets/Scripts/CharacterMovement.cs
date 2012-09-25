using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class CharacterMovement : MonoBehaviour {
	
	public float jumpHeightMultiplier;
	public float staticSpeed;
	public float minimumSpeed;
	public float boostAmount;
	public float boostDuration;
	public float boostCooldownTime;
	
	private Vector3 movement;
	private bool jumping;
	private float jumpHeight;
	private bool feetOnGround;
	private float boostCooldown;
	private bool boosting;
	

	private Rigidbody rigidbody;
    private HUDJumpBooster guiText;
	private AnimationStateHandler animationHandler;

	
	void Start () {

		rigidbody = this.GetComponent<Rigidbody>();
        guiText = GameObject.Find("JumpBooster").GetComponent<HUDJumpBooster>();
		animationHandler = this.GetComponent<AnimationStateHandler>();

	}
	

	void Update () {
		
		// move the character statically first
		rigidbody.AddForce (staticSpeed*Time.deltaTime, 0, 0);

		// add boost if boost active
		if (boosting)
		{
			boost();
			if (boostCooldown < boostCooldownTime - boostDuration)
				boosting = false;
		}
		
		// calculate the movement force given from controllers
		Vector3 deltaMove = new Vector3(movement.x, movement.y, movement.z) * Time.deltaTime ;
		rigidbody.AddForce (deltaMove);
		movement =- deltaMove;
		
		// handle jumping, also stop boosting if jumping
		if (jumping) {
			rigidbody.AddForce (0, jumpHeight, 0);
			jumping = false;
			boosting = false;
		}

		// count boost cooldown if active
		if (boostCooldown > 0)
		{
			boostCooldown -= Time.deltaTime;
		}
	}
	
	public void move(float horizontalMovement) {

		if (horizontalMovement < 0)
		{
			slowDown(horizontalMovement);
		}
		else if (boostCooldown <= 0 && feetOnGround)
		{
			boostCooldown = boostCooldownTime;
			boosting = true;
		}

	}

	
	private void slowDown(float amount)
	{
		movement.x += amount;
		if (movement.x < minimumSpeed)
			movement.x = minimumSpeed;
	}

	private void boost()
	{
		movement.x += boostAmount;
	}

	public void jump(float jumpTimer) {

		if (feetOnGround)
		{
			jumpHeight = jumpTimer * jumpHeightMultiplier;
			jumping = true;
			
			// update gui and animation
			guiText.setJumpingDone(true);
			animationHandler.activateJumpAnimation();
		}
	}

	public void land()
	{
		feetOnGround = true;
		animationHandler.deactivateJumpAnimation();
	}

	public void setJumpingAllowed(bool b)
	{
		feetOnGround = b;
	}

}
