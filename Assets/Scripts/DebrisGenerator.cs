using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DebrisGenerator : MonoBehaviour {


	public List<Texture2D> textures;
	public GameObject debrisObject;
	public float generationFrequency;

	private float timer;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		generationFrequency = 1 / System.Math.Abs(gameObject.rigidbody.velocity.x);

		if (timer > generationFrequency)
		{
			timer = 0;

			GameObject obj = (GameObject) GameObject.Instantiate(debrisObject, transform.position + new Vector3(0f, -0.8f, -0.2f), debrisObject.transform.rotation);
			obj.renderer.material.mainTexture = textures[Random.Range(0, textures.Count - 1)];
			obj.GetComponent<DebrisScript>().addToDirection(new Vector3(gameObject.rigidbody.velocity.x * 0.5f, 0, 0));
		}

	}
}
