using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : touchableScript {

	//to-do:
	//-make obstacle spawn related to speed, so you can get around obstacles more easily (something about forcemode.impulse maybe)

	//change speed to change speed
	float speed = 10.0f;
	//used for tornado jumping
	Vector3 jump;
	//used for jumping off of the side of a house
	Vector3 unstuckJump;
	Vector3 stuckJump;
	//used to move backwards to try to avoid obstacles
	Vector3 back;
	float jumpForce = 4.0f;
	Rigidbody myBody;
	bool isJumping;
	GameObject touched;
	bool touchedTrap;
	Vector3 speedVector;
	GameObject whatTrap;
	float mobDistance;

	//prints distance from mob onscreen so you know how dead ya are
	void OnGUI () {
		GUI.Label (new Rect (10, 10, 150, 100), "Distance from Mob: " + mobDistance);
	}

	//sets the speed at which player runs, endlessly
	void StartEndlessRun() {
		myBody = this.gameObject.GetComponent<Rigidbody>();
		speedVector = new Vector3 (1, myBody.velocity.y, 0);

		myBody.velocity = (speedVector * speed);
	}

	//helps ensure the player stays moving forwards/at a min speed, unless trapped
	void UpdateEndlessRun () {
		if (touchedTrap == true) {
			//do nothing
		} else {
			Vector3 awkwardFix = new Vector3 ((speedVector.x * speed), speedVector.y, speedVector.z);

			if (myBody.velocity.y <= 0.5f) {
				if (-0.5f <= myBody.velocity.y) {
					isJumping = false;
				} else {
					isJumping = true;
				}
			} if (myBody.velocity.x < speed) {
				myBody.velocity = awkwardFix;
			} if (speed < 3.0f) {
				speed = 3.0f;
			}
		}
	}

	void UpdateMobDistance() {
		float mobSpot = default(float);
		GameObject.FindWithTag ("mob").GetComponent<mobScript> ().GetX(mobSpot);
		mobDistance = this.transform.position.x - mobSpot;
	}
		
	//jump function, add to start
	void JumpStart(){
		unstuckJump = new Vector3 (0f, 3f, 0f);
		stuckJump = new Vector3 (0f, 25f, 0f);
		back = new Vector3 (-20f, 0f, 0f);
	}
		
	//jump function, add to update, also lets you exit game to menu
	void JumpUpdate(){
		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false || Input.GetKeyDown (KeyCode.W) && isJumping == false) {
			myBody.AddForce (jump * jumpForce, ForceMode.Impulse);
			isJumping = true;
		} if (Input.GetKeyDown (KeyCode.A)) {
			myBody.AddForce(back, ForceMode.Impulse);
		} if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene(0);
		}
	}

	//checks if the player done dead
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "kid") {
			speed = (speed * 1.5f);
		} else if (col.gameObject.tag == "goat") {
			speed = (speed * 1.25f);
		} else if (col.gameObject.tag == "cactus") {
			speed = (speed * 0.75f);
		} else if (col.gameObject.tag == "tornado") {
			speed = (speed * 0.5f);
			myBody.AddForce(jump * jumpForce, ForceMode.Impulse);
		} else if (col.gameObject.tag == "houseSide") {
			touched = col.gameObject;
			HouseSide ();
		} else if (col.gameObject.tag == "newGround" || col.gameObject.tag == "oldGround") {
			isJumping = false;
			jump = unstuckJump;
		} else if (col.gameObject.tag == "trap") {
			whatTrap = col.gameObject;
			if (touchedTrap == true) {
				//nothing
			} else {
				StartCoroutine (TouchedTrap ());
			}
		} else {
			Debug.Log ("OH DEAR GOD WHAT DID I STEP ON?! (playerScript.OnCollisionEnter())");
		}
	}

	//stops player for 3s when in a trap, and removes them from the trap so they aren't stuck over and over
	IEnumerator TouchedTrap() {
		touchedTrap = true;
		float xPosition = default(float);
		GetX (xPosition);
		float trapWidth = 4f;
		float trapLocation = default(float);
		whatTrap.GetComponent<badObjectScript> ().GetX (trapLocation);
		float playerWidth = 2f;
		float trappedDepth = ((trapLocation + trapWidth / 2) - (xPosition - (playerWidth/2)));
		float previousSpeed = speed;
		speed = 0;
		this.gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		Vector3 untrapped = new Vector3 ((this.transform.position.x + trappedDepth + 0.1f), this.transform.position.y, this.transform.position.z);
		this.transform.position = untrapped;

		yield return new WaitForSeconds (2);

		speed = previousSpeed;
		touchedTrap = false;
	}

	void HouseSide() {
		float elevation = default(float);
		float houseHeight = 6f;
		float houseLocation = default(float);

		this.GetComponent<shouseScript> ().GetY (elevation);
		touched.GetComponent<shouseScript> ().GetX(houseLocation);

		if (elevation <= houseHeight) {
			isJumping = false;
			if (elevation <= 5.5f) {
				jump = stuckJump;
			} else {
				//do nothing
			}
		} else {
			jump = unstuckJump;
		}
	}
		
	//restarts the level when you die
	void IsDead() {
		SceneManager.LoadScene(1);
	}

	// Use this for initialization
	void Start () {
		SetColor (Color.cyan);
		StartEndlessRun ();
		JumpStart ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateEndlessRun ();
		JumpUpdate ();
		UpdateMobDistance ();
	}
}
