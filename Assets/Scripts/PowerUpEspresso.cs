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
			fadeCollectedItem();
		}

	}

    public override void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
			setItemCollected(true);
			GameObject.Instantiate(showPU, this.transform.position, showPU.transform.rotation);
			Destroy(gameObject);
			fadeCollectedItem();
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
	public void fadeCollectedItem()
	{
		Debug.Log("DOPPIOO");
		renderer.material.SetColor("_Color", Color.green);
		fadeTimer -= Time.deltaTime;
		fader -= 0.2f;
	
	}



}
