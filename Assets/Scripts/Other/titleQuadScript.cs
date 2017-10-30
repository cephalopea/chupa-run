using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleQuadScript : MonoBehaviour {

	void PlaneColor() {
		Color planeColor = Color.black;
		Material materialColored = new Material (Shader.Find ("Diffuse"));
		materialColored.color = planeColor;
		this.GetComponent<Renderer>().material = materialColored;
	}

	// Use this for initialization
	void Start () {
		PlaneColor ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
