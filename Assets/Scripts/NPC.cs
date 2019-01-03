using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class NPC : Character {
	private bool charInRange;
	public Dialogue dialogue;
	public bool talkedTo = false;
	public bool windowIsActive = false;
	private Queue<string> sentences;
	public TextMeshProUGUI textPro;
	private GameObject dialogDisplay;
	Player player;

	// Use this for initialization
	void Start () {
		charInRange = false;
		textPro = FindObjectOfType<TextMeshProUGUI>();
		dialogDisplay = GameObject.FindGameObjectWithTag("DialogDisplay");
		dialogDisplay.SetActive(false);
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		//if player is in range and presses space, triggers NPC dialogue
		if (charInRange && Input.GetKeyDown(KeyCode.Space))
		{
			textPro.text = "";
			//TriggerDialogue();
		}
		if (!charInRange)
		{
			dialogDisplay.SetActive(false);
		}
	}

	//if Player gameObject is in NPC collider, player is in range
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			charInRange = true;
		}
	}

	//if player exits NPC collider, player is not in range
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			charInRange = false;
		}
	}
	/*
	//if NPC has been talked to before, displays next sentence; if not, loads dialogue and displays first sentence
	private void TriggerDialogue()
	{
		
		if (!talkedTo)
		{
			talkedTo = true;
			StartDialogue(dialogue);
		}
		else
		{
			DisplayNextSentence();
		}
	}

	//loads a queue with lines from Dialogue and displays first sentence
	
	public void StartDialogue(Dialogue dialogue)
	{
		sentences = new Queue<string>();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}
	

	//displays next sentence in the queue
	public void DisplayNextSentence()
	{
		string sentence;

		if (windowIsActive == false)
		{
			player.DisablePlayerMovement();
			//if last sentence in the queue, display it again
			if (sentences.Count == 1)
			{
				sentence = sentences.Peek();
				textPro.text = sentence;
				Debug.Log(sentence);
				StartCoroutine(DisplayTextWindow());
				return;
			}

			sentence = sentences.Dequeue();
			textPro.text = sentence;
			Debug.Log(sentence);
			StartCoroutine(DisplayTextWindow());
		}
		else
		{
			DeactivateTextWindow();
			player.EnablePlayerMovement();
		}
	}
	*/

	IEnumerator DisplayTextWindow()
	{
		dialogDisplay.SetActive(true);
		windowIsActive = true;
		yield return new WaitForSeconds(0.1f);
		yield return WaitForKeyPress(KeyCode.Space);
		DeactivateTextWindow();
	}

	private void DeactivateTextWindow()
	{
		textPro.text = "";
		dialogDisplay.SetActive(false);
		windowIsActive = false;
	}

	IEnumerator WaitForKeyPress(KeyCode key)
	{
		bool isTalking = true;

		while (isTalking)
		{
			if (Input.GetKeyDown(key))
			{
				isTalking = false;
			}
			yield return null;
		}
	}
}
