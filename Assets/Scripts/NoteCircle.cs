// Name: NoteCircle Class
// Programmer: Konrad Kahnert
// Date: 10/21/2022
// Description: This class controls the behavior of a note circle, the object that represents a note or input event in the beatmap. This is the visual element that tells the player when they should make their
// inputs.

using UnityEngine;

public class NoteCircle : MonoBehaviour
{
    Conductor cond;
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

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector2(0, -3.5f);
        cond = Conductor.instance;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (cond.GetBeatsShownInAdvance() - (targetBeat - cond.GetSongPositionInBeats())) / cond.GetBeatsShownInAdvance();
        transform.position = Vector2.Lerp(startPos, targetPos, t);

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }
}
