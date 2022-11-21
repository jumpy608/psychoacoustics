// Name: DrawRing Class
// Programmer: Konrad Kahnert
// Date: 11/19/2022
// Description: Draws a ring around the object this script is attached to using LineRenderer

using UnityEngine;

public class DrawRing : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    int lineCount = 60;       //more lines = smoother ring

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Draw(float width, float radius)
    {
        lineRenderer.positionCount = lineCount;
        lineRenderer.startWidth = width;
        float theta = (2f * Mathf.PI) / lineCount;  //find radians per segment
        float angle = 0;

        for (int i = 0; i < lineCount; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += theta;
        }
    }
}
