using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour {


	public delegate void EndGame();
	public static event EndGame endGame;


	void PlayerDiedEndGame ()
	{
		if (endGame != null) {

			endGame();
			FindObjectOfType<GameManagerLocal>().freezeEnable();

		}


		Destroy(gameObject);

	}


	void OnTriggerEnter2D (Collider2D collider)
	{
		// Player hit the shredder offscreen
		if (collider.tag == "Shredder") {
			FindObjectOfType<GameManagerLocal>().gameOverAudio.SetActive(true);

			PlayerDiedEndGame();
		}

	}



	void OnCollisionEnter2D (Collision2D collider)
	{
		// Player hit a Zombie and dies immediately
		if (collider.gameObject.tag == "Zombie") {
			PlayerDiedEndGame();
		}

	}



} // PlayerDied
