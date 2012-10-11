using UnityEngine;
using System.Collections;

public class PowerUpEspresso : PowerUpTemplate {

    public Texture espressoText;
	// Use this for initialization
	public override void Start () {
        
	}
	
	// Update is called once per frame
	public override void Update () {
	
	}

    public override void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
            Destroy(gameObject);
            powerUpOn();
        }
    }

    public override void powerUpOn()
    {
        Graphics.DrawTexture(new Rect(10, 10, 600, 600), espressoText); // ?????
    }


}
