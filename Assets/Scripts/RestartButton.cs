using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Name: RestartLevel Function
    // Programmer: Konrad Kahnert
    // Date: 1/29/2023
    // Description: Restarts level
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
