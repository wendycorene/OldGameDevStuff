using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	private float distPerSec = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float leftright = distPerSec * Time.deltaTime*Input.GetAxis("Horizontal");
		float updown = distPerSec * Time.deltaTime * Input.GetAxis ("Vertical");
		transform.Translate (leftright, updown, 0);
	}
}
