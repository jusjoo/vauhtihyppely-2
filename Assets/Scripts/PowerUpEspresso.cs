using UnityEngine;
using System.Collections;

public class PowerUpEspresso : PowerUpTemplate {

	private bool itemCollected;
	private float fader;
	private float fadeTimer;

	// Use this for initialization
	public override void Start () {

		itemCollected = false;

	}
	
	// Update is called once per frame
	public override void Update () {
		if (getItemCollected() == true)
		{
			showCollectedItem();
		}

	}

    public override void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
			setItemCollected(true);
			GameObject.Instantiate(showPU, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
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
	public void showCollectedItem()
	{
		fadeTimer -= Time.deltaTime;
		fader -= 0.2f;
	
	}



}
