using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovement))]

public class VectorCharacterControl : MonoBehaviour {

	// The distance after the drag is automatically released
	public float maxDragDistance;

	private bool isMouseDown;
	private Vector2 originalMousePosition;	
	private float horizontalOffset;
	private float verticalOffset;
	
	private CharacterMovement movementHandler;	
	
	// Use this for initialization
	void Start () {
		movementHandler = this.GetComponent<CharacterMovement>();
		isMouseDown = false;
		horizontalOffset = 0;
		verticalOffset = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
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
			sendMovement(horizontalOffset, verticalOffset);
			horizontalOffset = 0;
			verticalOffset = 0;
		}

	}
	
	public void sendMovement(float horizontalOffset, float verticalOffset) {
		movementHandler.move(-horizontalOffset, -verticalOffset);
	}	
	
	/*
	 * Returns the length of the drag
	 */
	public float getDragDistance() {
		// Pythagoras
		return Mathf.Sqrt (Mathf.Pow(horizontalOffset, (float)2) + Mathf.Pow (verticalOffset, (float)2) );	
	}
	
	/*
	 * Returns percent of current drag distance of the maximum.
	 * Returns float between 0.0 and 1.0
	 */
	public float getDragDistancePercent() {
		return getDragDistance() / maxDragDistance;
	}
}
