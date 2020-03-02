using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerLocal : MonoBehaviour {
	[SerializeField] public GameObject pausePanel;
	[SerializeField] private GameObject StartGameCanvas;
	[SerializeField] private GameObject GamePlayCanvas;

	[SerializeField] public GameObject groundPlayer;
	[SerializeField] private GameObject objectParent;
	[SerializeField] private GameObject groundPlayerPrefab;

	[SerializeField] private GameObject ObstacleShredderSky;


	[SerializeField] private Button restartGameButton;
	[SerializeField] private Button jumpGameButton;


	[SerializeField] public Text scoreText, pauseText;

	private int score = 0;

	public GameObject obstaclesObj;
	public GameObject gameOverAudio;

	public SingleJoystickPlayerController singleJoystickPlayerController;

	// Use this for initialization
	void Start () {
        FindObjectOfType<GameManager>().ballonHasAir = true;
	    	Debug.Log("ballonHasAir" + FindObjectOfType<GameManager>().ballonHasAir);
				// score distance
				//scoreText.text = score + "";
				//StartCoroutine (CountScore());
				Time.timeScale = 0f;
				StartGameCanvas.SetActive(true);
				GamePlayCanvas.SetActive(false);
				OnEnable();
				jumpGameButton.onClick.AddListener( () => FindObjectOfType<PlayerJump>().Jump());


	}

	void Update()
	{
		// Add restart game function
		ObstacleShredderSky.SetActive(true);
	}

	// increment distance every .6f seconds
	IEnumerator CountScore ()
	{

		yield return new WaitForSeconds(0.6f);
		score++;
		scoreText.text = score + "";

		StartCoroutine (CountScore());
	}


	public void OnEnable ()
	{
		gameOverAudio.SetActive(false);
		FindObjectOfType<GameManager>().comeFromOut = true;//for breathing practice to show start of game in the begin

		foreach (Transform child in obstaclesObj.transform)
{
		child.gameObject.SetActive(false);
}


		Destroy(groundPlayer);

		var cc = Instantiate(groundPlayerPrefab);
		this.groundPlayer = cc;
		this.groundPlayer.transform.SetParent(objectParent.transform.parent, false);
		singleJoystickPlayerController.myRotationObject = this.groundPlayer.transform;

		StartGameCanvas.SetActive(true);
		pausePanel.SetActive(false);
		pauseText.text = "";


		// Register as a delegate
		PlayerDied.endGame += PlayerDiedEndTheGame;

	}

	public void freezeEnable ()
	{
		// freeze game
		Time.timeScale = 0f;
	}

	void OnDisable ()
	{
		// Unregister as a delegate
		PlayerDied.endGame -= PlayerDiedEndTheGame;
	}

	// Function to run when player dies
	public void PlayerDiedEndTheGame ()
	{

		// check if no score key exists
		if (!PlayerPrefs.HasKey ("Score")) {

			// init score to zero on first run.
			PlayerPrefs.SetInt ("Score", 0);

		} else {

			int highscore = PlayerPrefs.GetInt ("Score");
			if (score > highscore) {
				// Set new high score
				PlayerPrefs.SetInt ("Score", score);
			}

		}

		// display game over text
		pauseText.text = "Game Over";
		Destroy(groundPlayer);

		// activate and display the pause panel
		pausePanel.SetActive(true);

		// clear listeners
		restartGameButton.onClick.RemoveAllListeners();

		// Add restart game function
		restartGameButton.onClick.AddListener( () => RestartGame() );

		// freeze game
		//Time.timeScale = 0f;


	}

	// Restart function
	public void RestartGame ()
	{
		// Unfreeze game
		Time.timeScale = 1f;
		OnEnable();

		// Reload level
		StartGameCanvas.SetActive(false);
		GamePlayCanvas.SetActive(true);
		pausePanel.SetActive(false);

	/*	if (!FindObjectOfType<GameManager>().ballonHasAir && FindObjectOfType<GameManager>().IAmInGame)
		{
			// display game over text
			pauseText.text = "Ballon Has no Air";

			// activate and display the pause panel
			pausePanel.SetActive(true);
			StartCoroutine(GameOverBreathing());

		}*/

	}


	public void PauseButton ()
	{
		// freeze game
		Time.timeScale = 0f;

		// activate and display the pause panel
		pausePanel.SetActive(true);

		// clear listeners
		restartGameButton.onClick.RemoveAllListeners();

		// Add restart game function
		restartGameButton.onClick.AddListener( () => ResumeGame() );

	}

	IEnumerator GameOverBreathing()
	{
		yield return new WaitForSeconds(3f);
		FindObjectOfType<GameManager>().HomeState(4);
	}

	public void ResumeGame()
	{
		// freeze game
		Time.timeScale = 1f;

		// activate and display the pause panel
		pausePanel.SetActive(false);
	}


	public void GoToStart()
	{
		StartGameCanvas.SetActive(true);
		GamePlayCanvas.SetActive(false);
		pausePanel.SetActive(false);
		SceneManager.LoadScene("RunnerScene"); //Load scene called Game
	}


}
