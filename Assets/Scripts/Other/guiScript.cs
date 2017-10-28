using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guiScript : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 150, 100), "Chupa-Run!");

		if (GUI.Button (new Rect (10, 50, 110, 100), "Play")) {
			PlayButton ();
		} if (GUI.Button (new Rect (130, 50, 110, 100), "Options")) {
			OptionsButton ();
		}

	}

	void Leave() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}

	//rename this appropriately
	void PlayButton() {
		SceneManager.LoadScene(1);
	}

	void OptionsButton() {
		SceneManager.LoadScene (2);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Leave ();
	}
}
