// Name: Controller Class
// Programmer: Konrad Kahnert
// Date: 3/26/2023
// Description: This class will display a short message that indicates whether the player hit or missed a note.

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

    // Name: Fade Function
    // Programmer: Konrad Kahnert
    // Date: 3/26/2023
    // Description: Sets alpha of text to 1, then fades text out until alpha is 0.
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
