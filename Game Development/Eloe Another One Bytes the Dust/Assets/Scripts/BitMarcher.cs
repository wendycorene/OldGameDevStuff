using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitMarcher : MonoBehaviour {
	GameController gc;

	// Use this for initialization
	void Start () {
		StartCoroutine ("MoveIt");
		gc = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MoveIt(){
		for (;;) {
			yield return new WaitForSeconds (1);
			transform.Translate (0, -.4f, 0);
		}
	}

	private void OnCollisionEnter2D (Collision2D touch) {
		if (touch.gameObject.tag == "Ground") {
			Destroy (gameObject);
			gc.AnotherBitDestroyed ();
		}
		if (touch.gameObject.tag == "Electron") {
			Destroy (gameObject);
			gc.AnotherBitDestroyed ();
		}
	}
}
