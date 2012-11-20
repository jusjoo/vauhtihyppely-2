using UnityEngine;
using System.Collections;

public class DoorOpenTrigger : MonoBehaviour {
	
	/*
	 * This is the name of the door element (gameobject)
	 * that this trigger will open. This way we can use
	 * multiple triggers and door in one level. 
	 */
	public string nameOfDoorElement;
	
	/*
	 * How many pixels the door will go up 
	 */
	public float amountToMoveY = 5.0f;
	
	/*
	 * How many pixels the door has risen.
	 * Will eventually be amountAlreadyMovedY == amountToMoveY.
	 */
	private float amountAlreadyMovedY;
	
	/*
	 * In how many seconds the door should move the given amount.
	 * This gives us the speed = amountToMoveY/timeToRise 
	 */
	public float timeToMove = 1.0f;
	
    private GameObject doorToOpen;
    
	// Is the opening triggered
	private bool triggered;

	// Is the door completely open. Should open only once
	private bool opened;

    // Use this for initialization
    void Start () {
        doorToOpen = GameObject.Find(nameOfDoorElement);
        amountAlreadyMovedY = 0f;
        triggered = false;
		opened = false;
    }
    
    // Update is called once per frame
    void Update () {

        if (triggered && ! opened )
        {
            // Move the door
			float howMuchToMove = amountToMoveY * (Time.deltaTime / timeToMove); 
			amountAlreadyMovedY += howMuchToMove;
			
            doorToOpen.transform.position += new Vector3(0f, howMuchToMove, 0f);
        } 
        
        if ( triggered && amountAlreadyMovedY > amountToMoveY )
        {
            // Stop the door
            triggered = false;
			opened = true;
            //doorToOpen.transform.position += new Vector3(0f, 0f, 0f);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (! triggered && c.gameObject.name == "Player")
        {
			Debug.Log ("seesami aukene!");
            triggered = true;
        }

    }
}
