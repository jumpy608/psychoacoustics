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

    // Timing variables
    [SerializeField] float bpm = 0f;
    [SerializeField] float levelStartOffset = 0f; // How long to wait in sec to start the level
    [SerializeField] float beatsShownInAdvance = 3f; // How many beats to spawn a note in advance of it reaching the hit circle
    [SerializeField] float songOffset = 0f; // How long in sec to pre-emptivley play song in order to account for silence at beginning of song
    private float songStartDspTime = 0f;
    private float songPosition = 0f; // Time in dspTime since song has started
    private float secPerBeat = 0f;
    private float songPositionInBeats = 0f;
    int nextBeatIndex = 0; // Index of next beat to be played
    float beatOffset = 4f; // How long to delay beat timings. Song must play this many "empty" beats so first beat doesn't instantly spawn on hit circle.

    // Note circle variables
    [SerializeField] GameObject noteCircle;
    float noteSpawnX = 0;
    float noteSpawnY = 6;

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
        StartCoroutine(WaitThenSpawnBeats());
    }

    // Name: WaitThenSpawnBeats coroutine
    // Programmer: Konrad Kahnert
    // Date: 10/23/2022
    // Description: Wait for a bit, then start spawning beats

    IEnumerator WaitThenSpawnBeats()
    {
        float currentDspTime = (float)AudioSettings.dspTime;
        float offsetDspTime = currentDspTime + levelStartOffset;

        // Wait
        while (currentDspTime < offsetDspTime)
        {
            currentDspTime = (float)AudioSettings.dspTime;
            yield return null;
        }

        songStartDspTime = (float)AudioSettings.dspTime; // Set song start time
        StartCoroutine(CheckBeats()); // Start consuming beats
        StartCoroutine(WaitThenPlaySong());
    }

    // Name: WaitThenPlaySong coroutine
    // Programmer: Konrad Kahnert
    // Date: 10/23/2022
    // Description: Delays the playing of the song so it starts right when the first beat happens.
    IEnumerator WaitThenPlaySong()
    {
        float currentDspTime = (float)AudioSettings.dspTime;
        float offsetDspTime = currentDspTime + beatOffset * secPerBeat - songOffset;

        // Wait
        while (currentDspTime < offsetDspTime)
        {
            currentDspTime = (float)AudioSettings.dspTime;
            yield return null;
        }

        AudioManager.instance.PlaySound("Ana Ng"); // Play song
    }

    // Name: SpawnNoteCircle function
    // Programmer: Konrad Kahnert
    // Date: 10/21/2022
    // Description: Spawns a note circle and sets its target beat.
    // Precondition: The beat when the note circle should align with the hit circle.
    void SpawnNoteCircle(float targetBeat)
    {
        GameObject noteInst = Instantiate(noteCircle);
        noteInst.transform.position = new Vector2(noteSpawnX, noteSpawnY);
        noteInst.GetComponent<NoteCircle>().SetTargetBeat(targetBeat);
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
                if (songPositionInBeats + beatsShownInAdvance >= Beats.instance.GetBeatAt(nextBeatIndex) + beatOffset) // Check if beat time has been reached
                {
                    SpawnNoteCircle(Beats.instance.GetBeatAt(nextBeatIndex) + beatOffset);
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

    // Name: GetBeatsShownInAdvance
    // Programmer: Konrad Kahnert
    // Date: 10/21/2022
    // Description: Returns beatsShownInAdvance
    // Postcondition: beatsShownInAdvance
    public float GetBeatsShownInAdvance()
    {
        return (beatsShownInAdvance);
    }
}
