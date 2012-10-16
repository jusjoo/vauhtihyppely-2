using UnityEngine;
using System.Collections;

public class PowerUpEspresso : PowerUpTemplate {

	private bool itemCollected;

	// Use this for initialization
	public override void Start () {

		itemCollected = false;

	}
	
	// Update is called once per frame
	public override void Update () {
	
	}

    public override void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
            Destroy(gameObject);
			setItemCollected(true);
        }
    }

    public override void setItemCollected(bool set)
    {
		itemCollected = set;
    }
	public override bool getItemCollected()
	{
		return itemCollected;
	}



}
