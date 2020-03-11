using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {

	// move to the left (negative side)
	private float obstacleSpeed = -1f;
	[SerializeField] private AudioClip heallingGoneSound;
	private Rigidbody2D rigidBody;

	//[SerializeField] private AudioClip ballonPop;

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
		rigidBody.velocity = new Vector2(obstacleSpeed, 0f);



	}

	private void OnTriggerEnter2D(Collider2D other)
	{
			if (other.CompareTag("Player"))
			{
				Debug.Log(GameManager.Instance.energyHealthValue);
				if(GameManager.Instance.energyHealthValue > 0)
				{
					Debug.Log("Decrese Heal");
					AudioSource.PlayClipAtPoint(heallingGoneSound, transform.position);
					GameManager.Instance.HealingGone();
					this.gameObject.SetActive(false);
				}
				else if (GameManager.Instance.energyHealthValue == 0.0f)
				{
					FindObjectOfType<GameManagerLocal>().PlayerDiedEndTheGame();

					//StartCoroutine(GameOverNature());
					//AudioSource.PlayClipAtPoint(ballonPop, transform.position);
					FindObjectOfType<GameManager>().ballonHasAir = false;
					FindObjectOfType<GameManager>().IAmInGame = true;
					FindObjectOfType<GameManagerLocal>().groundPlayer.SetActive(false);
					StartCoroutine(GameOverBreathing());
				}
			}
	}


/*	IEnumerator GameOverNature()
	{
		yield return new WaitForSeconds(2f);
		FindObjectOfType<GameManager>().ActiveNatureScene(2);
	}*/

	IEnumerator GameOverBreathing()
	{
		yield return new WaitForSeconds(2f);
		this.gameObject.SetActive(false);
		// display game over text
		FindObjectOfType<GameManagerLocal>().pauseText.text = "Ballon Has no Air";
		// activate and display the pause panel
		FindObjectOfType<GameManagerLocal>().pausePanel.SetActive(true);
		FindObjectOfType<GameManager>().HomeState(4);
	}
}
