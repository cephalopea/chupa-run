using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapScript : objectScript {

	public float x;

	void GetPosition() {
		x = this.transform.position.x;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "chupacabra") {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		SetColor (Color.red);
	}

	// Update is called once per frame
	void Update () {
		GetPosition ();
		DefunctDespawn (4f, this.gameObject);
	}
}
