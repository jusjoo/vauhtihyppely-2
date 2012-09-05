using UnityEngine;
using System.Collections;

public class GUIJumpBooster : MonoBehaviour {
	
		// background image that is 256 x 32
	public Texture2D bgImage; 

	// foreground image that is 256 x 32
	public Texture2D fgImage; 

	// a float between 0.0 and 1.0
	public float jumpBoost;
	
	private CharacterControl control;
	
	void OnGUI () {
		
		control = this.GetComponent<CharacterControl>();
		
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0,256,32));

		// Draw the background image
		GUI.Box (new Rect (0,0,200,32), bgImage);

			// Create a second Group which will be clipped
			// We want to clip the image and not scale it, which is why we need the second Group
			jumpBoost = control.getJumpTime();
			GUI.BeginGroup (new Rect (0,0,(jumpBoost-control.minJumpTime) * 256, 32));

			// Draw the foreground image
			GUI.Box (new Rect (0,0,200,32), fgImage);

			// End both Groups
			GUI.EndGroup ();

		GUI.EndGroup ();

		
		
	}
}
