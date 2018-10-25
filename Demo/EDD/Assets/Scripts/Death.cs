using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public GameObject player;
	public GameObject canvas;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") { 
			player.GetComponent<Animator> ().SetTrigger ("death");
			canvas.SetActive (true);
			Destroy (player.GetComponent<Control> ());
		}
	}
}
