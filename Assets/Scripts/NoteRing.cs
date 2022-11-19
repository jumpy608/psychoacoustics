using UnityEngine;
[RequireComponent(typeof(DrawRing))]

public class NoteRing : MonoBehaviour
{
    Conductor cond;
    DrawRing drawRing;

    float startRad = 3f;
    float targetRad = 0.5f;
    float targetBeat;
    float ringWidth = 0.1f;

    private void Start()
    {
        cond = Conductor.instance;
        drawRing = GetComponent<DrawRing>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = (cond.GetBeatsShownInAdvance() - (targetBeat - cond.GetSongPositionInBeats())) / cond.GetBeatsShownInAdvance();
        float rad = Mathf.Lerp(startRad, targetRad, t);
        drawRing.Draw(ringWidth, rad);

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }

    public void SetTargetBeat(float x)
    {
        targetBeat = x;
    }
}
