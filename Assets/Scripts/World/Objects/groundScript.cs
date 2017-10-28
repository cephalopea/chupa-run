using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScript : touchableScript {

	//problems: maybe spawn more stuff
	
	Vector3 groundVector;
	float xParameterA;
	float xParameterB;
	bool reproducedBool = false;
		
	void TagSwap() {
		GameObject oldGround = GameObject.FindWithTag ("newGround");
		oldGround.tag = "oldGround";
		this.tag = "newGround";
	}
		
	void GetLocation() {
		groundVector = this.transform.position;
		xParameterA = (groundVector.x - 250);
		xParameterB = (groundVector.x + 250);
	}

	void AddStuff() {
		int numberOfObstacles = 20;
		float groundWidth = 500;
		float intervalFloat = (groundWidth/numberOfObstacles);
		float xLocationA = xParameterA + intervalFloat;
		float xLocationC = xParameterA + groundWidth;

		for (int i = 0; i < numberOfObstacles; i++) {
			int obstacleSelector = Random.Range (0, 7);
			if (xLocationA < xLocationC) {
				if (obstacleSelector == 0 || obstacleSelector == 6) {
					GameObject house = Instantiate (Resources.Load ("house")) as GameObject;
					float randomX = Random.Range ((xLocationA + 6), (xLocationA + intervalFloat - 6));
					Vector3 houseVector = new Vector3 (randomX, 3, 0);
					house.transform.position = houseVector;
					xLocationA = randomX;
				} else if (obstacleSelector == 1) {
					GameObject tornado = Instantiate (Resources.Load ("tornado")) as GameObject;
					float randomX = Random.Range ((xLocationA + 2), (xLocationA + intervalFloat - 2));
					Vector3 tornadoVector = new Vector3 (randomX, 1.5f, 0);
					tornado.transform.position = tornadoVector;
					xLocationA = randomX;
				} else if (obstacleSelector == 2) {
					GameObject trap = Instantiate (Resources.Load ("trap")) as GameObject;
					float randomX = Random.Range ((xLocationA + 1.5f), (xLocationA + intervalFloat - 1.5f));
					Vector3 trapVector = new Vector3 (randomX, 1, 0);
					trap.transform.position = trapVector;
					xLocationA = randomX;
				} else if (obstacleSelector == 3) {
					GameObject cactus = Instantiate (Resources.Load ("cactus")) as GameObject;
					float randomX = Random.Range ((xLocationA + 1), (xLocationA + intervalFloat - 1));
					Vector3 cactusVector = new Vector3 (randomX, 2, 0);
					cactus.transform.position = cactusVector;
					xLocationA = randomX;
				} else if (obstacleSelector == 4) {
					GameObject goat = Instantiate (Resources.Load ("goat")) as GameObject;
					float randomX = Random.Range ((xLocationA + 1), (xLocationA + intervalFloat - 1));
					Vector3 goatVector = new Vector3 (randomX, 2, 0);
					goat.transform.position = goatVector;
					xLocationA = randomX;
				} else if (obstacleSelector == 5) {
					GameObject kid = Instantiate (Resources.Load ("kid")) as GameObject;
					float randomX = Random.Range ((xLocationA + .5f), (xLocationA + intervalFloat - .5f));
					Vector3 kidVector = new Vector3 (randomX, 1, 0);
					kid.transform.position = kidVector;
					xLocationA = randomX;
				} else {
					//do nothing
				}
				xLocationA = (xLocationA + intervalFloat); 
			} else {
				//do nothing
			}
		}
	}

	void TrackPlayer() {
		GameObject player = GameObject.FindWithTag ("chupacabra");
		float playerLocation = player.GetComponent<touchableScript> ().xPosition;
		if (playerLocation > (xParameterB + 100)) {
			Despawn ();
		} else if (playerLocation >= groundVector.x && reproducedBool == false) {
			Reproduce ();
		} else {
			//do nothing
		}
	}

	//gets rid of this ground
	void Despawn () {
		GameObject me = this.gameObject;
		Destroy (me);
	}

	//makes next ground
	void Reproduce() {
		reproducedBool = true;
		Vector3 newGroundSpot = new Vector3 ((250 + xParameterB), this.transform.position.y, this.transform.position.z);
		GameObject nextGround = Instantiate (Resources.Load ("ground")) as GameObject;
		nextGround.transform.position = newGroundSpot;
	}

	// Use this for initialization
	void Start () {
		TagSwap ();
		GetLocation ();
		AddStuff ();
	}
	
	// Update is called once per frame
	void Update () {
		TrackPlayer ();
	}
}
