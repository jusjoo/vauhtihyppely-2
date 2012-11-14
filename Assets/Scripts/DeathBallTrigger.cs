using UnityEngine;
using System.Collections;

public class DeathBallTrigger : MonoBehaviour
{

    private GameObject deathBall;
  
    private bool triggeredBall;

    public float deathBallSpeed = 0.05f;

    // Use this for initialization
    void Start()
    {
        deathBall = GameObject.Find("deathBall");
        //timeToMove = 0; // in seconds
        triggeredBall = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (triggeredBall)
        {
            // Move the door
            deathBall.transform.position += new Vector3(deathBallSpeed, 0.0f, 0f);
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
