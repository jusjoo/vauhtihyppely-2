using UnityEngine;
using System.Collections;

public class DeathBallTrigger : MonoBehaviour
{
	//  How many seconds the ball will fall without moving forward in x-direction
	public float freeFallTime = 0.5f;
	
	public float deathBallSpeed = 0.05f;
	public string elementNameToActivate = "deathBall";
	
	private float fallenTime;
    private GameObject deathBall;
    private bool triggeredBall;
	
    // Use this for initialization
    void Start()
    {
        deathBall = GameObject.Find(elementNameToActivate);
        fallenTime = 0f;
        triggeredBall = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (triggeredBall)
        {
            if ( fallenTime > freeFallTime ) {
				// Move the door
            	deathBall.transform.position += new Vector3(deathBallSpeed, 0.0f, 0f);
			} else {
				// Still in free fall
				fallenTime += Time.deltaTime;	
			}
		}

        
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (!triggeredBall && c.gameObject.name == "Player")
        {
            triggeredBall = true;
            deathBall.rigidbody.useGravity = true;
        }

    }
}
