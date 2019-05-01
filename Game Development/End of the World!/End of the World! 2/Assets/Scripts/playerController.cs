using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
	//I got a BUNCH of the jumping stuff from Duncan's example
	Rigidbody2D player;
	const float MAX_FORCE_HORIZONTAL = 5.0f;
	private bool canJump = true;
	public Text deadTxt;
	public Text winTxt;
	private bool canInput = true;
	private Animator animator;
	private SpriteRenderer sr;
	public bool firstFlip = false;
	public GameObject resetButton;
	AudioSource audio;
	public AudioClip win;
	public AudioClip lose;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
		player = this.GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		audio = GetComponent<AudioSource>();
		resetButton.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (canInput == true){
			float up = Input.GetAxis ("Horizontal") * MAX_FORCE_HORIZONTAL;
			player.velocity = new Vector2(up, player.velocity.y);

			//allows walking animation
			if (up > 0) {
				animator.SetInteger ("IsWalking", 1);
				animator.SetInteger ("IsJumping", 0);

			
				// Handles turning right
				if (firstFlip) {
					firstFlip = false;
					sr.flipX = false;
				}

			} else if (up < 0) {
				animator.SetInteger ("IsWalking", 1);
				animator.SetInteger ("IsJumping", 0);

				// Handles turning left
				if (firstFlip == false) {
					firstFlip = true;
					sr.flipX = true;
				} else if (firstFlip) {
					sr.flipX = true;
				}

			} else if (up == 0) {
				animator.SetInteger ("IsWalking", 0);

			}
		}

		//allows jumping.
		if (canJump && Input.GetKey(KeyCode.Space)) {
			player.AddForce(new Vector2(0, 300));
			animator.SetInteger ("IsJumping", 1);
			animator.SetInteger ("IsWalking", 0);
			canJump = false;
		}
	}

	
	
	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Ground") { // Allow the player to jump if they touch the ground
			canJump = true;
		}
		if (collision.collider.tag == "Death") {// Indicates the player has hit something that will kill them
			deadTxt.text = "GAME OVER";
			audio.PlayOneShot (lose);
			animator.SetInteger ("IsJumping", 0);
			animator.SetInteger ("IsWalking", 0);
			animator.SetInteger ("IsDead", 1);
			canInput = false;
			resetButton.gameObject.SetActive (true);
		}
		if (collision.collider.tag == "Enemy") {// Indicates the players has hit an enemy
			animator.SetInteger ("IsJumping", 0);
			animator.SetInteger ("IsWalking", 0);
			animator.SetInteger ("IsDead", 1);
			deadTxt.text = "GAME OVER";
			canInput = false;
			resetButton.gameObject.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D touch){// Indicates the player has hit the win switch
		if (touch.gameObject.tag == "Win") {
			winTxt.text = "YOU WIN";
			audio.PlayOneShot (win);
			canInput = false;
			resetButton.gameObject.SetActive (true);
		}
	}

	public void Death() {
		deadTxt.text = "GAME OVER";
		audio.PlayOneShot (lose);
		animator.SetInteger ("IsJumping", 0);
		animator.SetInteger ("IsWalking", 0);
		animator.SetInteger ("IsDead", 1);
		canInput = false;
		resetButton.gameObject.SetActive (true);
	}
}