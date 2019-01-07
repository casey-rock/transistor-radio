using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public Image portrait;
    public GameObject textBox;
    public TextMeshProUGUI UIText;
	public TextHandler textHandler;

    static DialogueSystem _instance;
    public static DialogueSystem instance
    {
        get
        {
            return _instance;
        }
    }

    public void Awake()
    {
        if (_instance != null)
            Debug.LogError("You somehow have two dialogue systems in your scene at once");
        _instance = this;
    }
}
