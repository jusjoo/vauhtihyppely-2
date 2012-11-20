using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpStateHandler : MonoBehaviour {

	private float powerUpTimer;
	private List<string> powerUps;

	// Use this for initialization
	void Start () {
		powerUps = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void activatePowerUp(string type){
		powerUps.Clear();
		powerUps.Add(type);
	}

	public bool isPowerUpOn(string type){
		return (powerUps.Contains(type));
	}
}
