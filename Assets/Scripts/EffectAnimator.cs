using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectAnimator : MonoBehaviour {

	public List<Texture2D> textures;
	public float frameLength;

	private float animationTimer;

	// Use this for initialization
	void Start () {
		animationTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		animationTimer += Time.deltaTime;

		if (animationTimer <= frameLength * textures.Count)
		{
			this.renderer.material.mainTexture = textures[(int)Mathf.Floor(animationTimer / frameLength)];
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
