using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void HideMe() {
		gameObject.SetActive (false);
	}
}
