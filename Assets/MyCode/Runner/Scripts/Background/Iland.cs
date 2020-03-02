using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iland : MonoBehaviour {

	// move to the left (negative side)
	public float ilandSpeed = -0.3f;

	private Rigidbody2D rigidBody;


	void Awake ()
	{

		// get the rigidbody of the obstacle
		rigidBody = GetComponent<Rigidbody2D>();


	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// move the object to the left
		rigidBody.velocity = new Vector2(ilandSpeed, 0f);


	}
}
