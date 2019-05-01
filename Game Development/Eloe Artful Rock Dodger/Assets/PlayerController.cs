using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text shieldleft;
	public Text wintxt;
	int shields = 3;
	int refuelCount = 0;
	public Text losetxt;
	public AudioClip loseSound;
	public AudioClip winSound;
	int playOnce = 0;

	private AudioSource source;
	Rigidbody2D player;
	const float MAX_FORCE_HORIZONTAL = 5.0f;
	const float MAX_FORCE_VERTICAL = 20.0f;


	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		player.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * MAX_FORCE_HORIZONTAL, 0.0f));
		if (Input.GetKey (KeyCode.Space)) {
			player.AddForce (new Vector2 (0.0f, MAX_FORCE_VERTICAL));
		}
		loseTxt ();
	}

	void OnTriggerEnter2D(Collider2D touch){
		if (touch.gameObject.tag == "rock") {
			shields--;
			shieldleft.text = string.Format ("{0}", shields);
		}
		if (touch.gameObject.tag == "lander" && playOnce == 0) {
			wintxt.text = string.Format ("{0}","You win!!!");
			source.PlayOneShot (winSound);
			playOnce++;
		}
		if (touch.gameObject.tag == "fuel" && refuelCount < 1) {
			shields++;
			shieldleft.text = string.Format ("{0}", shields);
			refuelCount++;
		}
	}

	void loseTxt(){
		if (shields < 0 && playOnce == 0) {
			losetxt.text = string.Format ("{0}", "You lose!");
			source.PlayOneShot (loseSound);
			playOnce++;
		}
	}
}
