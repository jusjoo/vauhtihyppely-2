using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioEffects : MonoBehaviour {

    public AudioClip jump;



    private List<AudioSource> sources;

	// Use this for initialization
	void Start () {
        sources = new List<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        foreach (AudioSource a in sources)
        {
            if (!a.isPlaying)
            {
                Destroy(a);
            }
        }
	}

    public void playJump() {
        AudioSource audio = new AudioSource();
        audio.clip = jump;
        audio.Play();
    }
}
