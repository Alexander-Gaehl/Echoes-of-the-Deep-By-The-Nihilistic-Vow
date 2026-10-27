using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class TimerCountdown : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI timerText;
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

		timerText.text = string.Format("{0:D2}:{1:D2}", (Mathf.RoundToInt(remainingTime) / 60), (Mathf.RoundToInt(remainingTime) % 60));
	}
}
