using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator animator;


	// Use this for initialization
	void Start () {

		// get animation controller
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// if we collide with something, stop the Run animation
	void OnCollisionEnter2D (Collision2D collider)
	{

		if (collider.gameObject.tag == "Obstacle") {

			animator.Play("Idle");


		}


	}


	// if we leave the collider, resume running animation
	void OnCollisionExit2D (Collision2D collider)
	{

		if (collider.gameObject.tag == "Obstacle") {

			animator.Play("Run");


		}


	}

}
