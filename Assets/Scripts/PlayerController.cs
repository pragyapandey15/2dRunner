﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movespeed;
	public float jumpforce;
	public bool grounded;
	public LayerMask whatIsGround;

	private Rigidbody2D myRigidbody;
	private Collider2D myCollider;
	private Animator myAnimator;
	public float jumpTime;
	private float jumpTimeCounter;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D > ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator=GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
	}

	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers (myCollider,whatIsGround);
		myRigidbody.velocity = new Vector2 (movespeed,myRigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
		{
			if(grounded)
			{
			
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpforce);
		     }
	}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) 
		{
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpforce);
				jumpTimeCounter -= Time.deltaTime;
			}
		
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
		
			jumpTimeCounter = 0;
		
		}
		if (grounded) {
			jumpTimeCounter = jumpTime;
		
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	
	
	}﻿ 



}