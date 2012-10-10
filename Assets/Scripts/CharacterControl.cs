using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterMovement))]

public class CharacterControl : MonoBehaviour {
	
	public float horizontalSensitivity;
	public float maxJumpTime;
	public float minJumpTime;
	public float registerAsJumpTime;
	
	private Vector2 lastMousePosition;
	private bool clicking;
	private float mouseStationaryTime;
	private bool jumping;
	private float jumpTimer;
	private bool mouseWasMoved;

	private CharacterMovement movementHandler;
	
	// Use this for initialization
	void Start () {
		clicking = false;
		movementHandler = this.GetComponent<CharacterMovement>();
	}
	
	public void sendMovement(float horizontalMovement) {
		
		// the command was not a jump when there was movement
		movementHandler.move(-horizontalMovement);
		wasMoved();
	}

	private void wasMoved()
	{
		mouseStationaryTime = 0.0f;
		mouseWasMoved = true;
	}
	
	public void sendJump() {
		
		movementHandler.jump(getJumpTime());
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
		// mouse was clicked
		if (Input.GetMouseButtonDown(0)) {
			clicking = true;
			mouseStationaryTime = 0.0f;
			lastMousePosition = Input.mousePosition;
			mouseWasMoved = false;
		}
		

		// mouse is being clicked
		if (clicking) {

			mouseStationaryTime += Time.deltaTime;

			float horizontalOffset = Input.mousePosition.x - lastMousePosition.x;
			
			// check if the controller movement is significant enough to be horizontal movement
			if (horizontalOffset > horizontalSensitivity) {
				sendMovement(horizontalOffset);
			}
			else if (horizontalOffset < -horizontalSensitivity) {
				sendMovement(horizontalOffset);
			}

			lastMousePosition = Input.mousePosition;


			if (jumping)
			{
				if (!movementHandler.getJumpingAllowed())
				{
					cancelJumping();
				}
				jumpTimer += Time.deltaTime;
			}
			else 			
			{
				// if the mouse is being clicked and has been stationary for longer than the required jump timer
				if (mouseStationaryTime > registerAsJumpTime && !mouseWasMoved)
				{
					// then we start jumping!
					startJumping();
				}
			}
		}


		// mouse click ends
		if (Input.GetMouseButtonUp(0))
		{
			clicking = false;

			// check if the command was to jump 
			if (jumping)
			{
				sendJump();
			}
		}
	
	
	}
	
	private void startJumping(){
		jumping = true;
		jumpTimer = 0.0f;
		
	}
	private void cancelJumping(){
		jumping = false;
		jumpTimer = 0.0f;
	}
	
	public float getJumpTime(){
		
		if (jumpTimer > maxJumpTime)
			return maxJumpTime;
		
		else if (jumpTimer < minJumpTime)
			return minJumpTime;
		
		else
			return jumpTimer;
	}

    public void setJumpTime(float jumpTimeNew)
    {
        jumpTimer = jumpTimeNew;
    }
}