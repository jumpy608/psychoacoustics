// Name: NoteCircle Class
// Programmer: Konrad Kahnert
// Date: 10/21/2022
// Description: This class controls the behavior of a note circle, the object that represents a note or input event in the beatmap. This is the visual element that tells the player when they should make their
// inputs.

using UnityEngine;

public class NoteCircle : MonoBehaviour
{
    Vector2 startPos;
    Vector2 targetPos;
    float targetBeat;

    // Name: SetTargetBeat Function
    // Programmer: Konrad Kahnert
    // Date: 11/19/2022
    // Description: Sets the beat that this note circle should target
    public void SetTargetBeat(float x)
    {
        targetBeat = x;
    }

    // Name: SetTargetPos Function
    // Programmer: Konrad Kahnert
    // Date: 3/11/2023
    // Description: Sets end position of this note circle
    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Interpolate the position of this note circle such that the distance to the target position is based on the time until the target beat
        float t = (Controller.instance.beatsShownInAdvance - (targetBeat - Conductor.instance.GetSongPositionInBeats())) / Controller.instance.beatsShownInAdvance;
        transform.position = Vector2.Lerp(startPos, targetPos, t);

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }
}
