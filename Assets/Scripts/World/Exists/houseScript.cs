using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseScript : objectScript {

	public float x;

	void GetPosition() {
		x = this.transform.position.x;
	}

	// Use this for initialization
	void Start () {
		GetPosition ();
		SetColor (Color.black);
	}

	// Update is called once per frame
	void Update () {
		DefunctDespawn (20f, this.gameObject);
	}
}
