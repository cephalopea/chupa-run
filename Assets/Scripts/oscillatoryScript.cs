using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillatoryScript : touchableScript {
	//the name of this script used to make more sense than it does now, but whatever

	int kidCount = 0;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "chupacabra") {
			if (this.tag == "kid") {
				GameObject me = this.gameObject;
				GameObject mob = GameObject.FindWithTag ("mob");
				kidCount = mob.GetComponent<mobScript> ().adjustableKidCount;

				mob.GetComponent<mobScript> ().adjustableKidCount = (kidCount + 1);
				Destroy (me);
			} else if (this.tag == "mob") {
				//do nothing
			} else {
				//goat, tornado, cactus
				GameObject me = this.gameObject;
				Destroy (me);
			}
		} else {
			//do nothing
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
