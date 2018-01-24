using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAndQuit : MonoBehaviour {
	// Use this for initialization
	void Start () {
		StartCoroutine (DoAction ());
	}
	
	private IEnumerator DoAction() {
		FadeController fc = GameObject.Find("Fader").GetComponent<FadeController> ();
		fc.speed = 1;
		fc.FadeOut ();
		yield return fc.WaitForFade ();
		Application.Quit ();
	}
}
