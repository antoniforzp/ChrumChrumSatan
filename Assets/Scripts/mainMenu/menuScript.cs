using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene("game_temp");
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}