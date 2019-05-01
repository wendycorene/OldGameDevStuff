using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bulletController : MonoBehaviour {
	private Rigidbody2D bullet;
	private float distPerSec = 300.0f;
	bool canFire = true;
	GameObject player;
	playerController pc;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<Rigidbody2D>("Prefabs/Bullet");
		player = GameObject.Find ("Player");
		pc = player.GetComponent<playerController> ();
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow) && canFire == true) {
			shoot ();
		}
	}
		private void OnCollisionEnter2D(Collision2D collision){
			if (collision.collider.tag == "Enemy") {
				Destroy(gameObject);
			if (collision.collider.tag == "Ground") {
				Destroy (gameObject);
			}
			}
	}

	void shoot(){
		Vector3 place = GameObject.FindGameObjectWithTag("Player").transform.position;
		audio.Play ();
		print (pc.firstFlip.ToString ());
        
		if (pc.firstFlip == true) {
			// left bullet
			Rigidbody2D spawnedBullet = Instantiate (bullet, place + (transform.right*-1.000001f), Quaternion.Euler(0, 0, -90));
			spawnedBullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-distPerSec, 0));
		} else {
			// right bullet
			Rigidbody2D spawnedBullet = Instantiate (bullet, place + (transform.right*1.000001f), Quaternion.Euler(0, 0, -90));
			spawnedBullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (distPerSec, 0));
		}


		canFire = false;
		StartCoroutine (waitForShoot ());
	}

	IEnumerator waitForShoot(){
		yield return new WaitForSeconds (.25f);
		canFire = true;
	}
}
