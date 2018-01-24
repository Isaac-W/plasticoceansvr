using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAfterCollected : MonoBehaviour {
	public enum ActionType {
		SetEnabled, SetKinematic, SetComponentEnabled
	}

	public GameObject target;
	public ActionType action = ActionType.SetEnabled;
	public bool enableOnTrigger = true;
	public string componentName;

	private CollectibleItemManager itemMgr;
	private bool triggered = false;

	// Use this for initialization
	void Start () {
		// Get item manager
		itemMgr = CollectibleItemManager.GetInstance();

		// Set default state
		DoAction(!enableOnTrigger);
	}

	// Update is called once per frame
	void Update () {
		if (!triggered) {
			// Activate action
			if (itemMgr.AreAllItemsCollected ()) {
				triggered = true;
				DoAction (enableOnTrigger);
			}
		}
	}

	private void DoAction(bool enable) {
		switch (action) {
		default:
		case ActionType.SetEnabled:
			target.SetActive (enable);
			break;
		case ActionType.SetKinematic:
			target.GetComponent<Rigidbody> ().isKinematic = enable;
			break;
		case ActionType.SetComponentEnabled:
			((MonoBehaviour)target.GetComponent (componentName)).enabled = enable;
			break;
		}
	}
}
