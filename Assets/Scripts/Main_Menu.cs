using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Main_Menu : MonoBehaviour
{
	public void LoadGame()
	{
		//Load the Game Scene
		SceneManager.LoadScene(1); //0 = MainMenu, 1 = Game Scene
	} 
}
