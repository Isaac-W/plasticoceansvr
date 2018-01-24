using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemManager : MonoBehaviour {
	private HashSet<CollectibleItem> allCollectibles = new HashSet<CollectibleItem>();
	private HashSet<CollectibleItem> collectedItems = new HashSet<CollectibleItem>();

	public static CollectibleItemManager GetInstance() {
		return GameObject.Find("CollectibleItemManager").GetComponent<CollectibleItemManager>();
	}

	// Use this for initialization
	void Start () {
		
	}

	public void AddCollectible(CollectibleItem item) {
		allCollectibles.Add (item);
	}

	public void CollectItem(CollectibleItem item) {
		collectedItems.Add (item);
	}

	public bool IsItemCollected(CollectibleItem item) {
		return allCollectibles.Contains (item);
	}

	public bool AreAllItemsCollected() {
		//return collectedItems.SetEquals (allCollectibles);
		return allCollectibles.Count == collectedItems.Count;
	}
}
