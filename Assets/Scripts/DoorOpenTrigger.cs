using UnityEngine;
using System.Collections;

public class DoorOpenTrigger : MonoBehaviour {

    private GameObject doorToOpen;
    private float timeToMove;
    private bool triggered;

    // Use this for initialization
    void Start () {
        doorToOpen = GameObject.Find("openingDoor");
        timeToMove = 0; // in seconds
        triggered = false;
    }
    
    // Update is called once per frame
    void Update () {

        if (triggered )
        {
            // Move the door
            doorToOpen.transform.position += new Vector3(0f, 0.1f, 0f);
            timeToMove -= Time.deltaTime;
        } 
        
        if ( triggered && timeToMove < 0 )
        {
            // Stop the door
            triggered = false;
            doorToOpen.transform.position += new Vector3(0f, 0f, 0f);
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (! triggered && c.gameObject.name == "Player")
        {
            triggered = true;
            timeToMove = 1.0f;
        }

    }
}
