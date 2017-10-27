using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobScript : MonoBehaviour {

	//to-do: change mob speed based on player

	float speed = 8.0f;
	Rigidbody mobBody;
	Vector3 speedVector;
	int kidCount;
	public int adjustableKidCount;
	bool fasterChase;
	float previousSpeed;
	float chupPosition;

	void StartEndlessChase() {
		mobBody = this.gameObject.GetComponent<Rigidbody>();
		speedVector = new Vector3 (1, mobBody.velocity.y, 0);

		mobBody.velocity = (speedVector * speed);
	}

	//makes mob chase, endlessly
	void UpdateEndlessChase () {
		Vector3 awkwardFix = new Vector3 ((speedVector.x * speed), speedVector.y, speedVector.z);

		if (mobBody.velocity.x < speed) {
			mobBody.velocity = awkwardFix;
		}
	}

	//decides if mob needs to chase player faster
	void GetKidCount() {
		if (adjustableKidCount > kidCount) {
			GameObject chupacabra = GameObject.FindWithTag ("chupacabra");

			chupPosition = chupacabra.GetComponent<touchableScript> ().xPosition;
			previousSpeed = speed;
			fasterChase = true;
			speed = (speed * 1.5f);

			//do this last
			kidCount = adjustableKidCount;
		} else {
			//do nothing
		}
	}

	void FasterChase() {
		if (fasterChase == true) {
			if (this.transform.position.x < chupPosition) {
				//do nothing
			} else if (this.transform.position.x <= chupPosition) {
				fasterChase = false;
				speed = previousSpeed;
			}
		} else {
			//do nothing
		}
	}

	// Use this for initialization
	void Start () {
		StartEndlessChase ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateEndlessChase ();
		GetKidCount ();
		FasterChase ();
	}
}
