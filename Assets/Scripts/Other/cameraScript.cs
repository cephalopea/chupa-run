using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
	float playerPosition = default(float);
	float playerAltitude = default(float);
	float mobPosition = default(float);
	float followSpot = default(float);

	//gets chup and mob positions and decides where to put camera
	void WhoToFollow() {
		playerScript player = GameObject.FindWithTag ("chupacabra").GetComponent<playerScript> ();
		playerPosition = player.x;
		playerAltitude = player.y;
		mobPosition = GameObject.FindWithTag ("mob").GetComponent<mobScript>().x;

		if ((playerPosition - mobPosition) < 50f) {
			followSpot = (((mobPosition + 40) + playerPosition)/2);
			this.transform.position = new Vector3 (followSpot, playerAltitude + 5, -20);
		} else {
			this.transform.position = new Vector3 (playerPosition, playerAltitude + 5, -20);
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		WhoToFollow ();
	}
}
