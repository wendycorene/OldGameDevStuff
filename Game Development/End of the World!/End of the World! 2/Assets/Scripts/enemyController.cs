using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyController : MonoBehaviour {
	private float distPerSec = -1.0f;
	Rigidbody2D bullet;
	bool canFire = true;
	Vector3 offset = new Vector3 (-1, 0, 0);
	public Text killTXT;
	private int killCount = 0;
	public bool shouldMove = true;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load<Rigidbody2D>("Prefabs/EnemyBullet");
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldMove) {
			transform.Translate (distPerSec * Time.deltaTime, 0.0f, 0.0f);
		}
		
		if (canFire == true) {
			shoot ();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Player") {
			Destroy (gameObject);
		}
		if (collision.collider.tag == "Bullet") {
			Destroy (gameObject);
			killCount++;
			killTXT.text = string.Format ("{0}", killCount);
		}
	}

	void shoot(){
		Vector3 place = gameObject.transform.position;
		Rigidbody2D spawnedBullet = Instantiate (bullet, (place + offset), Quaternion.Euler(0, 0, 90));
		spawnedBullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-200f, 0));
		canFire = false;
		StartCoroutine (waitForShoot ());
	}

	IEnumerator waitForShoot(){
		yield return new WaitForSeconds (3);
		canFire = true;
	}
}
