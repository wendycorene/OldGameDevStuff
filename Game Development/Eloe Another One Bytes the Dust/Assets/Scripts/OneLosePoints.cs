using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLosePoints : MonoBehaviour {
	public GameObject one;
	GameController gc;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {
			gc.IncreaseScore (-2);
		}
	}
}
