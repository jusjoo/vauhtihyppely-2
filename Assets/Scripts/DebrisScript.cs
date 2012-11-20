using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour {

	public float lifeTime;

	private float movementAmount = 3f;
	private float timer;
	private Vector3 rndDirection;

	// Use this for initialization
	void Start () {
		rndDirection += new Vector3(Random.Range(-movementAmount, movementAmount), Random.Range(0, movementAmount), 0);
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		transform.position += rndDirection * Time.deltaTime;

		renderer.material.color -= new Color(0, 0, 0, 0.02f);



		if (timer > lifeTime)
		{
			GameObject.Destroy(gameObject);
		}
	}

	public void addToDirection(Vector3 vector) {

		rndDirection += vector;
	}
}
