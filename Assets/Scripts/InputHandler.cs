// Name: InputHandler Class
// Programmer: Konrad Kahnert
// Date: 10/10/2022
// Description: This class handles player input and is in charge of letting the player know if they hit or miss a note.

using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    [SerializeField] float leeway = 0f; // Max time difference between when player hits button and actual beat time of note to still register as a hit
    char[] keys = { '1', '2', '3', '4' }; // Keys corresponding to hit circles
    int targetBeatIndex = 0; // Index of beat that player is currently supposed to hit
    bool missed = false; // Whether the target beat has been missed or not

    private void Start()
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
    }

    /*
    // Name: CheckTiming Function
    // Programmer: Konrad Kahnert
    // Date: 10/11/2022
    // Description: This function is called when the player hits the spacebar and does a check to see if the player hit or missed the current note.
    void CheckTiming()
    {
        if (targetBeatIndex < Beats.instance.GetTotalBeats()) // While there are still notes left to play
        {
            float songPosition = Conductor.instance.GetSongPosition();
            float secPerBeat = Conductor.instance.GetSecPerBeat();
            float offset = Conductor.instance.GetBeatOffset() * secPerBeat;
            float targetTime = Beats.instance.GetBeatAt(targetBeatIndex) * secPerBeat;

            if (missed == false)
            {
                if (Mathf.Abs(songPosition - (targetTime + offset)) <= leeway) // If difference between current time and time of note is within leeway
                {
                    HitCounter.instance.IncHits();
                    targetBeatIndex++;
                }
                else
                {
                    HitCounter.instance.IncMisses();
                    missed = true;
                }
            }
        }
    }

    // Name: UpdateTargetBeat Function
    // Programmer: Konrad Kahnert
    // Date: 10/11/2022
    // Description: This function advances the targetBeatIndex when a note plays without the player hitting the spacebar.
    void UpdateTargetBeat()
    {
        if (targetBeatIndex < Beats.instance.GetTotalBeats()) // While there are still notes left to play
        {
            // Time checking needs to be done in dsp time so actual leeway is not based on bpm
            float songPosition = Conductor.instance.GetSongPosition();
            float secPerBeat = Conductor.instance.GetSecPerBeat();

            float offset = Conductor.instance.GetBeatOffset() * secPerBeat;
            float targetTime = Beats.instance.GetBeatAt(targetBeatIndex) * secPerBeat;
            float missTime = targetTime + offset + leeway; // Time where the note will have been missed

            if (songPosition > missTime) // Check if note has been missed
            {
                targetBeatIndex++;

                if (missed == false)
                {
                    HitCounter.instance.IncMisses();
                }
                else
                {
                    missed = false;
                }
            }
        }
    }

    // Name: Update Function
    // Programmer: Konrad Kahnert
    // Date: 10/11/2022
    // Description: Update is called every frame. Calls UpdateTargetBeat and checks for player input to call CheckTiming.
    void Update()
    {
        UpdateTargetBeat();

        if (Input.GetKeyDown(KeyCode.Space)) // When space is pressed down
        {
            CheckTiming();
        }
    }

    */

    // Name: GetKeys Function
    // Programmer: Konrad Kahnert
    // Date: 11/29/2022
    // Description: Returns char array containing input keys
    // Returns: array of input keys
    public char[] GetKeys()
    {
        return (keys);
    }
}
