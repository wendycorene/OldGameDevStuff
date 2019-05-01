using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
	//I got a BUNCH of the jumping stuff from Duncan's example
	Rigidbody2D player;
	const float MAX_FORCE_HORIZONTAL = 5.0f;
	private bool canJump = true;
	public Text deadTxt;
	public Text winTxt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		float up = Input.GetAxis ("Horizontal") * MAX_FORCE_HORIZONTAL;
		Debug.Log (player.velocity);
		player.velocity = new Vector2(up, player.velocity.y);

		if (canJump && Input.GetKey(KeyCode.Space))
		{
			player.AddForce(new Vector2(0, 200));
			canJump = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Ground") { // Allow the player to jump if they touch the ground
			canJump = true;
		}
		if (collision.collider.tag == "Death") {
			deadTxt.text = "GAME OVER";
		}
		if (collision.collider.tag == "Win") {
			winTxt.text = "YOU WIN";
		}
	}
}
