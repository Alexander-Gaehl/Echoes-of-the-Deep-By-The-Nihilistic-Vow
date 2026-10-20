using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI TimerText;
	[SerializeField] float remainingTime;

	void Update()
	{
		if (remainingTime > 0)
		{
			remainingTime -= Time.deltaTime;
		}
		else if (remainingTime < 0)
		{
			remainingTime = 0;
			SceneManager.LoadScene("Profile");
		}

		int minutes = Mathf.FloorToInt(remainingTime / 60);
		int seconds = Mathf.FloorToInt(remainingTime % 60);
		TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
