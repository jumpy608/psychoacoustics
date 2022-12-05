using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Main_Menu : MonoBehaviour
{
	// Name: LoadGame(), EaasySongs(), MediumSongs(), HardSongs(), BeginGame()
    	// Programmer: Maggie Swartz
    	// Date: 10/23/2022
    	// Description: Utilizes SceneManagement library to switch between the scene environments (starts w/ main menu, then switches based on selections). To be utilized w/ a button click.
	public void MainMenu()
	{
		SceneManager.LoadScene(0); //0 = MainMenu
	} 
	
	public void EasySongs()
	{
		SceneManager.LoadScene(1); //1 = Easy Song Select Scene
	}

	public void MediumSongs()
	{
		SceneManager.LoadScene(2); //2 = Medium Song Select Scene
	}

	public void HardSongs()
	{
		SceneManager.LoadScene(3); //3 = Hard Song Select Scene
	}

	public void BeginGame()
	{	
		SceneManager.LoadScene(4); //4 = Gameplay Scene
	} 
}
