﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision){
		// Destroy users bullet on any collision.
		Destroy (gameObject);
	}
}
