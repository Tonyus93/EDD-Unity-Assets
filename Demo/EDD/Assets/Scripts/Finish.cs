using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

	public GameObject player;
	public GameObject canvas;
	public GameObject textObject;
	public SpriteRenderer chest;
	public Sprite openChest;
	public string text;

	void OnTriggerEnter2D (Collider2D col) {
		textObject.GetComponent<Text> ().text = text;
		chest.sprite = openChest;
		canvas.SetActive (true);
		Destroy(player.GetComponent<Control> ());
		Destroy (gameObject);
	}
}
