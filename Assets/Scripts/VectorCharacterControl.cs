using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMovement))]

public class VectorCharacterControl : MonoBehaviour {

	// The distance after the drag is automatically released
	public float maxDragDistance;
	
	// Amount (in pixels) in vertical drag, that is ignored,
	// to prevent unwanted jumps
	public float yDeadZone;	
	
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
		
		//Debug.Log("feet on ground: " + movementHandler.isOnGround());
		
		// If feet are not on the ground, don't read controls
		if ( ! movementHandler.isOnGround() ) {
			
			// Should not be necessary, but makes it more robust against bugs
			isMouseDown=false;
			
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
		if ( ( Input.GetMouseButtonUp(0) && isMouseDown ) ) { // || ( getDragDistance() >= maxDragDistance ) ) {
			isMouseDown = false;
			sendMovement(horizontalOffset, verticalOffset);
			horizontalOffset=0;
			verticalOffset=0;
		}


        if (Input.GetKey("left"))
        {
            sendMovement(5f, 0f);
        }

        if (Input.GetKey("right"))
        {
            sendMovement(-5f, 0f);
        }

	}
	
	public void sendMovement(float horizontalOffset, float verticalOffset) {
		
		if ( Mathf.Abs(verticalOffset) < yDeadZone ) {
			verticalOffset = 0;
		}
		
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
