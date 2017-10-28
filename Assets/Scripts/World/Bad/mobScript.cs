using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mobScript : touchableScript {

	//used by FindChup()
	GameObject chupacabra;
	playerScript chupScript;
	//used by StartEndlessChase(), UpdateEndlessChase(), GetKidCount(), FasterChase()
	float speed = 8.0f;
	//used by StartEndlessChase(), UpdateEndlessChase()
	Rigidbody mobBody;
	Vector3 speedVector;
	//used by GetKidCount()
	int kidCount;
	public int adjustableKidCount;
	//used by GetKidCount(), FasterChase()
	bool fasterChase;
	float previousSpeed;
	float chupPosition = default(float);
	//used by Restart()
	float liveChupPosition = default(float);

	//finds the player and attached player script, sets them to local variables for later use
	void FindChup() {
		chupacabra = GameObject.FindWithTag ("chupacabra");
		chupScript = chupacabra.GetComponent<playerScript> ();
	}

	//starts mob chasing
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
			chupScript.GetX(chupPosition);
			previousSpeed = speed;
			fasterChase = true;
			speed = (speed * 1.5f);

			//do this last
			kidCount = adjustableKidCount;
		} else {
			//do nothing
		}
	}
		
	//makes the mob chase faster to where the player last ate a kid, then reverts speed when mob reaches that point
	void FasterChase() {
		if (fasterChase == true) {
			if (this.transform.position.x < chupPosition) {
				//do nothing
			} else if (this.transform.position.x >= chupPosition) {
				fasterChase = false;
				speed = previousSpeed;
			}
		} else {
			//do nothing
		}
	}

	//restarts the level if the mob has caught the player
	void Restart() {
		chupScript.GetX (liveChupPosition);
		if ((this.transform.position.x + 25) >= liveChupPosition) {
			SceneManager.LoadScene ("lvl1");
		}
	}

	// Use this for initialization
	void Start () {
		FindChup ();
		StartEndlessChase ();
		SetColor (Color.red);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateEndlessChase ();
		GetKidCount ();
		FasterChase ();
		Restart ();
	}
}
