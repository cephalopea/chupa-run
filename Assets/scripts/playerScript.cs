using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

	//problems: falls through ground

	//mobScript uses to decide if mob needs to speed up or not
	public string playerTouched;
	//change speed to change speed
	float speed = 0.1f;
	//used for jumping
	Vector2 jump;
	float jumpForce = 4.0f;
	Rigidbody2D myBody;
	bool isJumping;

	void SetLocation() {
		this.transform.position = new Vector3 (0f, 20f, 0f);
		//remove green color once sprites are added
		this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
	}

	/*
	//changes sprite if jumping
	void Animate() {

	}
	*/

	//sets the speed at which player runs, endlessly
	void EndlessRun () {
		Vector3 moveVector = new Vector3 ((this.transform.position.x + speed), this.transform.position.y, this.transform.position.z);
		this.transform.position = moveVector;
		//running = (running + 1);
	}

	//jump function, add to start
	void JumpStart(){
		myBody = this.gameObject.GetComponent<Rigidbody2D>();
		jump = new Vector2 (0.0f, 3.0f);
	}
		
	//jump function, add to update
	void JumpUpdate(){
		if(Input.GetKeyDown(KeyCode.Space) && isJumping == false){
			myBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			isJumping = true;
		}
	}

	//checks if the player done dead
	void OnCollisionEnter2D(Collision2D col) {
		playerTouched = col.gameObject.tag;
		if (col.gameObject.tag == "kid") {
			speed = (speed * 1.5f);
			//runningII = (runningII + 12);
		} else if (col.gameObject.tag == "goat") {
			speed = (speed * 1.25f);
			//runningII = (runningII + 6);
		} else if (col.gameObject.tag == "mob") {
			IsDead ();
		} else if (col.gameObject.tag == "cactus") {
			speed = (speed * 0.75f);
			//runningII = (runningII - 6);
		} else if (col.gameObject.tag == "tornado") {
			speed = (speed * 0.5f);
			//runningII = (runningII - 12);
			myBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			isJumping = true;
		} else if (col.gameObject.tag == "house") {
			TouchedHouse ();
		} else if (col.gameObject.tag == "newGround" || col.gameObject.tag == "oldGround") {
			isJumping = false;
		} else if (col.gameObject.tag == "trap") {
			StartCoroutine (TouchedTrap ());
		} else {
			Debug.Log ("OH DEAR GOD WHAT DID I STEP ON?! (playerScript.OnCollisionEnter())");
		}
	}

	//decides if you've touched the front or side of a house, and responds accordingly
	void TouchedHouse() {
		float elevation = this.transform.position.x;
		float height = this.transform.lossyScale.y;
		float myElevation = (elevation - height / 2);
		float houseHeight = GameObject.FindWithTag("house").GetComponent<touchableScript>().height;

		if (myElevation > houseHeight) {
			isJumping = false;
		} else {
			while (myElevation <= houseHeight) {
				speed = 0;
			}
		}
	}

	//stops player for 3s when in a trap, and removes them from the trap so they aren't stuck over and over
	IEnumerator TouchedTrap() {
		float xPosition = this.transform.position.x;

		float trapWidth = GameObject.FindWithTag ("trap").GetComponent<touchableScript> ().width;
		float trapLocation = GameObject.FindWithTag ("trap").GetComponent<touchableScript> ().xPosition;
		float playerWidth = this.transform.lossyScale.x;
		float trappedDepth = ((trapLocation + trapWidth / 2) - (xPosition - (playerWidth/2)));
		float previousSpeed = speed;

		speed = 0;
		yield return new WaitForSeconds (3);
		Vector3 untrapped = new Vector3 ((this.transform.position.x + trappedDepth + 0.1f), this.transform.position.y, this.transform.position.z);
		this.transform.position = untrapped;
		speed = previousSpeed;
	}

	//restarts the level when you die
	void IsDead() {
		//restart the level, or whatever
	}

	// Use this for initialization
	void Start () {
		SetLocation ();
		JumpStart ();
	}
	
	// Update is called once per frame
	void Update () {
		//Animate ();
		EndlessRun ();
		JumpUpdate ();
	}
}
