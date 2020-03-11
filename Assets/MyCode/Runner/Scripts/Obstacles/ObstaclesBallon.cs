using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesBallon : MonoBehaviour
{
  	// move to the left (negative side)
  	private float obstacleSpeed = -1f;

  	private Rigidbody2D rigidBody;

    [SerializeField] private AudioClip ballonPop;

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
            // play the audio clip for jumping
            AudioSource.PlayClipAtPoint(ballonPop, transform.position);
            FindObjectOfType<GameManager>().ballonHasAir = false;
            FindObjectOfType<GameManager>().IAmInGame = true;
            FindObjectOfType<GameManagerLocal>().groundPlayer.SetActive(false);
            StartCoroutine(GameOverBreathing());

  			}
  	}

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
