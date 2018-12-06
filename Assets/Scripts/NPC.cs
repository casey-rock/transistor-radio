using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPC : Character {
	private bool charInRange;
	public Dialogue dialogue;
	public bool talkedTo = false;

	// Use this for initialization
	void Start () {
		charInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (charInRange && Input.GetKeyDown(KeyCode.Space))
		{
			TriggerDialogue();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			charInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			charInRange = false;
		}
	}

	private void TriggerDialogue()
	{
		if (!talkedTo)
		{
			talkedTo = true;
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}
		else
		{
			FindObjectOfType<DialogueManager>().DisplayNextSentence();
		}
	}
}
