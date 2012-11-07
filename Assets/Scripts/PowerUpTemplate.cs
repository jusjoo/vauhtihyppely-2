using UnityEngine;
using System.Collections;

public abstract class PowerUpTemplate : MonoBehaviour {

	public GameObject showPU;
	protected PowerUpStateHandler powerUpStateHandler;
	protected bool itemCollected;

	// Use this for initialization
	void Start()
	{
		powerUpStateHandler = GameObject.Find("Player").GetComponent<PowerUpStateHandler>();
		itemCollected = false;
	}
	// Update is called once per frame
    public abstract void Update();

    public abstract void OnTriggerEnter(Collider c);

    public abstract void setItemCollected(bool set);

	public abstract bool getItemCollected();
}
