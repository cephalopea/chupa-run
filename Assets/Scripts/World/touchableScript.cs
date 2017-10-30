using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class touchableScript : MonoBehaviour {

	//sets object's color to passed color
	public void SetColor(Color gimme){
		this.gameObject.GetComponent<Renderer> ().material.color = gimme;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
