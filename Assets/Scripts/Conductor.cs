// Name: Controller Class
// Programmer: Konrad Kahnert
// Date: 9/23/2022
// Description: This class handles song timing and note spawning. Note: DSP time is the time system used in Unity based on audio samples. DSP time must be used instead of regular Unity time for music syncing
// or else the notes will not be synced correctly.

using UnityEngine;
using System.Collections;

public class Conductor : MonoBehaviour
{
    public static Conductor instance;
    [SerializeField] TextAsset beatMap; // Text file containing beatmap
    [SerializeField] GameObject flasher;

    // Timing variables
    [SerializeField] float bpm = 0f;
    [SerializeField] float songOffset = 0f; // How long to wait in sec to start the song
    [SerializeField] float beatOffset = 0f; // How many beats to delay the beat timings
    private float songStartDspTime = 0f;
    private float songPosition = 0f; // Time in dspTime since song has started
    private float secPerBeat = 0f;
    private float songPositionInBeats = 0f;
    int nextBeatIndex = 0; // Index of next beat to be played

    // Name: Start function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Sets instance and secPerBeat, loads beat map, then calls WaitThenPlaySong
    void Start()
    {
        // Set instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this); // Destroy instance if another instance exists
            return;
        }

        if (bpm > 0)
        {
            secPerBeat = 60 / bpm;
        }
        else
        {
            Debug.LogError("BPM must be greater than zero!");
        }

        Beats.instance.LoadBeatMap(beatMap);
        StartCoroutine(WaitThenPlaySong());
    }

    // Name: WaitThenPlaySong coroutine
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Plays the song after a delay specified by songOffset.

    IEnumerator WaitThenPlaySong()
    {
        float currentDspTime = (float)AudioSettings.dspTime;
        float offsetDspTime = currentDspTime + songOffset;

        // Wait
        while (currentDspTime < offsetDspTime)
        {
            currentDspTime = (float)AudioSettings.dspTime;
            yield return null;
        }

        AudioManager.instance.PlaySound("Ana Ng"); // Play song
        songStartDspTime = (float)AudioSettings.dspTime; // Set song start time
        StartCoroutine(CheckBeats()); // Start consuming beats
    }

    // Name: CheckBeats coroutine
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Checks beat time of next note to be played and if the beat time matches the current song position, flash and increment next beat index
    IEnumerator CheckBeats()
    {
        while (true)
        {
            // Get song position
            songPosition = (float)AudioSettings.dspTime - songStartDspTime;
            songPositionInBeats = songPosition / secPerBeat;

            if (nextBeatIndex < Beats.instance.GetTotalBeats()) // If there are still notes left to play
            {
                if (songPositionInBeats >= Beats.instance.GetBeatAt(nextBeatIndex) + beatOffset) // Check if beat time has been reached
                {
                    flasher.GetComponent<Flasher>().Flash(); // Flash
                    nextBeatIndex++;
                }
            }

            yield return null;
        }
    }

    // Name: GetSongPositionInBeats function
    // Programmer: Konrad Kahnert
    // Date: 10/10/2022
    // Description: Returns songPositionInBeats
    // Postcondition: songPositionInBeats
    public float GetSongPositionInBeats()
    {
        return (songPositionInBeats);
    }

    // Name: GetSongPosition function
    // Programmer: Konrad Kahnert
    // Date: 10/10/2022
    // Description: Returns songPosition
    // Postcondition: songPosition
    public float GetSongPosition()
    {
        return (songPosition);
    }

    // Name: GetSecPerBeat function
    // Programmer: Konrad Kahnert
    // Date: 10/10/2022
    // Description: Returns secPerBeat
    // Postcondition: secPerBeat
    public float GetSecPerBeat()
    {
        return (secPerBeat);
    }

    // Name: GetBeatOffset
    // Programmer: Konrad Kahnert
    // Date: 10/10/2022
    // Description: Returns beat offset
    // Postcondition: beat offset
    public float GetBeatOffset()
    {
        return (beatOffset);
    }
}
