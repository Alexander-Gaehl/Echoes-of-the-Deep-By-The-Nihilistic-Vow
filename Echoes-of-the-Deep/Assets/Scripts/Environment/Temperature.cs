using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temperature : MonoBehaviour
{

	public Image imageTemp;

	public float duration = 30f;

	private float timer;

	public bool tempDamage;


	void Start()
	{

		timer = duration;

		imageTemp.fillAmount = 1f;

	}


	void Update()
	{


		if (timer > 0)
		{

			timer -= Time.deltaTime;

			imageTemp.fillAmount = timer / duration;

			tempDamage = false;

		}


		else
		{

			timer = 0f;

			imageTemp.fillAmount = 0f;

			Debug.Log("You Froze to Death.");

			tempDamage = true;

		}

	}


	public void AddTime(float time)
	{

		timer += time;

		timer = Mathf.Min(timer, duration);

		imageTemp.fillAmount = timer / duration;

	}

}
