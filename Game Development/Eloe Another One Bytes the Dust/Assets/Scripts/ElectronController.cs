using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronController : MonoBehaviour {
	public GameObject bullet;
	GameController gc;

	// Use this for initialization
	void Start () {
		gc = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "One") {
			Destroy (bullet);
			gc.IncreaseScore (1);
		}
		if (collision.gameObject.tag == "Zero") {
			Destroy (bullet);
			gc.IncreaseScore (-1);
		}
	}
}
