// Name: AudioManager class
// Programmer: Konrad Kahnert
// Date: 9/22/2022
// Description: This class stores a list of sounds and handles the playing, stopping, and manipulation of these sounds.

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] Sound[] sounds; // List of sounds
    [SerializeField] float gameVolume = 1f;

    // Name: Awake
    // Programmer: Konrad Kahnert
    // Date: 9/22/2022
    // Description: Assigns audiosources to each sound in sounds and sets game volume.
    // Preconditions: none
    // Postconditions: none
    private void Awake()
    {
        // If there is no other instance of this class, assign instance ID to instance. Else, destroy this instance. This assures that there is only one instnace of this script active at a time.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        // Assign audiosources to sounds
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.loop = s.loop;
        }

        // Set game volume
        AudioListener.volume = gameVolume;
    }

    // Name: PlaySound
    // Programmer: Konrad Kahnert
    // Date: 9/22/2022
    // Description: Searches for the specified sound and plays it.
    // Preconditions: Name of sound
    // Postconditions: none
    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.audioSource.Play();
                return;
            }
        }

        Debug.LogError("Sound: " + name + " not found!");
    }

    // Name: StopSound
    // Programmer: Konrad Kahnert
    // Date: 9/22/2022
    // Description: Searches for the specified sound and stops it.
    // Preconditions: Name of sound
    // Postconditions: none
    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.audioSource.Stop();
                return;
            }
        }

        Debug.LogError("Sound: " + name + " not found!");
    }

    // Name: IsSoundPlaying
    // Programmer: Konrad Kahnert
    // Date: 9/22/2022
    // Description: Searches for the specified sound and returns whether or not it is currently playing.
    // Preconditions: Name of sound
    // Postconditions: Bool
    public bool IsSoundPlaying(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                return (s.audioSource.isPlaying);
            }
        }

        Debug.LogError("Sound: " + name + " not found!");
        return (false);
    }
}
