// Name: HitCircle Class
// Programmer: Konrad Kahnert
// Date: 11/19/2022
// Description: Draws a black ring around the hit circle

using UnityEngine;

public class HitCircle : MonoBehaviour
{
    [SerializeField] DrawRing drawRing;

    // Name: Start Function
    // Programmer: Konrad Kahnert
    // Date: 11/19/2022
    // Description: Initialization
    void Start()
    {
        drawRing.Draw(Controller.instance.ringWidth, Controller.instance.ringEndRad);
    }
}
