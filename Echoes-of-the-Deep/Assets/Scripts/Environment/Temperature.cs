using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Temperature : MonoBehaviour
{
	public Image ImageTemp;
	public float duration = 60f;

	private float timer;

	void Start()
	{
		timer = duration;
		ImageTemp.fillAmount = 1f;
	}

	void Update()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
			ImageTemp.fillAmount = timer / duration;
		}
		else
		{
			timer = 0;
			ImageTemp.fillAmount = 0f;
			Debug.Log("You Froze to Death.");
			SceneManager.LoadScene("GAMEOVER");
		}
	}

	public void AddTime(float time)
	{
		timer += time;
		timer = Mathf.Min(timer, duration);
		ImageTemp.fillAmount = timer / duration;
	}
}
