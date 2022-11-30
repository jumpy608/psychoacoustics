// Name: NoteRing Class
// Programmer: Konrad Kahnert
// Date: 11/20/2022
// Description: This class controls the behavior of a note ring, the object that represents a note or input event in the beatmap. This is the visual element that tells the player when they should make their
// inputs.

using UnityEngine;
[RequireComponent(typeof(DrawRing))]

public class NoteRing : MonoBehaviour
{
    DrawRing drawRing;

    float startRad;
    float targetRad;
    float targetBeat;
    float ringWidth;

    // Name: SetTargetBeat Function
    // Programmer: Konrad Kahnert
    // Date: 11/20/2022
    // Description: Initialization
    private void Start()
    {
        drawRing = GetComponent<DrawRing>();
        startRad = Controller.instance.ringStartRad;
        targetRad = Controller.instance.ringEndRad;
        ringWidth = Controller.instance.ringWidth;
    }

    // Name: SetTargetBeat Function
    // Programmer: Konrad Kahnert
    // Date: 11/20/2022
    // Description: Draws the note ring, adjusting its radius every frame so it shrinks on time
    void Update()
    {
        // Interpolate radius of circle by how much time there is until the target beat
        float t = (Controller.instance.beatsShownInAdvance - (targetBeat - Conductor.instance.GetSongPositionInBeats())) / Controller.instance.beatsShownInAdvance;
        float rad = Mathf.Lerp(startRad, targetRad, t);
        drawRing.Draw(ringWidth, rad);

        // Destroy when target beat is reached
        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }

    // Name: SetTargetBeat Function
    // Programmer: Konrad Kahnert
    // Date: 11/20/2022
    // Description: Sets target beat
    // Arguments: x (value to set target beat to)
    public void SetTargetBeat(float x)
    {
        targetBeat = x;
    }

    public void SetTargetRad(float x)
    {
        targetRad = x;
    }

    public void SetRingWidth(float x)
    {
        ringWidth = x;
    }
}
