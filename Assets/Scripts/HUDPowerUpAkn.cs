using UnityEngine;
using System.Collections;

public class HUDPowerUpAkn : MonoBehaviour {

	public Component powerUpItem;
	private GUITexture gText;
	private PowerUpTemplate pUTemp;
	private float fadeTime;
	// Use this for initialization
	void Start () {

		gText = this.GetComponent<GUITexture>();
		pUTemp = powerUpItem.GetComponent<PowerUpTemplate>();
		fadeTime = 3.0f;

	}
	
	// Update is called once per frame
	void Update () {

		if (pUTemp.getItemCollected() == true)
		{
			gText.color = new Color(1, 1, 1, 1);
			fadePowerUpItem();
			
		}
	
	}
	void fadePowerUpItem()
	{
		pUTemp.setItemCollected(false);
		float fader = 1.0f;

		while(fadeTime >= 0.0f){
			gText.color = new Color(1, 1, 1, 0);
			fadeTime -= Time.deltaTime;
			fader -= 0.5f;
		}
	}
}
