using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmthIncrease : MonoBehaviour
{
	[SerializeField] private float timeAmount = 15f;

	private Temperature coldTimerScript;

	void Start()
	{
		coldTimerScript = Object.FindFirstObjectByType<Temperature>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			coldTimerScript.AddTime(timeAmount);
		}
	}
}
