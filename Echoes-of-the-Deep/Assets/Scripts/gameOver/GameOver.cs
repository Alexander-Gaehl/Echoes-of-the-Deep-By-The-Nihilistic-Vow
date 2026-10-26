using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public void Retry()
	{
		//loads to profile
		SceneManager.LoadScene("Profile");
	}

	public void Quit()
	{
		Application.Quit();
		Debug.Log("Player has quit the game.");
	}
}
