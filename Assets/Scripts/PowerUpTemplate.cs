using UnityEngine;
using System.Collections;

public abstract class PowerUpTemplate : MonoBehaviour {

	public GameObject showPU;
	// Use this for initialization
    public abstract void Start();

	// Update is called once per frame
    public abstract void Update();

    public abstract void OnTriggerEnter(Collider c);

    public abstract void setItemCollected(bool set);

	public abstract bool getItemCollected();
}
