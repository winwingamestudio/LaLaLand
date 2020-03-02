using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour {


	[SerializeField] private GameObject[] obstacles;
	public float time1, time2;


	private List<GameObject> obstaclesForSpawning = new List<GameObject>();
	public GameObject parent;


	private void Awake ()
	{

		InitializeObstacles ();

	}


	// Use this for initialization
	private void Start () {


	}
	private void OnEnable () {
		// Start spawning Obstacles
		StartCoroutine(SpawnRandomObstacle () );
	}

	// Update is called once per frame
	private void Update () {

	}


	private void InitializeObstacles ()
	{


		// obstacle index
		int loopAroundIndex = 0;


		// populate the object list with three of each obstacle
		for (int i = 0; i < obstacles.Length * 3; i++) {

			// create instance of object
			GameObject obsItem = Instantiate (obstacles [loopAroundIndex], new Vector3(transform.position.x, transform.position.y, -3), Quaternion.identity) as GameObject;
			obsItem.transform.parent = parent.transform;
			// add it to the List
			obstaclesForSpawning.Add (obsItem);

			// ensure it is inactive for now
			obstaclesForSpawning [i].SetActive (false);

			// increment index
			loopAroundIndex++;

			// set index back to 0 to go through objects again
			if (loopAroundIndex == obstacles.Length) {
				loopAroundIndex = 0;
			}

		}

	}


	private void Shuffle ()
	{

		for (int i = 0; i < obstaclesForSpawning.Count; i++) {

			// store the temp object
			GameObject temp = obstaclesForSpawning[i];

			// get a new index
			int random = Random.Range(i, obstaclesForSpawning.Count);

			// change the i to the random index object
			obstaclesForSpawning[i] = obstaclesForSpawning[random];

			// change the random index object to the temp object
			obstaclesForSpawning[random] = temp;

		}


	}



	IEnumerator SpawnRandomObstacle ()
	{
		// wait random time between spawning the obstacle
		yield return new WaitForSeconds (Random.Range (time1, time2));

		// get a random obstacle
		int index = Random.Range (0, obstaclesForSpawning.Count);

		// loop through until we break out of the loop
		while (true) {

			// if the object is not active, activate it!
			if (!obstaclesForSpawning [index].activeInHierarchy) {

				// set the object to active
				obstaclesForSpawning [index].SetActive (true);

				// position the obstacle at the spawner location
				obstaclesForSpawning [index].transform.position = new Vector3(transform.position.x, transform.position.y, -3);

				// break out of loop
				break;

			} else {

				// obstacle was already spawned since there is an active one in the hierarchy
				// Generate a new index to try on next loop iteration
				index = Random.Range(0, obstaclesForSpawning.Count);

			}

		}

		// start the endless spawning of obstacles
		StartCoroutine(SpawnRandomObstacle () );


	}



} // ObstacleSpawner
