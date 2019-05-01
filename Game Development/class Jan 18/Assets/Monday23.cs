using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monday23 : MonoBehaviour {
	public string scripterName;
	public bool parkedLegally;
	public GameObject groundTile;
	private float distPerSec = 1.0f;
	//const float MAX_SPEED = 7.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Move steadily across
		//transform.Translate (distPerSec*Time.deltaTime, 0.0f, 0.0f);
		//Move with input
		float distance = distPerSec * Time.deltaTime*Input.GetAxis("Horizontal");
		transform.Translate (distance, 0, 0);
	}
	/*void FixedUpdate(){
		float deltaX = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (deltaX * MAX_SPEED, 0f);
	}*/
}
