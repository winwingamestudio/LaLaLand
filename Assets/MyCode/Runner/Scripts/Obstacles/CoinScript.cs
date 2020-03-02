using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

	// move to the left (negative side)
	private float coinSpeed = -1f;
	private Rigidbody2D rigidBody;
  [SerializeField] private AudioClip gotCoinSound;


	void Awake ()
	{
		// get the rigidbody of the obstacle
		rigidBody = GetComponent<Rigidbody2D>();
	}


	// Use this for initialization
	void Start ()
  {

	}

	// Update is called once per frame
	void Update () {

		// move the object to the left
		rigidBody.velocity = new Vector2(coinSpeed, 0f);


	}

	private void OnCollisionEnter2D(Collision2D other)
	{
			if (other.collider.CompareTag("Player"))
			{
        AudioSource.PlayClipAtPoint(gotCoinSound, transform.position);
        GameManager.Instance.GetScore();
				this.gameObject.SetActive(false);
			}
	}

}
