using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioMaanager : MonoBehaviour {
    public Sound[] sounds;
	// Use this for initialization
	void Awake () {
	foreach(Sound s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }	
	}
	
	// Update is called once per frame
	public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name==name );
        s.source.Play();
        if (s == null)
        {
            Debug.LogWarning("Sound :" + name + " not found");
        }
    }
}
