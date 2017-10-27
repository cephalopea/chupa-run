using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobScript : MonoBehaviour {

	float speed = 0.1f;

	//starts the mob just offscreen
	void SetStartSpot() {
		float startPoint = (0 - (Screen.width + 10));
		Vector3 startVector = new Vector3 (startPoint, this.transform.position.y, this.transform.position.z);
		this.transform.position = startVector;
	}

	//makes mob chase, endlessly
	void EndlessChase () {
		Vector3 moveVector = new Vector3 ((this.transform.position.x + speed), this.transform.position.y, this.transform.position.z);
		this.transform.position = moveVector;
		//chasingInt = (chasingInt + 1);
	}
		
	/*
	//controls animation effect
	void Animate() {
		
	}
	*/

	// Use this for initialization
	void Start () {
		SetStartSpot ();
	}
	
	// Update is called once per frame
	void Update () {
		EndlessChase ();
		//Animate ();
	}
}
