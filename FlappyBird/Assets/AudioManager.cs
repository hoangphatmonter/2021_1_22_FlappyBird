using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        // Similar to Singleton pattern
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // create a scene that this instance was in it
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            // initial new AudioSource object to source
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);
        if (s == null) Debug.LogWarning("Sound: " + name + " not found!");
        s.source.Play();
    }
}
