using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Toggle chungusToggle;

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

	public void howtoplay_btn()
	{
		SceneManager.LoadScene(5);
	}


	public void SetChungus()
    {
		if (chungusToggle.isOn)
			PlayerPrefs.SetInt("Chungus", 1);
		else
			PlayerPrefs.SetInt("Chungus", 0);
	}
}