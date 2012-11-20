using UnityEngine;
using System.Collections;

public class DoorOpenTrigger : MonoBehaviour {
	
	/*
	 * This is the name of the door element (gameobject)
	 * that this trigger will open. This way we can use
	 * multiple triggers and door in one level. 
	 */
	public string nameOfDoorElement;
	
    private GameObject doorToOpen;
    private float timeToMove;
    
	// Is the opening triggered
	private bool triggered;

	// Is the door completely open. Should open only once
	private bool opened;

    // Use this for initialization
    void Start () {
        doorToOpen = GameObject.Find(nameOfDoorElement);
        timeToMove = 0; // in seconds
        triggered = false;
		opened = false;
    }
    
    // Update is called once per frame
    void Update () {

        if (triggered && ! opened )
        {
            // Move the door
            doorToOpen.transform.position += new Vector3(0f, 0.1f, 0f);
            timeToMove -= Time.deltaTime;
        } 
        
        if ( triggered && timeToMove < 0 )
        {
            // Stop the door
            triggered = false;
			opened = true;
            doorToOpen.transform.position += new Vector3(0f, 0f, 0f);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (! triggered && c.gameObject.name == "Player")
        {
			Debug.Log ("seesami aukene!");
            triggered = true;
            timeToMove = 1.0f;
        }

    }
}
