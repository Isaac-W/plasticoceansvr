using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAfterCollected : MonoBehaviour {
	public GameObject target;

	private CollectibleItemManager itemMgr;

	// Use this for initialization
	void Start () {
		itemMgr = CollectibleItemManager.GetInstance ();
		target.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (itemMgr.AreAllItemsCollected())
			target.SetActive (true); // Enable after all items collected
	}
}
