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
	private bool jumpingAllowed;
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
		
		// handle jumping
		if (jumping) {
			rigidbody.AddForce (0, jumpHeight, 0);
			jumping = false;
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
		else if (boostCooldown <= 0)
		{
			boostCooldown = boostCooldownTime;
			boosting = true;
		}

	}

	
	private void slowDown(float amount)
	{
		Debug.Log("Slowing down!");
		movement.x += amount;
		if (movement.x < minimumSpeed)
			movement.x = minimumSpeed;
	}

	private void boost()
	{
		Debug.Log("Boosting!");
		movement.x += boostAmount;
	}

	public void jump(float jumpTimer) {

		if (jumpingAllowed)
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
		jumpingAllowed = true;
		animationHandler.deactivateJumpAnimation();
	}

	public void setJumpingAllowed(bool b)
	{
		jumpingAllowed = b;
	}

}
