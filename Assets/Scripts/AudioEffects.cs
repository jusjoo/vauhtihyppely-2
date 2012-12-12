using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioEffects : MonoBehaviour {

    public List<string> keys;
    public List<AudioClip> values;

    private static Dictionary<string, AudioClip> clips;

    private static List<AudioSource> sources;

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

    public static void play(string name)
    {
        AudioSource source = GameObject.Find("AudioEffects").AddComponent<AudioSource>();
        AudioEffects.sources.Add(source);

        AudioClip audioClip;
        clips.TryGetValue(name, out audioClip);

        source.clip = audioClip;
        source.Play();
    }

 
}
