using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactusScript : objectScript {

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
		DefunctDespawn (2f, this.gameObject);
	}
}
