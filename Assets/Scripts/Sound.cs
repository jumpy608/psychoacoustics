// Name: Sound Class
// Programmer: Konrad Kahnert
// Date: 9/22/2022
// Description: This class holds an AudioClip and an accompanying AudioSource.

using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector] public AudioSource audioSource;
    public bool loop; // Whether or not this sound should loop

    [Range(0f, 1f)] public float volume;
}
