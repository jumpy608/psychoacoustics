// Name: HitCircle Class
// Programmer: Konrad Kahnert
// Date: 11/19/2022
// Description: Draws a black ring around the hit circle

using UnityEngine;

public class HitCircle : MonoBehaviour
{
    public static HitCircle instance;
    [SerializeField] DrawRing drawRing;
    float ringWidth = 0.1f;
    float ringRad = 0.5f;

    // Name: Start Function
    // Programmer: Konrad Kahnert
    // Date: 11/19/2022
    // Description: Initialization
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

        drawRing.Draw(ringWidth, ringRad);
    }

    // Name: GetRingWidth Function
    // Programmer: Konrad Kahnert
    // Date: 11/20/2022
    // Description: Returns ringWidth
    // Arguments: None
    // Returns: ringWidth
    public float GetRingWidth()
    {
        return ringWidth;
    }

    // Name: GetRingRad Function
    // Programmer: Konrad Kahnert
    // Date: 11/20/2022
    // Description: Returns ringRad
    // Arguments: None
    // Returns: ringRad
    public float GetRingRad()
    {
        return ringRad;
    }
}
