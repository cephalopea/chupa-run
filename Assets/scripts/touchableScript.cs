using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class touchableScript : MonoBehaviour {

	//now other stuff can find this
	public float xPosition = default(float);
	public float yPosition = default(float);

	//updates this object's position for other objects to use and updates player's position for this object
	void SetPositions() {
		xPosition = this.transform.position.x;
		yPosition = this.transform.position.y;
	}

	public void GetX(float x) {
		x = xPosition;
	}

	public void GetY(float y) {
		y = yPosition;
	}

	void SetColor(){
		if (this.tag == "trap" || this.tag == "mob" || this.tag == "tornado") {
			this.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		} else if (this.tag == "newGround" || this.tag == "house") {
			this.gameObject.GetComponent<Renderer> ().material.color = Color.black;
		} else if (this.tag == "chupacabra") {
			this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		} else if (this.tag == "kid" || this.tag == "goat") {
			this.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
		}
	}

	void FixZ() {
		Vector3 FixedZ = new Vector3 (this.transform.position.x, this.transform.position.y, 0);
		this.transform.position = FixedZ;
	}

	void Despawn() {
		float playerPosition;
		float mobPosition;

		GameObject.FindWithTag ("mob").GetComponent<touchableScript> ().GetX(mobPosition);
		GameObject.FindWithTag ("chupacabra").GetComponent<touchableScript> ().GetX(playerPosition);

		if (xPosition < (playerPosition - 100) || (xPosition <= mobPosition + 33)) {
			if (this.tag == "mob" || this.tag == "newGround" || this.tag == "oldGround" || this.tag == "chupacabra") {
				//do nothing
			} else {
				GameObject me = this.gameObject;
				Destroy (me);
			}
		} else if ((mobPosition + 25) >= playerPosition && this.tag == "mob"){
			SceneManager.LoadScene("lvl1");
		} else {
			//do nothing
		}
	}

	// Use this for initialization
	void Start () {
		SetColor ();
	}
	
	// Update is called once per frame
	void Update () {
		SetPositions ();
		FixZ ();
		Despawn ();
	}
}
