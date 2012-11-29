using UnityEngine;
using System.Collections;

public class TimedSelfDestroyer : MonoBehaviour {

    public float timeToShow = 3.0f;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		timeToShow -= Time.deltaTime;
		Debug.Log (timeToShow);
        if ( timeToShow < 0 )
        {
            GameObject.DestroyObject(this.gameObject);
        }
	}


}
