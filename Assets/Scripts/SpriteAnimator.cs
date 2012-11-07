using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteAnimator : MonoBehaviour {

	public List<Texture2D> idleTextures;
	public float idleFrameLength;
	
	public List<Texture2D> runTextures;
	public float runFrameLength;

	public List<Texture2D> jumpTextures;
	public float jumpAnimationLength;

	public List<Texture2D> fallTextures;
	public float fallFrameLength;

	// time spent in current animation state
	private float animationStateTime;
	private AnimationState currentAnimation;

    // will the sprite be flipped
    private bool flipped;
	
	/* Factor of 0..1 how fast the player is runnings */
	private float runFactor;
	
	public enum AnimationState { Idle, Run, Jump, Fall }

	

	// Use this for initialization
	void Start () {
		runFactor=0;
		setAnimationState(AnimationState.Idle);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentAnimation == AnimationState.Run)
		{
			animationStateTime += Time.deltaTime*runFactor;
		} else {
			animationStateTime += Time.deltaTime;
		}
		


        if (flipped)
        {
            
            if (transform.localScale.z > 0)
            {
 
                transform.localScale += new Vector3(0, 0, -transform.localScale.z*2);
            }
        }
       else
        {
            if (transform.localScale.z < 0)
            {
				transform.localScale += new Vector3(0, 0, -transform.localScale.z * 2);
            }
        }


		if (currentAnimation == AnimationState.Run)
		{
			checkLoop(runFrameLength * runTextures.Count);
			Debug.Log( (int)Mathf.Floor((animationStateTime) / runFrameLength) );
			this.renderer.material.mainTexture = runTextures[(int)Mathf.Floor((animationStateTime) / runFrameLength)];
	
		} else if ( currentAnimation == AnimationState.Idle )
		{
			checkLoop(idleFrameLength * idleTextures.Count);
			this.renderer.material.mainTexture = idleTextures[(int)Mathf.Floor(animationStateTime / idleFrameLength)];				

		} else if (currentAnimation == AnimationState.Jump)
		{
			checkLoop(jumpAnimationLength * jumpTextures.Count);
			this.renderer.material.mainTexture = jumpTextures[(int)Mathf.Floor((animationStateTime / jumpTextures.Count) / jumpAnimationLength)];
		
		} else if (currentAnimation == AnimationState.Fall)
		{
			checkLoop(fallFrameLength * fallTextures.Count);
			this.renderer.material.mainTexture = fallTextures[(int)Mathf.Floor(animationStateTime / fallFrameLength)];

		} else {
			// This shouldn't happen
			Debug.Log("ERROR - else animation!");
		}

	}

	// check if the animation is complete, restart the loop
	private void checkLoop(float loopLength) {
		if (animationStateTime > loopLength)
		{
			animationStateTime = 0;
		}
	}

	// set current animation and restart if it's a different animation
	public void setAnimationState(AnimationState animation)
	{
		if (currentAnimation != animation)
		{
			currentAnimation = animation;
			animationStateTime = 0;
		}
	}


    internal void flip(bool b)
    {
        
        this.flipped = b;
    }
	
	public void setRunFactor(float factor) 
	{
		runFactor = Mathf.Abs( factor );
	}
}
