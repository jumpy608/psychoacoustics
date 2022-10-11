// Name: Beats Class
// Programmer: Konrad Kahnert
// Date: 9/23/2022
// Description: This class stores a list of beat timings. Each value in the list corresponds to when the note should be hit.

using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Beats : MonoBehaviour
{
    public static Beats instance;
    private List<float> beats = new List<float>();
    float tickLength = 0.25f; // How many beats there are between each character read in


    // Name: Start function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
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

    // Name: LoadBeatMap function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Reads in beats from a text file
    // Precondition: TextAsset
    // Postcondition: None
    public void LoadBeatMap(TextAsset map)
    {
        if (map != null)
        {
            string beatMapText = map.text;

            // Remove '|'s and whitespace from beat map text
            beatMapText = beatMapText.Replace("|", string.Empty).Trim();
            beatMapText = String.Concat(beatMapText.Where(c => !Char.IsWhiteSpace(c)));

            // Add beats
            for (int i = 0; i < beatMapText.Length; i++) // Loop through text
            {
                if (beatMapText[i] == 'x') // If note detected
                {
                    beats.Add(i * tickLength); // Add time of note to beats
                }
            }
        }
        else
        {
            Debug.LogError("No beat map text specified!");
        }
    }

    // Name: GetBeatAt function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Returns beat at specified list index
    // Precondition: valid index
    // Postcondition: beat value
    public float GetBeatAt(int index)
    {
        if ((index > -1) && (index < beats.Count())) // Check for valid index
        {
            return (beats[index]);
        }
        else
        {
            Debug.LogError("Invalid index!");
            return (-1);
        }
    }

    // Name: RemoveBeat function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Removes node at front of beat list
    public void RemoveBeat()
    {
        if (beats.Count > 0)
        {
            beats.RemoveAt(0);
        }
        else
        {
            Debug.LogError("Beats list is empty!");
        }
    }

    // Name: GetBeatsLeft function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Returns how many beats are in the list
    // Preconditon: None
    // Postcondition: num of beats in list
    public int GetTotalBeats()
    {
        return (beats.Count());
    }
}
