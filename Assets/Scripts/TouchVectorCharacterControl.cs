using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovement))]

public class TouchVectorCharacterControl : MonoBehaviour {

	private float maxDragDistance = 25;

	/** To avoid unwanted jumps.
	 * Jumps less than this angle will be ignored,
	 * and treated as horizontal-only movement.
	 */
	private float deadzoneAngle = 25; // degrees

	private Touch currentTouch;
	private bool isTouching;
	private Vector2 originalMousePosition;	
	private float horizontalOffset;
	private float verticalOffset;
	
	private CharacterMovement movementHandler;	
	
	// Use this for initialization
	void Start () {
		movementHandler = this.GetComponent<CharacterMovement>();
		isTouching = false;
		clearDrag();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0)
		{
			// save the first touch to use, ignore multitouch
			if (currentTouch.Equals(null)) {
				//currentTouch = ;
			}



			if (Input.GetMouseButtonDown(0) && !isTouching)
			{
				// Mouse was pressed down
				isTouching = true;
				originalMousePosition = Input.mousePosition;

			}
			else if (isTouching)
			{
				// Mouse is being dragged
				horizontalOffset = Input.mousePosition.x - originalMousePosition.x;
				verticalOffset = Input.mousePosition.y - originalMousePosition.y;
			}

			// Mouse was released or maximum drag distance achieved
			if (Input.GetMouseButtonUp(0) && isTouching)
			{
				isTouching = false;
				sendMovement();
				clearDrag();
			}
		}
	}
	
	private void clearDrag() {
		horizontalOffset = 0;
		verticalOffset = 0;
	}
	
	public void sendMovement() {
		
		// To prevent unwanted jumps
		if ( isBelowJumpDeadzone() ) {
			verticalOffset = 0;
		}
		
		if ( isOverMaxDragDistance() ) {
			// Normalize
			float temp_distance = getDragDistance();
			horizontalOffset *= 1 / temp_distance;
			verticalOffset *= 1 / temp_distance;
		} else {
			// Normalize
			horizontalOffset *= 1 / maxDragDistance;
			verticalOffset *= 1 / maxDragDistance;
		}
		
		movementHandler.move(-horizontalOffset, -verticalOffset);
	}	
	
	private bool isBelowJumpDeadzone() {
		float angle = calculateAngle();
		if ( angle < 90f ) {
			return angle < deadzoneAngle;
		} else {
			return Mathf.Abs(180-angle) < deadzoneAngle;
		}
	}
	
	// Returns in degrees
	private float calculateAngle() {
		float angle = Mathf.Atan2(verticalOffset, horizontalOffset);
		angle = Mathf.Abs(angle);
		angle = angle*Mathf.Rad2Deg;
		angle -= 180;
		angle = Mathf.Abs(angle);
		return angle;
	}
	
	/*
	 * Returns the length of the drag
	 */
	public float getDragDistance() {
		// Pythagoras
		return Mathf.Sqrt (Mathf.Pow(horizontalOffset, 2f) + Mathf.Pow (verticalOffset, 2f) );	
	}
	
	private bool isOverMaxDragDistance() {
		float percent = getDragDistancePercent();
		return percent > 0.99;
	}
	
	/*
	 * Returns percent of current drag distance of the maximum.
	 * Returns float between 0.0 and 1.0
	 */
	public float getDragDistancePercent() {
		float percent = getDragDistance() / maxDragDistance;
		if ( percent > 1 ) {
			percent = 1.0f;
		}
		
		return percent;
	}
}
