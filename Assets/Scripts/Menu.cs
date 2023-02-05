using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void play_btn()
	{
		SceneManager.LoadScene(1);
	}

	public void quit_btn()
	{
		Debug.Log("QUIT PRESSED");
		Application.Quit();
	}
}