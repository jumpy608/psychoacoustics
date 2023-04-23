using UnityEngine;

public class ButtonExit : MonoBehaviour
{
	// Name: Exit Function
	// Programmer: Maggie Swartz
	// Date: 4/23/23
	// Description: Function allows exit button to quit the application and end the game
	
	public void Button_exit()
	{
		Application.Quit();
		Debug.Log("Game is exiting!");
	}
}
