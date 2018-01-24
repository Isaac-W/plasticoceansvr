using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteraction : MonoBehaviour {
	private Color originalColor;

	public Color highlightColor;

	// Use this for initialization
	void Start () {
		originalColor = GetComponent<Renderer>().material.color;
	}

	public void SetHighlight(bool isSelected) {
		GetComponent<Renderer>().material.color = isSelected ? highlightColor : originalColor;
	}
}
