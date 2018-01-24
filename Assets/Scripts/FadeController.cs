using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour {
	private UnityEngine.UI.Image image;

	private bool isFading = false; // Determines if currently fading
	private bool fadingOut = true; // Sets fade direction
	private float fadePercent = 0; // 0 - transparent; 1 - opaque

	public Color fadeColor;
	public float speed = 1; // Timestep between 1 - 100
	public bool fadeInOnSceneLoad = false;

	// Use this for initialization
	void Start () {
		image = GetComponent<UnityEngine.UI.Image>();

		if (fadeInOnSceneLoad) {
			SetFadePercent (1);
			FadeIn ();
		} else {
			SetFadePercent (0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isFading) {
			// End fade conditions
			if (fadePercent > 1) {
				BlinkOut (); // Opaque
			} else if (fadePercent < 0) {
				BlinkIn (); // Transparent
			} else {
				float percent = fadePercent + (fadingOut ? 1 : -1) * speed / 100f;
				SetFadePercent (percent);
			}
		}
	}

	public void SetFadePercent(float percent) {
		fadePercent = percent;

		Color color = fadeColor;
		color.a = Mathf.Lerp (0, 1, percent);
		image.color = color;
	}

	public void FadeOut() {
		fadingOut = true;
		isFading = true;
	}

	public void FadeIn() {
		fadingOut = false;
		isFading = true;
	}

	public bool IsFading() {
		return isFading;
	}

	public void BlinkOut() {
		SetFadePercent (1);
		isFading = false;
	}

	public void BlinkIn() {
		SetFadePercent (0);
		isFading = false;
	}

	// Usage: yield return fadeControl.WaitForFade() -- must be done in a StartCoroutine()
	public IEnumerator WaitForFade() {
		yield return new WaitUntil(() => !isFading); // Wait for fade
	}
}
