using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnProximity : MonoBehaviour {
	public bool showIfClose = true;
	public float thresholdDistance = 20.0f; // Distance to show

	private GameObject player;
	private Renderer r;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		r = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if ((player.transform.position - gameObject.transform.position).magnitude > thresholdDistance) {
			r.enabled = !showIfClose;
		} else {
			r.enabled = showIfClose;
		}
	}
}
