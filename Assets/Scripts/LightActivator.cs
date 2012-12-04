using UnityEngine;
using System.Collections;

public class LightActivator : MonoBehaviour {

    public bool instantActivation;

    private bool activated;
    private float timer;
	// Use this for initialization
	void Start () {
        activated = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (activated)
        {
            timer += Time.deltaTime;

            if (timer >= 0 && timer < 0.1f)
            {
                gameObject.GetComponent<Light>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Light>().enabled = false;
            }

            if (timer > 0.6f && timer < 0.7f)
            {
                gameObject.GetComponent<Light>().enabled = true;
            }
            else
            {
                gameObject.GetComponent<Light>().enabled = false;
            }

            if (timer > 1)
            {
                gameObject.GetComponent<Light>().enabled = true;
                activated = false;
            }
        }
	}

    public void activate()
    {
        if (instantActivation)
        {
            gameObject.GetComponent<Light>().enabled = true;
        }
        else
        {
            timer = 0;
            activated = true;
        }
        
    }

    public void deactivate()
    {
        gameObject.GetComponent<Light>().enabled = false;
    }
}
