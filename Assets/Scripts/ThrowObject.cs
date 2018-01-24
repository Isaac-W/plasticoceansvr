using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour {
	public float strength = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Throw() {
		// Get player facing direction
		Vector3 direction = GameObject.Find ("Main Camera").transform.forward;
		direction.y = 1f; // Add extra "up" force

		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.AddForce(direction * strength, ForceMode.Impulse);
	}
}
