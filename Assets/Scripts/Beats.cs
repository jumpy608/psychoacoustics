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
    private List<List<float>> beats = new List<List<float>>(); // A list of lists to store beat info. Essentially a jagged array
    int beatCount = 0;
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

        // Initialize beats list
        for (int i = 0; i < 4; i++)
        {
            beats.Add(new List<float>());
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

            char[] keys = { '1', '2', '3', '4' }; // Get key chars

            for (int i = 0; i < beatMapText.Length; i++) // Loop through beat map text
            {
                for (int k = 0; k < keys.Length; k++) // Check character for match with a key
                {
                    if (beatMapText[i] == keys[k])
                    {
                        // Add beat to beat array
                        beats[k].Add(i * tickLength);
                        beatCount++;
                        break;
                    }
                }
            }

            // Print beats to console
            for (int i = 0; i < 4; i++)
            {
                string testString = "";
                for (int j = 0; j < beats[i].Count; j++)
                {
                    if (j == 0)
                    {
                        testString = beats[i][j].ToString();
                    }
                    else
                    {
                        testString = testString + ", " + beats[i][j];
                    }
                }
                Debug.Log(testString);
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
    // Description: Returns beat at specified location
    // Arguments: row and column of array position
    // Returns: beat value
    public float GetBeatAt(int row, int col)
    {
        if ((row > -1) && (row < beats.Count()))
        {
            if ((col > -1) && (col < beats[row].Count()))
            {
                return (beats[row][col]);
            }
            else
            {
                Debug.LogError("Invalid index!");
                return (-1);
            }
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
    public void RemoveBeat(int row)
    {
        if (beats.Count > 0)
        {
            beats[row].RemoveAt(0);
        }
        else
        {
            Debug.LogError("Beats row is empty!");
        }
    }

    // Name: GetTotalBeats function
    // Programmer: Konrad Kahnert
    // Date: 9/23/2022
    // Description: Returns how many beats are in the array
    // Returns: beatCount
    public int GetTotalBeats()
    {
        return (beatCount);
    }
}
