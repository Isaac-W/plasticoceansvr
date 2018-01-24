using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
	public Color color;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = color;
	}
	
	public void SetColor(Color color) {
		this.color = color;
		GetComponent<Renderer>().material.color = color;
	}

	public Color GetColor() {
		return this.color;
	}
}
