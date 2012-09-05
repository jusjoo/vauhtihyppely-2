using UnityEngine;
using System.Collections;

public class HUDJumpBooster : MonoBehaviour {

	public Component playerCharacter;
	public Color color;
	// a float between 0.0 and 1.0
	private float jumpBoost;
	private CharacterControl control;
	
	

	// Use this for initialization
	void Start () {

		control = playerCharacter.GetComponent<CharacterControl>();
		//color = this.GUI.Texture.color;

	}
	
	// Update is called once per frame
	void Update () {

		jumpBoost = control.getJumpTime();
		color = Color.Lerp(Color.green, Color.red, 0.5f);
	
	}
}
