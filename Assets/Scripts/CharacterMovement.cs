using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

/*TODO: hiirenklikkauksen minimiaika. eli ettei hyppää slaidatessa*/

public class CharacterMovement : MonoBehaviour {
	
	public float jumpHeightMultiplier;
	
	private Vector3 movement;

	private bool jumping;
	private float jumpHeight;
	private bool feetOnGround;

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
		
		// handle jumping
		if (jumping) {
			rigidbody.AddForce (0, jumpHeight, 0);
			jumping = false;
		}

        if (rigidbody.velocity.x < 0)
        {
            animationHandler.flip(true);
        }
        else 
        {
            animationHandler.flip(false);
        }



	}
	
	public void move(float horizontalMovement) {

        if (feetOnGround)
        {
            movement.x =+ horizontalMovement;
        }

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

	public bool getJumpingAllowed(){
		return feetOnGround;
	}

}
