using UnityEngine;
using System.Collections;

public class PowerUpColorFade : MonoBehaviour {

    private float fadeTimer;
    private float fader;
    private Color fadeStart;
    private Color fadeEnd;
    private Transform target;

	// Use this for initialization
	void Start () {

        fadeStart = Color.red;
        fadeEnd = Color.clear;
        fadeTimer = 2.0f;
        target.position = new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
       fadeCollectedItem();
       //transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * fadeTimer);
	}

    public void fadeCollectedItem(){

        if (renderer.material.color.a <= 0)
        {
            destroyPowerUpText();
        }
        else
        {
            renderer.material.color -= new Color(0, 0, 0, 0.01f);
        }

	}

    public void destroyPowerUpText()
    {
        Destroy(this.gameObject);
    }
}
