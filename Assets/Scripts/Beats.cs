// Name: Beats Class
// Programmer: Konrad Kahnert
// Date: 9/23/2022
// Description: This class stores a list of beat structs. Contains functionality for reading a text file and building a list of beats from it.

using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Beats : MonoBehaviour
{
    public static Beats instance;
    private List<Beat> beats = new List<Beat>();

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

            for (int i = 0; i < beatMapText.Length; i++) // Loop through beat map text
            {
                if ((beatMapText[i] == '1') || (beatMapText[i] == '2') || (beatMapText[i] == '3'))
                {
                    // Create beat and add to beat list
                    int hitCircleNo = beatMapText[i] - '0'; // Convert char to int
                    Beat beat = new Beat(hitCircleNo, i * Controller.instance.tickLength);
                    beats.Add(beat);
                }
            }

            /*
            // Print beats to console
            string testString = "";

            for (int i = 0; i < beats.Count; i++)
            {
                float time = beats[i].time;
                int hitCircleNo = beats[i].hitCircleNo;

                testString += "(" + hitCircleNo + "," + time + "), ";
            }

            Debug.Log(testString);
            */
        }
        else
        {
            Debug.LogError("No beat map text specified!");
        }
    }

    // Name: GetBeatAt function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Returns beat at specified location
    // Arguments: row and column of array position
    // Returns: beat value
    public Beat GetBeatAt(int x)
    {
        if (x < beats.Count)
        {
            return (beats[x]);
        }
        else
        {
            Debug.LogError("Invalid index!");
            Beat beat = new Beat(0, 0);
            return (beat);
        }
    }

    // Name: GetTotalBeats function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Returns how many beats are in the array
    // Returns: beatCount
    public int GetTotalBeats()
    {
        return (beats.Count);
    }
}
