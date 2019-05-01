using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

	private bool gameIsPlaying = true;

	// Use this for initialization
	void Start () {
		moveElevator ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void moveElevator() {

		transform.Translate (new Vector2(0,1) * 1 * Time.deltaTime);


	}
}
