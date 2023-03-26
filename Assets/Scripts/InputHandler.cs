// Name: InputHandler Class
// Programmer: Konrad Kahnert
// Date: 10/10/2022
// Description: This class handles player input and is in charge of letting the player know if they hit or miss a note.

using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;
    KeyCode[] keys = { KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M }; // Keys corresponding to hit circles. Index in array == which hit circle it corresponds to
    int targetBeatIndex = 0; // Index of beat that player is currently supposed to hit
    bool missed = false; // Whether the target beat has been missed or not

    [SerializeField] HitMessage[] hitMessages = new HitMessage[3];


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

    // Name: CheckTiming Function
    // Programmer: Konrad Kahnert
    // Date: 10/11/2022
    // Description: This function is called when the player hits a key and does a check to see if the player hit or missed the current note.
    // Arguments: Which hitcircle the player hit the key for
    void CheckTiming(int keyNo)
    {
        if (targetBeatIndex < Beats.instance.GetTotalBeats()) // While there are still notes left to play
        {
            float songPosition = Conductor.instance.GetSongPosition();
            float secPerBeat = Conductor.instance.GetSecPerBeat();
            float offset = Controller.instance.beatOffset * secPerBeat;

            Beat beat = Beats.instance.GetBeatAt(targetBeatIndex);
            float targetTime = beat.time * secPerBeat; // What time the key should have been pressed
            int targetHitCircle = beat.hitCircleNo; // Which key should have been pressed

            if (missed == false)
            {
                if ((Mathf.Abs(songPosition - (targetTime + offset)) <= Controller.instance.leeway) && (keyNo == targetHitCircle)) // If difference between current time and time of note is within leeway and correct key has been pressed
                {
                    // Hit
                    HitCounter.instance.IncHits();
                    targetBeatIndex++;

                    // Display Hit Message
                    hitMessages[beat.hitCircleNo - 1].DisplayHitText();
                }
                else
                {
                    // Miss
                    HitCounter.instance.IncMisses();
                    missed = true;
                    AudioManager.instance.PlaySound("Record Scratch");
                    hitMessages[beat.hitCircleNo - 1].DisplayMissText(); // Display Miss Message

                    // Get all note circles
                    GameObject[] noteCircles;
                    noteCircles = GameObject.FindGameObjectsWithTag("Note Circle");

                    // Find note circle to grey out by finding the note circle that has the current beat the player was supposed to hit
                    float currentBeat = beat.time + Controller.instance.beatOffset;

                    foreach (GameObject x in noteCircles)
                    {
                        NoteCircle noteCircle = x.GetComponent<NoteCircle>();

                        if (noteCircle.GetTargetBeat() == currentBeat)
                        {
                            // Grey out note circle
                            noteCircle.GreyOut();
                            break;
                        }
                    }
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

            float offset = Controller.instance.beatOffset * secPerBeat;
            float targetTime = Beats.instance.GetBeatAt(targetBeatIndex).time * secPerBeat;
            float missTime = targetTime + offset + Controller.instance.leeway; // Time where the note will have been missed

            if (songPosition > missTime) // Check if note has been missed
            {
                if (missed == false)
                {
                    HitCounter.instance.IncMisses();
                    AudioManager.instance.PlaySound("Record Scratch");

                    // Display Miss Message
                    int hitCircleNo = Beats.instance.GetBeatAt(targetBeatIndex).hitCircleNo;
                    hitMessages[hitCircleNo - 1].DisplayMissText(); 
                }
                else
                {
                    missed = false;
                }

                targetBeatIndex++;
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

        // Check for key press
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                CheckTiming(i + 1);
            }
        }
    }
}
