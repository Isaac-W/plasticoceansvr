using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMarker : MonoBehaviour {
	private const float MAX_DISTANCE = 10.0f;

	private GameObject player;
	private GameObject fader;
	private FadeController fadeControl;

	public bool hideIfUnreachable = true;
	public float teleportHeightOffset = 3.0f;

	// Use this for initialization
	void Start () {
		// Get player instance
		player = GameObject.Find("Player");

		// Get fader
		fader = GameObject.Find("Fader");
		fadeControl = fader.GetComponent<FadeController>();
	}

	// Update is called once per frame
	void Update() {
		// Hide if distance is too far from player to be interactable
		if (hideIfUnreachable) {
			if ((player.transform.position - gameObject.transform.position).magnitude > MAX_DISTANCE) {
				GetComponent<Renderer> ().enabled = false;
			} else {
				GetComponent<Renderer> ().enabled = true;
			}
		}
	}

	public void Teleport() {
		StartCoroutine(TeleportHelper());
	}

	private IEnumerator TeleportHelper() {
		print ("TeleportMarker::TeleportHelper()");
		
		// Fade out
		fadeControl.FadeOut();
		yield return fadeControl.WaitForFade();

		// Teleport player
		Vector3 newPos = gameObject.transform.position;
		newPos.y += teleportHeightOffset;
		player.transform.position = newPos;

		// Fade in
		fadeControl.FadeIn();
		yield return fadeControl.WaitForFade();
	}
}
