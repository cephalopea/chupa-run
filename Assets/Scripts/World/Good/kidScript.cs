using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kidScript : objectScript {

	int kidCount = 0;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "chupacabra") {
			GameObject mob = GameObject.FindWithTag ("mob");
			kidCount = mob.GetComponent<mobScript> ().adjustableKidCount;

			mob.GetComponent<mobScript> ().adjustableKidCount = (kidCount + 1);
			Destroy (this.gameObject);
		} else {
			//do nothing
		}
	}
	// Use this for initialization
	void Start () {
		SetColor (Color.green);
	}
	
	// Update is called once per frame
	void Update () {
		DefunctDespawn (2f, this.gameObject);
	}
}
