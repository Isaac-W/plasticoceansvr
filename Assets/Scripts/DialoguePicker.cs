using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePicker : MonoBehaviour {
    public DialogueChoice[] choices;

    public delegate void DialogueEventHandler(object sender, string selectedDialogue);
    public event DialogueEventHandler DialogueSelected;

    public GameObject viveController;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_TrackedController trackedController;

    private float threshold = 0.8f;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Awake() {
        trackedObj = viveController.GetComponent<SteamVR_TrackedObject>();
        trackedController = viveController.GetComponent<SteamVR_TrackedController>();
        trackedController.PadTouched += TrackedController_PadTouched;
        trackedController.PadUntouched += TrackedController_PadUntouched;
        trackedController.PadClicked += TrackedController_PadClicked;
	}

    private void TrackedController_PadClicked(object sender, ClickedEventArgs e)
    {
        DialogueChoice choice = GetChoice();
        if (choice)
        {
            DialogueSelected(choice, choice.GetDialogue());
        }
    }

    private void TrackedController_PadTouched(object sender, ClickedEventArgs e)
    {
        foreach (DialogueChoice c in choices)
        {
            c.SetSelected(false);
        }

        DialogueChoice choice = GetChoice();
        if (choice)
        {
            choice.SetSelected(true);
        }
    }

    private void TrackedController_PadUntouched(object sender, ClickedEventArgs e)
    {
        foreach (DialogueChoice c in choices)
        {
            c.SetSelected(false);
        }
    }

    private DialogueChoice GetChoice()
    {
        Vector2 touchpad = Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);

        // Left
        if (touchpad.x < -threshold && Math.Abs(touchpad.y) < threshold)
        {
            return choices[0];
        }

        // Up
        if (touchpad.y > threshold && Math.Abs(touchpad.x) < threshold)
        {
            return choices[1];
        }

        // Right
        if (touchpad.x > threshold && Math.Abs(touchpad.y) < threshold)
        {
            return choices[2];
        }

        // Down
        if (touchpad.y < -threshold && Math.Abs(touchpad.x) < threshold)
        {
            return choices[3];
        }

        return null;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetDialogueChoices(string[] dialogue)
    {
        for (int i = 0; i < Mathf.Min(choices.Length, dialogue.Length); i++)
        {
            choices[i].SetDialogue(dialogue[i]);
        }
    }
}
