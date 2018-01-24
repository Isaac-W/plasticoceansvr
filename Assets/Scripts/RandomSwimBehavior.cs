using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSwimBehavior : MonoBehaviour {
	public int cycleTime = 300; // How often to change direction
	public float swimSustainRatio = 0.25f; // How long to sustain swim

	public float swimSpeed = 0.1f;
	public float turnSpeed = 0.2f;
	public float maxDistance = 25f; // Maximum radius from origin before forced to swim back

	public bool swimFromPlayer = false; // If fish are scared of player

	private GameObject player;
	private float playerThreshold = 5.0f;

	private Vector3 origin;
	private Rigidbody rb;

	private int counter = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		origin = gameObject.transform.position;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		counter++;

		// First check for player condition
		if (swimFromPlayer) {
			if ((player.transform.position - gameObject.transform.position).magnitude < playerThreshold) {
				//gameObject.transform.forward = (gameObject.transform.position - player.transform.position).normalized;
				rb.AddForce(gameObject.transform.forward * swimSpeed, ForceMode.Impulse); // Swim FASTER!!
				return; // Skip other logic
			}
		}

		if (counter > cycleTime) {
			// Check if outside of bounds
			float dist = (gameObject.transform.position - origin).magnitude;
			if (dist > maxDistance) {
				// Point at origin
				gameObject.transform.LookAt (origin);
			} else {
				// Change random direction
				rb.AddTorque (0, turnSpeed * Random.Range (-1, 1), 0, ForceMode.Impulse);
			}

			// Don't forget to reset the counter
			counter = 0;
		} else if (counter < cycleTime * swimSustainRatio) {
			// Set swim direction
			rb.AddForce (gameObject.transform.forward * swimSpeed, ForceMode.Impulse);
		}
	}
}
