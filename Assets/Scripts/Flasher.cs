// Name: Flasher Class
// Programmer: Konrad Kahnert
// Date: 9/23/2022
// Description: This is an object that flashes colors in sync with the music.

using UnityEngine;

public class Flasher : MonoBehaviour
{
    [SerializeField] Color color1 = Color.blue;
    [SerializeField] Color color2 = Color.red;
    SpriteRenderer spriteRend;

    // Name: Start Class
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Gets sprite renderer and sets object color to color1
    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = color1;
    }

    // Name: Flash Class
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Changes object color. If object is color1, changes to color2. If object is color2, changes to color1.
    public void Flash()
    {
        if (spriteRend.color == color1)
        {
            spriteRend.color = color2;
        }
        else
        {
            spriteRend.color = color1;
        }
    }
}
