using UnityEngine;
using System.Collections;

public class ExitSignTrigger : MonoBehaviour {

	public LightActivator light;

	private bool triggered;
	// Use this for initialization
	void Start () {
		light.deactivate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (!triggered && c.gameObject.name == "Player")
		{
			triggered = true;
			light.activate();
		}
	}
}
