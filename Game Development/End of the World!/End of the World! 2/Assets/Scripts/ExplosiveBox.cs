using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplosiveBox : MonoBehaviour {

	private SpriteRenderer sr;
	GameObject player;
	playerController pc;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		player = GameObject.Find ("Player");
		pc = player.GetComponent<playerController> ();
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Player") {
			sr.color = new Color (1.0f, 0f, 0f);
			audio.Play ();
			pc.Death ();
		}
	}
}
