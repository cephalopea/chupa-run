using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : touchableScript {

	public void DefunctDespawn(float width) {
		float playerPosition = default(float);
		float mobPosition = default(float);

		GameObject.FindWithTag ("mob").GetComponent<mobScript> ().GetX(mobPosition);
		GameObject.FindWithTag ("chupacabra").GetComponent<playerScript> ().GetX(playerPosition);
		if (this.transform.position.x < (playerPosition - 100) || (this.transform.position.x <= mobPosition + 25 + width/2)) {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
