using UnityEngine;
using System.Collections;

public class AnimationStateHandler : MonoBehaviour {

	public float runVelocity;
	

	private SpriteAnimator animator;
	private Rigidbody body;
	private bool jumping;
	private bool boosting;
	

	// Use this for initialization
	void Start () {

		animator = this.GetComponent<SpriteAnimator>();
		body = this.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (jumping)
		{
			animator.setAnimationState(SpriteAnimator.AnimationState.Jump);
		}
		else
		{
			if (boosting)
			{

			}
			else
			{
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
	}


	public void activateJumpAnimation() {
		jumping = true;
	}
	public void deactivateJumpAnimation()
	{
		jumping = false;
	}
	public void activateBoostAnimation()
	{
		boosting = true;
	}
	public void deactivateBoostAnimation()
	{
		boosting = false;
	}

}