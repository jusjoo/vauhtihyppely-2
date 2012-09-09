using UnityEngine;
using System.Collections;

public class StatsHandler : MonoBehaviour {

    private float caffeine;


	// Use this for initialization
	void Start () {
        caffeine = 1; //Temporary test setup!

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getCaffeine() {
        return caffeine;
    }
    public void setCaffeine(float caffeine) { 

    }
}
