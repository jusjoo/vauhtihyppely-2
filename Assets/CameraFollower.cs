using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {
	
	public Transform objectToFollow;
	
	private Vector3 targetOffset;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {

        rigidbody = objectToFollow.GetComponent<Rigidbody>();
		targetOffset = this.transform.position - objectToFollow.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 currentOffset = this.transform.position - objectToFollow.transform.position;

        Vector3 velocityOffset = new Vector3(rigidbody.velocity.x, 0, -Mathf.Abs(rigidbody.velocity.x * 0.5f) - 5);

        Vector3 realTargetOffset = targetOffset + velocityOffset;

		this.transform.position = objectToFollow.transform.position + realTargetOffset;

	}
}
