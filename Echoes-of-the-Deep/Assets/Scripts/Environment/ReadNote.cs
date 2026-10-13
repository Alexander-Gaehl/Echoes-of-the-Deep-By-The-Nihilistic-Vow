using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadNote : MonoBehaviour
{
    [Header("UI Elements")]
	[SerializeField] private GameObject PaperNote; //The UI object
	[SerializeField] private TextMeshProUGUI NoteWord; //the text UI

	[Header("Note Content")]
	[TextArea(3, 10)]
	[SerializeField] private string noteContent;

	private bool isPlayerClose = false;
	private bool isNoteOpen = false;

	void Update()
	{
		
		if (isPlayerClose && Input.GetKeyDown(KeyCode.E)) //Check player is nearby and press the e key.
		{
			if (!isNoteOpen)
			{
				OpenNote();
			}
			else
			{
				CloseNote();
			}
		}
	}

	private void OpenNote()
	{
		NoteWord.text = noteContent; //note text into the UI
		PaperNote.SetActive(true); //Shows paper
		isNoteOpen = true;
	}

	public void CloseNote()
	{
		PaperNote.SetActive(false); //Hides paper
		isNoteOpen = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isPlayerClose = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isPlayerClose = false;
			CloseNote();
		}
	}
}
