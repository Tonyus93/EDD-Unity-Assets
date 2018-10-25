using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	public AudioSource audio;

	void OnTriggerEnter2D (Collider2D col) {
		audio.Play ();
		Destroy (gameObject);
	}
}
