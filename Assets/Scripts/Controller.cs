// Name: Controller Class
// Programmer: Konrad Kahnert
// Date: 11/30/2022
// Description: This class contains variables that are adjusted in the editor which modify gameplay.

using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller instance;

    [SerializeField] public float ringWidth = 0.1f;
    [SerializeField] public float ringStartRad = 3f;
    [SerializeField] public float ringEndRad = 0.5f;
    [SerializeField] public float tickLength = 0.25f; // How many beats there are between each character read in
    [SerializeField] public float bpm = 133f;
    [SerializeField] public float levelStartOffset = 2f; // How long to wait in sec to start the level
    [SerializeField] public float beatsShownInAdvance = 1.5f; // How many beats to spawn a note in advance of it reaching the hit circle
    [SerializeField] public float songOffset = 0.75f; // How long in sec to pre-emptivley play song in order to account for silence at beginning of song
    [SerializeField] public float leeway = 0f; // Max time difference between when player hits button and actual beat time of note to still register as a hit
    [SerializeField] public float beatOffset = 4f; // How long to delay beat timings. Song must play this many "empty" beats so first beat doesn't instantly spawn on hit circle.

    // Start is called before the first frame update
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
    }
}
