using UnityEngine;
using System.Collections;

public class FallingPlatformScript : MonoBehaviour {


	public float fallAfterTime;
    public float destroyAfterTime = 3;
	private float fallTimer;
    private float destroyTimer;

	private bool triggered;

	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (triggered)
		{

            fallTimer -= Time.deltaTime;
            destroyTimer -= Time.deltaTime;
			
            if (fallTimer < 0)
			{
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
                    | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			}
			
            if (destroyTimer < 0)
            {
                Destroy(gameObject);
            }

		}

	}

	void OnCollisionEnter(Collision c)
	{
		if ( !triggered
			&& c.gameObject.name == "Player" 
			&& c.transform.position.y > gameObject.transform.position.y )
		{
			triggered = true;
			fallTimer = fallAfterTime;
            destroyTimer = destroyAfterTime;

			Material glassMaterial = Resources.Load("Glass", typeof(Material)) as Material;
			renderer.material = glassMaterial;
			renderer.material.shader = Shader.Find("Transparent/Diffuse");


		}

	}
}
