using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Main_Menu : MonoBehaviour
{
	// Name: LoadGame()
    	// Programmer: Maggie Swartz
    	// Date: 10/23/2022
    	// Description: Utilizes SceneManagement library to switch between the scene environments (starts w/ main menu, then switches to game play). To be utilized w/ a button click.
	public void LoadGame()
	{
		//Load the Game Scene
		SceneManager.LoadScene(1); //0 = MainMenu, 1 = Game Scene
	} 
}
