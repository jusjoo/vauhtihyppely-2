using UnityEngine;
using System.Collections;

public class PowerUpEspresso : PowerUpTemplate {


	
	private float fader;
	private float fadeTimer;
	private bool setToDestroy;

	
	// Update is called once per frame
	public override void Update () {

		if (setToDestroy == true)
		{
			setToDestroy = false;
			Destroy(gameObject);
		}
	}

    public override void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
			setItemCollected(true);
			GameObject.Instantiate(showPU, new Vector3(this.transform.position.x, this.transform.position.y+2, this.transform.position.z), showPU.transform.rotation);
			setToDestroy = true;
			powerUpStateHandler.activatePowerUp("DoubleJump");
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
