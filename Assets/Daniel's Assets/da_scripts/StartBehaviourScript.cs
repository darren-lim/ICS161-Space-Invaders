/*
Daniel Alcala
February 05, 2018
Game Engine Lab
Project 2
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartBehaviourScript : MonoBehaviour
{
 
    public void StartGame()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void QuitGame()
	{
        Application.Quit();
	}

}
