using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
	GameObject player;
	GameObject mob;
	float playerPosition = default(float);
	float playerAltitude = default(float);
	float mobPosition = default(float);
	float followSpot = default(float);

	//finds the chup and the mob
	void FindThings(){
		player = GameObject.FindWithTag ("chupacabra");
		mob = GameObject.FindWithTag ("mob");
	}

	//gets chup and mob positions and decides where to put camera
	void WhoToFollow() {
		player.GetComponent<playerScript> ().GetX(playerPosition);
		player.GetComponent<touchableScript> ().GetY(playerAltitude);
		mob.GetComponent<mobScript> ().GetX(mobPosition);

		if ((Mathf.Abs(playerPosition - mobPosition)) < 50f) {
			followSpot = (((mobPosition + 40) + playerPosition)/2);
			this.transform.position = new Vector3 (followSpot, playerAltitude, -20);
		} else {
			this.transform.position = new Vector3 (playerPosition, playerAltitude, -20);;
		}
	}

	// Use this for initialization
	void Start () {
		FindThings ();
	}
	
	// Update is called once per frame
	void Update () {
		WhoToFollow ();
	}
}
