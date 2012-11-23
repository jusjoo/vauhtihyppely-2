using UnityEngine;
using System.Collections;

[RequireComponent(typeof(VectorCharacterControl))]
	
public class TimeFreezer : MonoBehaviour {

    public float timeScale = 0.001f;
    public GameObject screenDarkener;
	
	public float messageShowTimeLeft = 0.5f; // random time unit??
	
    private GameObject darkenInstance;
	// Use this for initialization
	
	private VectorCharacterControl vectorCharacterControl;
	
	void Start () {
        Time.timeScale = timeScale;
		
		// Because time really moves slowly after setting the timescale,
		// even the wait time need to be adjusted.
		// No idea how this should be done.....
		messageShowTimeLeft = messageShowTimeLeft*timeScale*5f;

		darkenInstance = (GameObject)GameObject.Instantiate(screenDarkener);
		vectorCharacterControl = this.GetComponent<VectorCharacterControl>();
		vectorCharacterControl.freezeControls();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("time" + messageShowTimeLeft);
		
		if ( messageShowTimeLeft < 0 ) {
	        if (Input.anyKeyDown)
	        {
	            Time.timeScale = 1;
	            GameObject.DestroyObject(darkenInstance);
	            GameObject.DestroyObject(this.gameObject);
	        	vectorCharacterControl.unfreezeControls();
	        }
		} else {
			messageShowTimeLeft -= Time.deltaTime;
		}
	}


}
