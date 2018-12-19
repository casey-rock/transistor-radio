using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogDisplay : MonoBehaviour
{
	public TextMeshProUGUI textPro;

	// Start is called before the first frame update
	void Start()
    {
		textPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	public void Disappear()
	{
		textPro.canvasRenderer.gameObject.SetActive(false);
	}

	public void Appear()
	{
		textPro.canvasRenderer.gameObject.SetActive(true);
	}



}
