using UnityEngine;
using System.Collections;

/*
 * TODO:
 * Korjaa hyppymittarin feidaaminen hahmon ollessa ilmassa
 */

public class HUDJumpBooster : MonoBehaviour {

	public Component playerCharacter;
    private CharacterControl control;
    private GUITexture guiText;
	private CharacterMovement movement;

	// a float between 0.0 and 1.0
	private float jumpBoost;
    private bool jumpingDone;

	

	// Use this for initialization
	void Start () {

		control = playerCharacter.GetComponent<CharacterControl>();
        guiText = this.GetComponent<GUITexture>();
		movement = playerCharacter.GetComponent<CharacterMovement>();

	}
	
	// Update is called once per frame
	void Update () {

        //Is the jumping sequence completed?
        if (jumpingDone != true)
        {
            startJumpBoost();
        }

        //It is? Fade the jump meter
        else
        {
            fadeJumpBoostMeter();
        }
	}
	
	public void startJumpBoost(){
		if(movement.getJumpingAllowed() == true){
			jumpBoost = control.getJumpTime();
	        guiText.color = Color.Lerp(Color.green, Color.red, (jumpBoost - control.minJumpTime));
	        guiText.pixelInset = new Rect(-90, 19, (jumpBoost - control.minJumpTime) * 200, 18);
		}
	}
	
	public void fadeJumpBoostMeter(){
		guiText.color -= new Color(0, 0, 0, 0.05f);
        if (guiText.color.a <= 0)
        {
			control.setJumpTime(0);
           	jumpingDone = false;
       	}
	}
	
    public void setJumpingDone(bool done){
        jumpingDone = done;
    }
}
