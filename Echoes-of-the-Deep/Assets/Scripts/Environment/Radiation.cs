using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Radiation : MonoBehaviour
{
	public Image ImageRad;
	public float fillSpeed = 0.009f;
	public float targetFillAmount = 100f;

	void Update() 
	{
		if (ImageRad.fillAmount < targetFillAmount)
		{
			ImageRad.fillAmount = Mathf.MoveTowards(ImageRad.fillAmount, targetFillAmount, fillSpeed * Time.deltaTime);
		}
		/*else
		{
			ImageRad.fillAmount = 100f;
			Debug.Log("You Died to Radiation Poisoning");
			SceneManager.LoadScene("GAMEOVER");
		}*/
	}

	public void setProgress(float progressPercent)
	{
		targetFillAmount = Mathf.Clamp01(progressPercent);
	}

	public void addProgress(float amount)
	{
		setProgress(targetFillAmount + amount);
	}

	public void removeProgress(float amount) 
	{
		ImageRad.fillAmount -= amount;
	}
}
