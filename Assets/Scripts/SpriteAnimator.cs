using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteAnimator : MonoBehaviour {

	public List<Texture2D> runTextures;
	public float runFrameLength;

	public List<Texture2D> boostTextures;
	public float boostAnimationLength;

	public List<Texture2D> jumpTextures;
	public float jumpAnimationLength;

	// time spent in current animation state
	private float animationStateTime;
	private AnimationState currentAnimation;

    // will the sprite be flipped
    private bool flipped;

	public enum AnimationState { Idle, Run, Jump, Boost }

	

	// Use this for initialization
	void Start () {
		setAnimationState(AnimationState.Run);
	}
	
	// Update is called once per frame
	void Update () {

		animationStateTime += Time.deltaTime;

        if (flipped)
        {
            
        }

		if (currentAnimation == AnimationState.Run)
		{
			checkLoop(runFrameLength * runTextures.Count);
			this.renderer.material.mainTexture = runTextures[(int)Mathf.Floor(animationStateTime / runFrameLength)];
		}

		if (currentAnimation == AnimationState.Idle)
		{
			this.renderer.material.mainTexture = runTextures[0];
		}

		if (currentAnimation == AnimationState.Jump)
		{
			this.renderer.material.mainTexture = jumpTextures[(int)Mathf.Floor(animationStateTime / jumpTextures.Count / jumpAnimationLength)];
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
}
