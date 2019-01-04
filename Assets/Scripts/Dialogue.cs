using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    public int npcID;
    public Sprite sprite;
    public string npcName;
	public AudioClip sound;
	public Message[] messages;
	
}
