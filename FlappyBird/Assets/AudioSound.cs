using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

//this class must not be inherited "MonoBehavior" to make all attributes in custom class visible to inspector
[System.Serializable]   // to make this class visible to the inspector
public class Sound
{
    
    public string soundName;

    [SerializeField]
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
