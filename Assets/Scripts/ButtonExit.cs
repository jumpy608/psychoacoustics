using UnityEngine;

public class ButtonExit : MonoBehaviour
{
	// Name: Exit Function
	// Programmer: Maggie Swartz
	// Date: 4/23/23
	// Description: Function allows exit button to quit the application and end the game
	
	public void Button_exit()
	{
		//Application.Quit(); This would exit when built in application
		UnityEditor.EditorApplication.isPlaying = false; //This exits when still in editor
		Debug.Log("Game is exiting!");
	}
}
