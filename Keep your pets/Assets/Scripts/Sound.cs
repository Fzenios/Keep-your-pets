using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;
    
    [HideInInspector]
    public AudioSource source;

}
