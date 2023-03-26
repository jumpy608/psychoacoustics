// Name: Controller Class
// Programmer: Konrad Kahnert
// Date: 3/26/2023
// Description: Data object for holding info about a beat event.

public readonly struct Beat
{
    public readonly float time; // Time which this beat is supposed to be hit
    public readonly int hitCircleNo; // Hit circle this beat corresponds to. Indexed from 1

    public Beat(int hitCircleNoIn, float timeIn)
    {
        time = timeIn;
        hitCircleNo = hitCircleNoIn;
    }
}
