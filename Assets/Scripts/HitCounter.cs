// Name: HitCounter Class
// Programmer: Konrad Kahnert
// Date: 10/11/2022
// Description: This is a class for an object that displays 2 counters. One shows how many times the player has hit a note, and the other shows how many times the player has missed a note.

using TMPro;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    public static HitCounter instance;
    [SerializeField] TextMeshProUGUI hitsText;
    [SerializeField] TextMeshProUGUI missesText;

    int hits = 0;
    int misses = 0;

    // Name: Start function
    // Programmer: Konrad Kahnert
    // Date: 10/10/2022
    // Description: Sets instance
    private void Start()
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
    }

    // Name: IncHits Function
    // Programmer: Konrad Kahnert
    // Date: 10/11/2022
    // Description: Incrementsand updates text display for hits counter.
    public void IncHits()
    {
        hits++;
        hitsText.text = hits.ToString();
    }

    // Name: IncMisses Function
    // Programmer: Konrad Kahnert
    // Date: 10/11/2022
    // Description: Increments and updates text display for misses counter.
    public void IncMisses()
    {
        misses++;
        missesText.text = misses.ToString();
    }
}
