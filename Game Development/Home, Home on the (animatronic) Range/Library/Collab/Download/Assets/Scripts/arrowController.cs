using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {
	private Rigidbody2D arrow;
	public GameObject player;
	private float distPerSec = 100.0f;

	// Use this for initialization
	void Start () {
		arrow = Resources.Load<Rigidbody2D>("arrow");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			Vector3 spawnSpot = player.transform.position;
			Rigidbody2D spawnedArrow = Instantiate (arrow, spawnSpot, Quaternion.identity);
			spawnedArrow.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (distPerSec, 0));
		}
	}
	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Deer") {
			Destroy(gameObject);
		}
	}
}