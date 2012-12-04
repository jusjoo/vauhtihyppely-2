using UnityEngine;
using System.Collections;

public class NonMovingKiller : MonoBehaviour
{
	
	public float rotateSpeedY = 60f;
    public GameObject NMK;

	
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		
		NMK.transform.Rotate( new Vector3(0f, rotateSpeedY*Time.deltaTime, 0f) );
	}
}
