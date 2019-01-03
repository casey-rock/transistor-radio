﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Dialogue dialogue;
    public TextHandler textHandler;
    public bool interactedWith = false;
	bool playerInRange = false;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            Speak();
        }
    }

    public void Speak()
    {
        if (interactedWith == false)
        {
            textHandler.LoadDialogue(dialogue);
            interactedWith = true;
        }
        else
        {
            textHandler.EndOfConvo();
        }

    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			playerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = false;
		}
	}
}
