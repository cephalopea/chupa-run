using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class touchableScript : MonoBehaviour {

	//to-do: add part of despawn to mobScript and take it out of this one

	//now other stuff can find this
	public float xPosition = default(float);
	public float yPosition = default(float);

	//updates this object's position for other objects to use and updates player's position for this object
	public void SetPositions() {
		xPosition = this.transform.position.x;
		yPosition = this.transform.position.y;
	}

	//gets an object's x position and sets a passed float to that position
	public void GetX(float x) {
		x = xPosition;
	}

	//gets an object's y position and sets a passed float to that position
	public void GetY(float y) {
		y = yPosition;
	}

	//this should be redone so it isn't dependent on tags
	//potentially pass it a color?
	public void SetColor(Color gimme){
		this.gameObject.GetComponent<Renderer> ().material.color = gimme;
	}

	//manually fixes an object's z coordinate
	public void FixZ() {
		Vector3 FixedZ = new Vector3 (this.transform.position.x, this.transform.position.y, 0);
		this.transform.position = FixedZ;
	}

	//redo so it doesn't depend on tags
	public void Despawn() {
		float playerPosition;
		float mobPosition;

		//redo these two lines once objects no longer are assigned touchableScripts
		GameObject.FindWithTag ("mob").GetComponent<touchableScript> ().GetX(mobPosition);
		GameObject.FindWithTag ("chupacabra").GetComponent<touchableScript> ().GetX(playerPosition);

		if (xPosition < (playerPosition - 100) || (xPosition <= mobPosition + 33)) {
			GameObject me = this.gameObject;
			Destroy (me);

		//this part should be a separate function in mobScript
		} else if ((mobPosition + 25) >= playerPosition && this.tag == "mob"){
			SceneManager.LoadScene("lvl1");
		} else {
			//do nothing
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
