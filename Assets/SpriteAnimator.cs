using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteAnimator : MonoBehaviour {

	public List<Texture2D> runTextures;
	public float runFrameLength;


	// time spent in current animation state
	private float animationStateTime;
	private AnimationState currentAnimation;

	public enum AnimationState { Idle, Run, Jump, Boost }

	

	// Use this for initialization
	void Start () {
		setAnimationState(AnimationState.Run);
	}
	
	// Update is called once per frame
	void Update () {

		animationStateTime += Time.deltaTime;


		if (currentAnimation == AnimationState.Run)
		{
			// if the animation is complete, restart the loop
			if (animationStateTime > runFrameLength * runTextures.Count)
			{
				animationStateTime = 0;
			}

			this.renderer.material.mainTexture = runTextures[(int)Mathf.Floor(animationStateTime / runFrameLength)];
		}

		if (currentAnimation == AnimationState.Idle)
		{
			this.renderer.material.mainTexture = runTextures[1];
		}
	}

	public void setAnimationState(AnimationState animation)
	{
		currentAnimation = animation;
	}

}
