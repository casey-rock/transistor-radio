using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHandler : MonoBehaviour
{
    Dialogue dialogue;

    private void Awake()
    {
        DialogueSystem.instance.textBox.SetActive(false);
    }

    public void LoadDialogue(Dialogue d)
    {
        dialogue = d;

		StartCoroutine(LoadText(0));
    }

    public IEnumerator LoadText(int dialogueID)
    {
        DialogueSystem.instance.UIText.text = "";
        char[] textArray;

        DialogueSystem.instance.portrait.sprite = dialogue.sprite;

        DialogueSystem.instance.textBox.SetActive(true);

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
            DialogueSystem.instance.UIText.text += textArray[i];
            DialogueSystem.instance.audioSource.PlayOneShot(dialogue.sound);
            yield return new WaitForSeconds(0.02f);
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
                DialogueSystem.instance.UIText.text = "";
                DialogueSystem.instance.textBox.SetActive(false);
            }
        }
        else
        {
            DialogueSystem.instance.UIText.text = "";
            DialogueSystem.instance.textBox.SetActive(false);
        }

        yield return null;
    }

    public void EndOfConvo()
    {
        if(DialogueSystem.instance.UIText.text.CompareTo("") == 0)
        {
            StartCoroutine(LoadText(dialogue.messages.Length-1));
        }
    }
}
