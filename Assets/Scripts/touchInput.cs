using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray,hit, 100)) {
			print ("Hit something!");
		}
	}
}
