using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sliderScript : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (10, 10, 150, 100), "This slider doesn't do anything!");
		if (GUI.Button (new Rect (150, 10, 110, 100), "Back")) {
			SceneManager.LoadScene (0);
		}
	}

	void OnClick() {
		SceneManager.LoadScene (0);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
