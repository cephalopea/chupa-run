using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class touchableScript : MonoBehaviour {
	
	//gets an object's x position and sets a passed float to that position
	public void GetX(float x) {
		x = this.transform.position.x;
	}

	//gets an object's y position and sets a passed float to that position
	public void GetY(float y) {
		y = this.transform.position.y;
	}

	//sets object's color to passed color
	public void SetColor(Color gimme){
		this.gameObject.GetComponent<Renderer> ().material.color = gimme;
	}

	//manually fixes an object's z coordinate
	public void FixZ() {
		Vector3 FixedZ = new Vector3 (this.transform.position.x, this.transform.position.y, 0);
		this.transform.position = FixedZ;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
