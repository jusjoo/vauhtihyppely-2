using UnityEngine;
using System.Collections;

public class DeathBallTrigger : MonoBehaviour
{
	// How many seconds the ball will fall with extra "gravity"
	// and we slowly speed up the forward movement
	public float freeFallTime = 0.5f;
	
	public float deathBallSpeed = 0.05f;
    public GameObject deathBall;
	
	private float fallenTime;
    private bool triggeredBall;
    private LightActivator lightActivator;
	
    // Use this for initialization
    void Start()
    {
        
        lightActivator = deathBall.GetComponentInChildren<LightActivator>();
        lightActivator.deactivate();
        fallenTime = 0f;
        triggeredBall = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (triggeredBall)
        {
            if ( fallenTime > freeFallTime ) {
				// Move the ball forward
            	deathBall.transform.position += new Vector3(deathBallSpeed, 0.0f, 0f);
			} else {
				// Still in free fall
				fallenTime += Time.deltaTime;
				
				// ... actually free fall is not enough. Let's speed up the falling.
				float dropAmount = -1.9f *Time.deltaTime;
				
				// ... also, slowly start moving the ball forward.
				float moveForwardAmount = deathBallSpeed* (fallenTime/freeFallTime);
				deathBall.transform.position += new Vector3(moveForwardAmount, dropAmount, 0f);
			}
		}

        
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (!triggeredBall && c.gameObject.name == "Player")
        {
            triggeredBall = true;
            deathBall.rigidbody.useGravity = true;
            lightActivator.activate();
        }

    }
}
