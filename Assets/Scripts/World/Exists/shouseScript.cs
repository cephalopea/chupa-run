using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shouseScript : objectScript {

	public float x;

	void GetPosition(){
		x = this.transform.position.x;
	}

	// Use this for initialization
	void Start () {
		SetColor (Color.black);
	}
	
	// Update is called once per frame
	void Update () {
		GetPosition ();
		//DefunctDespawn (0.1f, this.gameObject);
	}
}
