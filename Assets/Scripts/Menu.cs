using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	
	public void play_btn()
	{
		SceneManager.LoadSceneAsync("World");
	}

	public void quit_btn()
	{
		Debug.Log("QUIT PRESSED");
		Application.Quit();
	}

	public void menu_btn()
    {
		SceneManager.LoadSceneAsync("TitleScreen");
	}

	public void leaderboard_btn()
	{
		SceneManager.LoadSceneAsync("Leaderboard");
	}
}