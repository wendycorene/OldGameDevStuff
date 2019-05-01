using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D player;
	const float MAX_FORCE_HORIZONTAL = 5.0f;
	const float MAX_FORCE_VERTICAL = 20.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		player.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * MAX_FORCE_HORIZONTAL, 0.0f));
		if (Input.GetKey (KeyCode.Space)) {
			player.AddForce (new Vector2 (0.0f, MAX_FORCE_VERTICAL));
		}
	}
}
