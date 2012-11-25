using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovement))]

public class VectorCharacterControl : MonoBehaviour {

	private float maxDragDistance = 25;

	/** To avoid unwanted jumps.
	 * Jumps less than this angle will be ignored,
	 * and treated as horizontal-only movement.
	 */
	private float deadzoneAngle = 20; // degrees
	
	private bool isMouseDown;
	private Vector2 originalMousePosition;	
	private float horizontalOffset;
	private float verticalOffset;
	private bool isControlsFreezed;
	
	private CharacterMovement movementHandler;	
	
	// Use this for initialization
	void Start () {
		movementHandler = this.GetComponent<CharacterMovement>();
		isMouseDown = false;
		isControlsFreezed = false;
		clearDrag();
	}
	
	// Update is called once per frame
	void Update () {
	
		// When help message is shown in practice level,
		// the user might click the screen during the minShowTime
		// period. Don't accept controls that time.
		if ( isControlsFreezed ) {
			Debug.Log ("jäässä");
			return;
		}
		
		if ( Input.GetMouseButtonDown(0) && ! isMouseDown )	{
			// Mouse was pressed down
			isMouseDown = true;
			originalMousePosition = Input.mousePosition;
			
		} else if (isMouseDown) {
			// Mouse is being dragged
			horizontalOffset = Input.mousePosition.x - originalMousePosition.x;
			verticalOffset = Input.mousePosition.y - originalMousePosition.y;
		}

		// Mouse was released or maximum drag distance achieved
		if ( Input.GetMouseButtonUp(0) && isMouseDown ) {
			isMouseDown = false;
			sendMovement();
			clearDrag();
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
		
		//Debug.Log ("distance " + getDragDistance() );
		//Debug.Log ("hor " + horizontalOffset + " ver " + verticalOffset);		
		
		if ( isOverMaxDragDistance() ) {
			// Normalize
			float temp_distance = getDragDistance();
			horizontalOffset *= 1 / temp_distance;
			verticalOffset *= 1 / temp_distance;
		} else {
			horizontalOffset *= 1 / maxDragDistance;
			verticalOffset *= 1 / maxDragDistance;
		}
		//Debug.Log ("hor_norm " + horizontalOffset + " ver_norm " + verticalOffset);
		
		movementHandler.move(-horizontalOffset, -verticalOffset);
	}	
	
	private bool isBelowJumpDeadzone() {
		return calculateAngle() < deadzoneAngle;
	}
	
	// Returns in degrees
	private float calculateAngle() {
		float angle = Mathf.Atan2(verticalOffset, horizontalOffset);
		angle = Mathf.Abs(angle);
		angle = angle*Mathf.Rad2Deg;
		//Debug.Log("kulma " + angle);
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
	
	public void freezeControls() {
		isControlsFreezed = true;	
	}
	
	public void unfreezeControls() {
		isControlsFreezed = false;	
	}
}
