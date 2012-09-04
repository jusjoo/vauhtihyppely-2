using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {
	
	public Transform objectToFollow;
	
	private Vector3 targetOffset;
	// Use this for initialization
	void Start () {
	
		targetOffset = this.transform.position - objectToFollow.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
			
		this.transform.position = objectToFollow.transform.position + targetOffset;
	}
}
