using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public DialoguePicker picker;

	// Use this for initialization
	void Start () {
        picker.DialogueSelected += Picker_DialogueSelected;
	}

    private void Picker_DialogueSelected(object sender, string selectedDialogue)
    {
        Debug.Log("Dialog selected: " + selectedDialogue);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
