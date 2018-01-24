using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
	public bool countTowardsTotal = true;
	public bool hideOnCollect = true;

	private CollectibleItemManager itemMgr;

	// Use this for initialization
	void Start () {
		// Get item manager
		itemMgr = CollectibleItemManager.GetInstance();

		// Advise item manager
		if (countTowardsTotal)
			itemMgr.AddCollectible(this);
	}

	public void CollectItem() {
		gameObject.SetActive (!hideOnCollect);

		if (countTowardsTotal)
			itemMgr.CollectItem (this);
	}
}
