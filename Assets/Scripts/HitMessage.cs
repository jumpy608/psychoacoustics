using TMPro;
using UnityEngine;
using System.Collections;

public class HitMessage : MonoBehaviour
{
    TextMeshProUGUI text;
    float fadeSpeed = 3f;
    bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayHitText()
    {
        text.text = "Based!";
        text.color = Color.green;

        // If text is already fading, stop fading
        if (isFading == true)
        {
            StopCoroutine(Fade());
        }

        // Start fade
        StartCoroutine(Fade());
    }

    public void DisplayMissText()
    {
        text.text = "Cringe!";
        text.color = Color.red;

        // If text is already fading, stop fading
        if (isFading == true)
        {
            StopCoroutine(Fade());
        }

        // Start fade
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1); // Set alpha to 1
        isFading = true;

        while (text.color.a > 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - fadeSpeed * Time.deltaTime); // Decrease alpha
            yield return null;
        }

        isFading = false;
    }
}
