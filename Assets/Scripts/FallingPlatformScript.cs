using UnityEngine;
using System.Collections;

public class FallingPlatformScript : MonoBehaviour {


	public float fallAfterTime;
	private float fallTimer;

	private bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (triggered)
		{
			if (fallTimer > 0)
			{
				fallTimer -= Time.deltaTime;
			}
			else
			{
				
				gameObject.GetComponent<Rigidbody>().useGravity = true;
				gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
					| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			}

		}

	}

	void OnCollisionEnter(Collision c)
	{
		if (!triggered && c.gameObject.name == "Player")
		{
			triggered = true;
			fallTimer = fallAfterTime;
		}

	}
}