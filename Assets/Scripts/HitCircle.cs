using UnityEngine;
using UnityEngine.UI;

public class HitCircle : MonoBehaviour
{
    Image image;
    Color downColor = new Color(0, 0.68f, 0.08f);
    Color upColor = Color.green;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void DownColor()
    {
        image.color = downColor;
    }

    public void UpColor()
    {
        image.color = upColor;
    }
}
