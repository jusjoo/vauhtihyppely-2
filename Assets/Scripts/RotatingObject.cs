using UnityEngine;
using System.Collections;

public class RotatingObject : MonoBehaviour
{
	
	public float rotateSpeedY = 60f;
	
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		
		gameObject.transform.Rotate( new Vector3(0f, rotateSpeedY*Time.deltaTime, 0f) );
	}
}
