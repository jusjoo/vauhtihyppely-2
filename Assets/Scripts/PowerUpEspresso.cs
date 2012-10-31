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

	}

    public override void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player")
        {
			setItemCollected(true);
			GameObject.Instantiate(showPU, new Vector3(this.transform.position.x, this.transform.position.y+2, this.transform.position.z), showPU.transform.rotation);
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

}
