using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour {

	[SerializeField] private AudioClip jumpSFX;

	// Movement affectors
	public float jumpForce = 3f, forwardForce = 0f;

	// Get the player body to move
	private Rigidbody2D rigidBody;

	// Enable/disable jump
	private bool canJump;
	private bool jumped;

	// The jump button to wire up
	private Button jumpButton;


	// Use this for initialization
	void Start () {

		// get the Rigidbody2D
		rigidBody = GetComponent<Rigidbody2D>();

		// get the jump button
		//jumpButton = GameObject.Find("Jump Button").GetComponent<Button>();

		// programmatically add the OnClick event
		//jumpButton.onClick.AddListener( () => Jump() );


	}

	// Update is called once per frame
	void Update ()
	{

		// detect if the player is not flying through the air from a previous jump
		if (rigidBody.velocity.y < 0 || rigidBody.velocity.y == 0) {

			// playe is now eligble for jumping
			canJump = true;
			jumped = false;

		}
		if(transform.position.y < -3.0f)
		{
			rigidBody.gravityScale = 0.0f;
			if (!jumped) rigidBody.velocity = Vector3.zero;
			if(jumped) 		rigidBody.gravityScale = 0.3f;
		}


	}


	// Create the jump functionality
	public void Jump ()
	{

		if (canJump) {
			canJump = false;
			jumped = true;

			// if the player is on the left side of the screen, they will jump forward too.
			if (transform.position.x < -1) {

				forwardForce = 0.5f;

			} else {

				// too far forward so no forward force.
				forwardForce = 0f;
			}

			// play the audio clip for jumping
			AudioSource.PlayClipAtPoint(jumpSFX, transform.position);

			// move the player
			rigidBody.velocity = new Vector2(forwardForce, jumpForce);
			rigidBody.gravityScale = 0.3f;
		}


	}


}
