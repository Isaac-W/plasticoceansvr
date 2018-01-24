using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {
	public bool nextScene = true; // Switch to the next scene instead of specifying
	public string sceneName;
	public bool fadeOut;

	private FadeController fadeControl;

	// Use this for initialization
	void Start () {
		// Get fader
		if (fadeOut) {
			fadeControl = GameObject.Find("Fader").GetComponent<FadeController> ();
		}
	}
	
	public void LoadScene() {
		if (fadeOut) {
			StartCoroutine (FadeOutAndLoad());
		} else {
			DoSwitchScene ();
		}
	}

	private void DoSwitchScene() {
		if (nextScene) {
			SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
		} else {
			SceneManager.LoadScene (sceneName, LoadSceneMode.Single);
		}
	}

	// Coroutine. Waits for the screen to fade out then loads the next scene.
	private IEnumerator FadeOutAndLoad() {
		fadeControl.FadeOut ();
		yield return fadeControl.WaitForFade();
		DoSwitchScene ();
	}
}
