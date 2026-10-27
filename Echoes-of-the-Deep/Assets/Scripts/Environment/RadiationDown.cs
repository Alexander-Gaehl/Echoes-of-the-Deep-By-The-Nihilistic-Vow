using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationDown : MonoBehaviour
{
	[SerializeField] private float timeDecrease = 100f;

    private Radiation timeScript;
	void Start()
	{
		timeScript = Object.FindFirstObjectByType<Radiation>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			timeScript.removeProgress(timeDecrease);
		}
	}
}
