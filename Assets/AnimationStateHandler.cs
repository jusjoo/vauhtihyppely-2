using UnityEngine;
using System.Collections;

public class AnimationStateHandler : MonoBehaviour {

	public float runVelocity;

	private SpriteAnimator animator;
	private Rigidbody body;

	// Use this for initialization
	void Start () {

		animator = this.GetComponent<SpriteAnimator>();
		body = this.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (body.velocity.x < runVelocity)
		{
			animator.setAnimationState(SpriteAnimator.AnimationState.Idle);
		}
		else
		{
			animator.setAnimationState(SpriteAnimator.AnimationState.Run);
		}
	}
}
