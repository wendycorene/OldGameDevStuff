using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronCannonController : MonoBehaviour {
	SpriteRenderer mySpriteRend;
	const float MAX_FORCE_HORIZONTAL = 15.0f;
	Rigidbody2D cannon;
	private Rigidbody2D bullet;
	bool canFire = true;
	GameController gc;

	// Use this for initialization
	void Start () {
		mySpriteRend = GetComponent<SpriteRenderer>();
		cannon = GetComponent<Rigidbody2D> ();
		bullet = Resources.Load<Rigidbody2D>("Electron");
		gc = FindObjectOfType<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			mySpriteRend.flipX = false;
		}
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			mySpriteRend.flipX = true;
		}
		float moveDirection = Input.GetAxis ("Horizontal");
		cannon.velocity = new Vector2(moveDirection * 8, 0);

		if (Input.GetKey (KeyCode.Space) && canFire == true) {
			shoot ();
		}
	}

	void shoot(){
		GetComponent<AudioSource>().Play();
		Vector3 place = GameObject.FindGameObjectWithTag("Electron Cannon").transform.position;
		Rigidbody2D spawnedBullet = Instantiate (bullet, place, Quaternion.identity);
		spawnedBullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300));
		canFire = false;
		StartCoroutine (waitForShoot ());
	}
	IEnumerator waitForShoot(){
		yield return new WaitForSeconds (.25f);
		canFire = true;
	}
}
