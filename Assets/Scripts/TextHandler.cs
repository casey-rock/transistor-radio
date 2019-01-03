﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHandler : MonoBehaviour
{
    Dialogue dialogue;
    TextMeshProUGUI UIText;
	GameObject textBox;
	Image portrait;

    private void Awake()
    {
        UIText = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
		textBox = GameObject.Find("TextBox");
		portrait = GameObject.Find("Portrait").GetComponent<Image>();
		
		textBox.SetActive(false);
	}

    public void LoadDialogue(Dialogue d)
    {
        dialogue = d;

		StartCoroutine(LoadText(0));
    }

    public IEnumerator LoadText(int dialogueID)
    {
        UIText.text = "";
        char[] textArray;

		portrait.sprite = dialogue.sprite;

		textBox.SetActive(true);

        if (dialogueID == 99)
        {
            textArray = dialogue.messages[dialogue.messages.Length-1].text.ToCharArray();
        }
        else
        {
            textArray = dialogue.messages[dialogueID].text.ToCharArray();
        }

        for(int i = 0; i < textArray.Length; i++)
        {
            UIText.text += textArray[i];
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(WaitForResponse(dialogueID));

    }

    IEnumerator WaitForResponse(int currID)
    {
        bool responded = false;

        while (!responded) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                responded = true;
            }
            else
            {
                yield return new WaitForFixedUpdate();
            }
        }

        if (currID != 99)
        {
            if (dialogue.messages[currID].responses[0].next > 0)
            {
                StartCoroutine(LoadText(dialogue.messages[currID].responses[0].next));
            }
            else
            {
                UIText.text = "";
				textBox.SetActive(false);
            }
        }
        else
        {
            UIText.text = "";
			textBox.SetActive(false);
        }

        yield return null;
    }

    public void EndOfConvo()
    {
        if(UIText.text.CompareTo("") == 0)
        {
            StartCoroutine(LoadText(dialogue.messages.Length-1));
        }
    }
}
