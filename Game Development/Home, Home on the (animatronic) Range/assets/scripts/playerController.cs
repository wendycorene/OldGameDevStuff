using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	private Animator animator;
	Rigidbody2D player;
	const float MAX_FORCE_HORIZONTAL = 10.0f;
	const float MAX_FORCE_VERTICAL = 20.0f;
	public float thrust;
	public Rigidbody rb;
	SpriteRenderer mySpriteRend;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		mySpriteRend = GetComponent<SpriteRenderer>();
	}

	void Update(){
		player = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate()
	{
		/*
		 * 0 = walk
		 * 1 = attack
		 * 2 = jump
		 * 3 = hit
		 * 4 = faint
		 * 5 = idle1
		 * 6 = idle2
		 */
		player.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * MAX_FORCE_HORIZONTAL, 0.0f));
		if (Input.GetKey (KeyCode.RightArrow))
		{
			mySpriteRend.flipX = false;
			animator.SetInteger("State", 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			mySpriteRend.flipX = true;
			animator.SetInteger("State", 0);
		}
		if (Input.GetKey (KeyCode.Space))
		{
			animator.SetInteger("State", 2);
			rb.AddForce(transform.forward * thrust);
		}
		if (Input.GetKey (KeyCode.UpArrow))
		{
			animator.SetInteger("State", 1);
		}
	}
}