using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpawner : MonoBehaviour
{
  [SerializeField] private GameObject spawner1;
  [SerializeField] private GameObject spawner2;
  [SerializeField] private GameObject spawner3;
  [SerializeField] private GameObject spawner4;

    // Start is called before the first frame update
    void Start()
    {
      spawner1.SetActive (true);
      spawner2.SetActive (false);
      spawner3.SetActive (false);
      spawner4.SetActive (false);
      StartCoroutine(SwitchSpawnerObstacle1 () );
      StartCoroutine(SwitchSpawnerObstacle2 () );
      StartCoroutine(SwitchSpawnerObstacle3 () );

    }

    private void OnEnable () {
      spawner1.SetActive (true);
      spawner2.SetActive (false);
      spawner3.SetActive (false);
      spawner4.SetActive (false);
      StartCoroutine(SwitchSpawnerObstacle1 () );
      StartCoroutine(SwitchSpawnerObstacle2 () );
      StartCoroutine(SwitchSpawnerObstacle3 () );
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SwitchSpawnerObstacle1 ()
    {
      // wait random time between spawning the obstacle
      yield return new WaitForSeconds (30);
      spawner1.SetActive (false);
      spawner2.SetActive (true);
    }

    IEnumerator SwitchSpawnerObstacle2 ()
    {
      // wait random time between spawning the obstacle
      yield return new WaitForSeconds (90);
      spawner2.SetActive (false);
      spawner3.SetActive (true);
    }

    IEnumerator SwitchSpawnerObstacle3 ()
    {
      // wait random time between spawning the obstacle
      yield return new WaitForSeconds (120);
      spawner3.SetActive (false);
      spawner4.SetActive (true);
    }
}
