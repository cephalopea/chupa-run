using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScript : touchableScript {

	public float startSpot = default(float);

	public void DefunctDespawn(float width, GameObject me) {
		float playerPosition = default(float);
		float mobPosition = default(float);

		mobPosition = GameObject.FindWithTag ("mob").GetComponent<mobScript> ().x;
		playerPosition = GameObject.FindWithTag ("chupacabra").GetComponent<playerScript> ().x;
		if (me.transform.position.x < (playerPosition - 100) || (me.transform.position.x <= mobPosition + 25 + width/2)) {
			Destroy (me);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
