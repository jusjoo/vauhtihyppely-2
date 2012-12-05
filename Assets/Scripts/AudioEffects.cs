using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioEffects : MonoBehaviour {

    public List<string> keys;
    public List<AudioClip> values;

    private Dictionary<string, AudioClip> clips;

    private List<AudioSource> sources;

	// Use this for initialization
	void Start () {

        clips = new Dictionary<string, AudioClip>();

        for (int i = 0; i < keys.Count; i++)
        {
            clips.Add(keys[i], values[i]);
        }

        sources = new List<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        foreach (AudioSource a in sources)
        {
            if (!a.isPlaying)
            {
                sources.Remove(a);
                Destroy(a);
                break;
            }
        }
	}

    public void play(string name) {
        sources.Add(gameObject.AddComponent<AudioSource>());
        AudioClip audioClip;
        clips.TryGetValue(name, out audioClip);

        audio.clip = audioClip;
        audio.Play();
    }
}
