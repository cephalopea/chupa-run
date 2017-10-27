using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	void WhoToFollow() {
		GameObject player = GameObject.FindWithTag ("chupacabra");
		GameObject mob = GameObject.FindWithTag ("mob");
		float playerPosition = player.GetComponent<touchableScript> ().xPosition;
		float playerAltitude = player.GetComponent<touchableScript> ().yPosition;
		float mobPosition = mob.GetComponent<touchableScript> ().xPosition;

		if ((Mathf.Abs(playerPosition - mobPosition)) < 50f) {
			float followSpot = (((mobPosition + 40) + playerPosition)/2);
			Vector3 followVector = new Vector3 (followSpot, playerAltitude, -20);
			this.transform.position = followVector;
		} else {
			Vector3 followVector = new Vector3 (playerPosition, playerAltitude, -20);
			this.transform.position = followVector;
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
