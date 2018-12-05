using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character {
	private bool charInRange;
	public string script;

	// Use this for initialization
	void Start () {
		charInRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (charInRange && Input.GetKeyDown(KeyCode.Space))
		{
			Speak();
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

	private void Speak()
	{
		Debug.Log(script);
	}
}
