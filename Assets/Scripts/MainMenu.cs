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

    // Name: LevelGenerator Function
    // Programmer: Maggie Swartz
    // Date: 4/23/23
    // Description: Allows level generator button to navigate to the correct scene
    public void LevelGenerator()
    {
	SceneManager.LoadScene(2);
    }
}
