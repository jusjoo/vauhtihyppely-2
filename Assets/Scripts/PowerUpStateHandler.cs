using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpStateHandler : MonoBehaviour {

	private float powerUpTimer;
	private List<string> powerUps;

	// Use this for initialization
	void Start () {
		powerUps = new List<string>();
		Time.timeScale = 1; //Just that black coffee powerup doesn't stay on
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void activatePowerUp(string type){

		// Only add a certain powerup once
		if ( isPowerUpOn(type) )
			return;
		
		if ( type == "KillIrishCoffee" )
			removePowerUp("IrishCoffee");
		else
			powerUps.Add(type);
	}

	public bool isPowerUpOn(string type){
		return (powerUps.Contains(type));
	}
	
	public void removePowerUp(string type) {
		powerUps.Remove(type);	
	}
}
