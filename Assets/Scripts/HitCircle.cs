// Name: HitCircle Class
// Programmer: Konrad Kahnert
// Date: 11/19/2022
// Description: Draws a black ring around the hit circle

using UnityEngine;

public class HitCircle : MonoBehaviour
{
    [SerializeField] DrawRing drawRing;
    float ringWidth = 0.1f;
    float ringRad = 0.5f;

    // Name: Start Function
    // Programmer: Konrad Kahnert
    // Date: 11/19/2022
    // Description: Draws the ring
    void Start()
    {
        drawRing.Draw(ringWidth, ringRad);
    }
}
