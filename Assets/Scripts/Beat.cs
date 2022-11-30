public readonly struct Beat
{
    public readonly float time;
    public readonly int hitCircleNo;

    public Beat(int hitCircleNoIn, float timeIn)
    {
        time = timeIn;
        hitCircleNo = hitCircleNoIn;
    }
}
