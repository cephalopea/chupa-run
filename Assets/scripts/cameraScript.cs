using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	void WhoToFollow() {
		GameObject player = GameObject.FindWithTag ("chupacabra");
		GameObject mob = GameObject.FindWithTag ("mob");
		float playerPosition = player.GetComponent<touchableScript> ().xPosition;
		float playerHeight = player.GetComponent<touchableScript> ().yPosition;
		float mobPosition = mob.GetComponent<touchableScript> ().xPosition;

		if ((playerPosition - mobPosition) < Screen.width) {
			float mobWidth = mob.GetComponent<touchableScript>().width;
			float followSpot = (mobPosition + mobWidth/4) + (Screen.width/2);
			Vector3 followVector = new Vector3 (followSpot, playerHeight, this.transform.position.z);
			this.transform.position = followVector;
		} else {
			Vector3 followVector = new Vector3 (playerPosition, this.transform.position.y, this.transform.position.z);
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
