using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoice : MonoBehaviour {
    public Text text;
    public Image image;

    private string dialogue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSelected(bool selected)
    {
        image.color = selected ? new Color(1, 1, 0) : new Color(0, 1, 1);
    }

    public void SetDialogue(string dialogue)
    {
        text.text = dialogue;
        this.dialogue = dialogue;
    }

    public string GetDialogue()
    {
        return dialogue;
    }
}
