using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterMovement))]

public class CharacterControl : MonoBehaviour {
	
	public float horizontalSensitivity;
	public float maxJumpTime;
	public float minJumpTime;
	
	
	private Vector2 lastMousePosition;
	private bool clicking;
	private bool jumping;
	private float jumpTimer;
	
	private CharacterMovement movementHandler;
	
	// Use this for initialization
	void Start () {
		clicking = false;
		movementHandler = this.GetComponent<CharacterMovement>();
	}
	
	public void sendMovement(float horizontalMovement) {
		
		// the command was not a jump when there was movement
		cancelJumping();
		movementHandler.move(horizontalMovement);
	}
	
	public void sendJump() {
		
		movementHandler.jump(getJumpTime());
		
	}
	
	
	// Update is called once per frame
	void Update () {

		
		if (Input.GetMouseButtonDown(0)) {
			clicking = true;
			startJumping();
			lastMousePosition = Input.mousePosition;
		}
		
		if (Input.GetMouseButtonUp(0)) {
			clicking = false;
			
			// check if the command was to jump 
			if (jumping) {
				sendJump();
			}
		}
		
		if (clicking) {
			
			float horizontalOffset = Input.mousePosition.x - lastMousePosition.x;
			
			// check if the controller movement is significant enough to be horizontal movement
			if (horizontalOffset > horizontalSensitivity) {
				sendMovement(horizontalOffset);
			}
			else if (horizontalOffset < -horizontalSensitivity) {
				sendMovement(horizontalOffset);
			}
			
			lastMousePosition = Input.mousePosition;
			if (jumping) {
				jumpTimer += Time.deltaTime;
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
}