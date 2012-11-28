using UnityEngine;
using System.Collections;

//Used for fading the power up "check" text
public class PowerUpColorFade : MonoBehaviour {

    private float fadeTimer;
    private float fader;
    private Color fadeAmount;

	// Use this for initialization
	void Start () {
  
        fadeTimer = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
       fadeCollectedItem();
       transform.position += new Vector3(0.05f, 0.01f, 0);
	}

    public void fadeCollectedItem(){

        if (renderer.material.color.a <= 0)
        {
            destroyPowerUpText();
        }
        else
        {
            fadeAmount += new Color(0, 0, 0, 0.0001f);
            renderer.material.color -= fadeAmount;
        }

	}

    public void destroyPowerUpText()
    {
        Destroy(this.gameObject);
    }
}
