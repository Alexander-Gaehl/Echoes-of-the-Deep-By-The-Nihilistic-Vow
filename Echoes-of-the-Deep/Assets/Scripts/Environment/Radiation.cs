using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radiation : MonoBehaviour
{
	public Image ImageRad;
	public float fillSpeed = 0.009f;
	public float targetFillAmount = 60f;

	void Update() 
	{
		if (ImageRad.fillAmount < targetFillAmount)
		{
			ImageRad.fillAmount = Mathf.MoveTowards(ImageRad.fillAmount, targetFillAmount, fillSpeed * Time.deltaTime);
		}
	}

	public void setProgress(float progressPercent)
	{
		targetFillAmount = Mathf.Clamp01(progressPercent);
	}

	public void addProgress(float amount)
	{
		setProgress(targetFillAmount + amount);
	}
}
