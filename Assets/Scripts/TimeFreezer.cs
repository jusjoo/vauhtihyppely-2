using UnityEngine;
using System.Collections;

public class TimeFreezer : MonoBehaviour {

    public float timeScale = 0.001f;
    public GameObject screenDarkener;
	
	
    private GameObject darkenInstance;
	// Use this for initialization
	
	void Start () {
        Time.timeScale = timeScale;
		
		darkenInstance = (GameObject)GameObject.Instantiate(screenDarkener);
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            GameObject.DestroyObject(darkenInstance);
            GameObject.DestroyObject(this.gameObject);
        }
	}


}
