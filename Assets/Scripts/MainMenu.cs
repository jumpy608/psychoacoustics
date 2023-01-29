using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Name: Begin Function
    // Programmer: Konrad Kahnert
    // Date: 1/29/2023
    // Description: Switches to game scene
    public void Begin()
    {
        SceneManager.LoadScene(1);
    }
}
