using UnityEngine;
using System.Collections;

public class HUDJumpBooster : MonoBehaviour {

	public Component playerCharacter;


	// a float between 0.0 and 1.0
	private float jumpBoost;
	private CharacterControl control;
    private GUITexture guiText;
    private bool jumpingDone;

	

	// Use this for initialization
	void Start () {

		control = playerCharacter.GetComponent<CharacterControl>();
        guiText = this.GetComponent<GUITexture>();

	}
	
	// Update is called once per frame
	void Update () {


        if (jumpingDone != true)
        {
            jumpBoost = control.getJumpTime();
            guiText.color = Color.Lerp(Color.green, Color.red, (jumpBoost - control.minJumpTime));
            guiText.pixelInset = new Rect(-90, 19, (jumpBoost - control.minJumpTime) * 200, 18);
        }

        else
        {
            guiText.color -= new Color(0, 0, 0, 0.1f);
            if (guiText.color.a <= 0)
            {
                guiText.color = Color.clear;
                jumpBoost = 0;
                jumpingDone = false;
            }
        }
       

	}

    public void setJumpingDone(bool done){
        jumpingDone = done;
    }
}
