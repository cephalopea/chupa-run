using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchableScript : MonoBehaviour {

	//problems: things spawning at wrong height- tornadoes too high, houses too high, too tired to work on this rn

	//now other stuff can find this
	public float xPosition = default(float);
	public float yPosition = default(float);
	public float zPosition = default(float);
	//so things know how big this is
	public float height;
	public float width;

	//sets height and width
	void GetSize() {
		height = this.transform.lossyScale.y;
		width = this.transform.lossyScale.x;
	}

	//updates this object's position for other objects to use and updates player's position for this object
	void GetXPositions() {
		xPosition = this.transform.position.x;
		yPosition = this.transform.position.y;
		zPosition = this.transform.position.z;
	}

	void DefunctDespawn() {
		float playerPosition = GameObject.FindWithTag ("chupacabra").GetComponent<touchableScript> ().xPosition;

		if (xPosition < (playerPosition - Screen.width)) {
			if (this.tag == "mob" || this.tag == "newGround" || this.tag == "oldGround" || this.tag == "chupacabra") {
				//do nothing
			} else {
				GameObject me = this.gameObject;
				Destroy (me);
			}
		} else {
			//do nothing
		}
	}

	// Use this for initialization
	void Start () {
		GetSize ();
	}
	
	// Update is called once per frame
	void Update () {
		GetXPositions ();
		DefunctDespawn ();
	}
}
