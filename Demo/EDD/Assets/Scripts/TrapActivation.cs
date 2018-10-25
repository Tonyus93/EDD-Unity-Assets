using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour {

	public GameObject trap;

	void OnTriggerEnter2D (Collider2D col) {
		trap.GetComponent<Rigidbody2D> ().simulated = true;
		Destroy (gameObject);
	}
}
