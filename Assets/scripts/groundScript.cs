using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScript : MonoBehaviour {

	//problems: starting game spawns 2 ground, both at the same spot, one tagged oldGround and one tagged newGround
	//things still fall through this
	//fuck
	
	Vector3 groundVector;
	float xParameterA = default(float);
	float xParameterB = default(float);
		
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

	/*
	void SetSize() {
		Vector3 groundScale = new Vector3 (500, Screen.height/2, 0);
		this.transform.localScale = groundScale;
	}
	*/

	void AddStuff() {
		float xLocationA = xParameterA;
		float xLocationB = xParameterA;
		int numberOfObstacles = 50;
		int numberOfBoosts = 10;

		for (int i = 0; i < numberOfObstacles; i++) {
			int obstacleSelector = Random.Range (0, 3);
	
			if (obstacleSelector == 0) {
				GameObject trap = Instantiate (Resources.Load ("trap")) as GameObject;
				float trapWidth = trap.GetComponent<touchableScript> ().width;
				float trapHeight = trap.GetComponent<touchableScript> ().height;
				float randomX = Random.Range ((xLocationA + trapWidth/2), (xLocationA + 50 - trapWidth/2));
				Vector3 trapVector = new Vector3 (randomX, trapHeight / 2, 0);
				trap.transform.position = trapVector;
			} else if (obstacleSelector == 1) {
				GameObject tornado = Instantiate(Resources.Load("tornado")) as GameObject;
				float tornadoWidth = tornado.GetComponent<touchableScript> ().width;
				float tornadoHeight = tornado.GetComponent<touchableScript> ().height;
				float randomX = Random.Range ((xLocationA + tornadoWidth/2), (xLocationA + 50 - tornadoWidth/2));
				Vector3 tornadoVector = new Vector3 (randomX, tornadoHeight / 2, 0);
				tornado.transform.position = tornadoVector;
			} else if (obstacleSelector == 2) {
				GameObject house = Instantiate(Resources.Load("house")) as GameObject;
				float houseWidth = house.GetComponent<touchableScript> ().width;
				float houseHeight = house.GetComponent<touchableScript> ().height;
				float randomX = Random.Range ((xLocationA + houseWidth/2), (xLocationA + 50 - houseWidth/2));
				Vector3 houseVector = new Vector3 (randomX, 0, 0);
				house.transform.position = houseVector;
			} else if (obstacleSelector == 3) {
				GameObject cactus = Instantiate(Resources.Load("cactus")) as GameObject;
				float cactusWidth = cactus.GetComponent<touchableScript> ().width;
				float cactusHeight = cactus.GetComponent<touchableScript> ().height;
				float randomX = Random.Range ((xLocationA + cactusWidth/2), (xLocationA + 50 - cactusWidth/2));
				Vector3 cactusVector = new Vector3 (randomX, cactusHeight / 2, 0);
				cactus.transform.position = cactusVector;
			} else {
				//do nothing
			}
			xLocationA = (xLocationA + 50);

		} 
		for (int i = 0; i < numberOfBoosts; i++) {
			int boostSelector = Random.Range (0, 1);

			if (boostSelector == 0) {
				GameObject goat = Instantiate(Resources.Load("goat")) as GameObject;
				float goatWidth = goat.GetComponent<touchableScript> ().width;
				float goatHeight = goat.GetComponent<touchableScript> ().height;
				float randomX = Random.Range ((xLocationA + goatWidth/2), (xLocationA + 50 - goatWidth/2));
				Vector3 goatVector = new Vector3 (randomX, goatHeight / 2, 0);
				goat.transform.position = goatVector;
			} else if (boostSelector == 1) {
				GameObject kid = Instantiate(Resources.Load("kid")) as GameObject;
				float kidWidth = kid.GetComponent<touchableScript> ().width;
				float kidHeight = kid.GetComponent<touchableScript> ().height;
				float randomX = Random.Range ((xLocationA + kidWidth/2), (xLocationA + 50 - kidWidth/2));
				Vector3 kidVector = new Vector3 (randomX, kidHeight / 2, 0);
				kid.transform.position = kidVector;
			} else {
				//do nothing
			}
			xLocationB = (xLocationB + 125);
		}
	}

	void TrackPlayer() {
		GameObject player = GameObject.FindWithTag ("chupacabra");
		float playerLocation = player.GetComponent<touchableScript> ().xPosition;
		if (playerLocation > (xParameterB + Screen.width)) {
			Despawn ();
		} else if (playerLocation == groundVector.x) {
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
		Vector3 newGroundSpot = new Vector3 ((250 + xParameterB), this.transform.position.y, this.transform.position.z);
		GameObject nextGround = Instantiate (Resources.Load ("ground")) as GameObject;
		nextGround.transform.position = newGroundSpot;
	}

	// Use this for initialization
	void Start () {
		TagSwap ();
		GetLocation ();
		AddStuff ();
		//SetSize ();
	}
	
	// Update is called once per frame
	void Update () {
		TrackPlayer ();
	}
}
