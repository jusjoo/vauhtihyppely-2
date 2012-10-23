using UnityEngine;
using System.Collections;

public class AnimationStateHandler : MonoBehaviour {

	public float runVelocity;

	public GameObject jumpEffect;

	private SpriteAnimator animator;
	private Rigidbody body;
	private bool jumping;
    private bool flipped;
	

	// Use this for initialization
	void Start () {

		animator = this.GetComponent<SpriteAnimator>();
		body = this.GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (jumping)
		{

			if (body.velocity.y >= -2)
			{
				animator.setAnimationState(SpriteAnimator.AnimationState.Jump);
			}
			else
			{
				animator.setAnimationState(SpriteAnimator.AnimationState.Fall);
			}
		}
		else
		{

			if (body.velocity.x < runVelocity && body.velocity.x > -runVelocity)
			{
				animator.setAnimationState(SpriteAnimator.AnimationState.Idle);
			}
			else
			{
				animator.setAnimationState(SpriteAnimator.AnimationState.Run);
			}
			
		}
	}


	public void activateJumpAnimation() {

		if (jumping == false)
		{
			GameObject.Instantiate(jumpEffect, this.transform.position - new Vector3(0f,1f,0f), jumpEffect.transform.rotation);
		}

		jumping = true;
		
	}
	public void deactivateJumpAnimation()
	{
		jumping = false;
	}

    internal void flip(bool b)
    {
        animator.flip(b);
    }
}
