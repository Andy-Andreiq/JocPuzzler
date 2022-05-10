using UnityEngine.Audio;
using UnityEngine;
[System.Serializable] //Pentru a aparea in unity
//nume script
public class Sound
{
    //seteaza un nume de tip string si gaseste clipul cu numele respectiv
    public string name;
    public AudioClip clip;

    [Range(0f,1f)] //Sliders pt volum
    public float volume;
    [Range(.1f, 3f)]
    public float pitch; //Sliders pt pitch

    public bool loop;

[HideInInspector] //Nu apare in inspector
    public AudioSource source;

}