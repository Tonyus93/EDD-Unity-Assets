using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

	public void respawn () {
		Application.LoadLevel(Application.loadedLevel);
	}
}
