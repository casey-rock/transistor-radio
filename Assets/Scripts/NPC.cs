using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPC : Character {
	private bool charInRange;
	public Dialogue dialogue;
	public bool talkedTo = false;
	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		charInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if player is in range and presses space, triggers NPC dialogue
		if (charInRange && Input.GetKeyDown(KeyCode.Space))
		{
			TriggerDialogue();
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
		//if last sentence in the queue, display it again
		if (sentences.Count == 1)
		{
			sentence = sentences.Peek();
			Debug.Log(sentence);
			return;
		}

		sentence = sentences.Dequeue();
		Debug.Log(sentence);
	}

	//ends dialogue
	private void EndDialogue()
	{
		Debug.Log("CONVERSATION OVER");
	}
}
