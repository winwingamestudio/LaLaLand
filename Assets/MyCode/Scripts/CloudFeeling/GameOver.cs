using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GO;

    public GameObject CloudsParent;
    public GameObject CloudsParentPrefab;
    public GameObject DClouds;
    public GameObject DCloudsPrefab;
    public GameObject Spwaners;
    public GameObject GameAudio;
    public GameObject GamoverAudio;


    public void OnEnable()
    {
      Spwaners.SetActive(true);
      GamoverAudio.SetActive(false);
        GameAudio.SetActive(true);
        GO.SetActive(false);
        var cc = Instantiate(CloudsParentPrefab);
        this.CloudsParent = cc;

        var c = Instantiate(DCloudsPrefab);

        this.DClouds = c;
        var objs = FindObjectsOfType<CloudSpawner>();
        foreach (var VARIABLE in objs)
        {
            VARIABLE.parent = CloudsParent;
        }

    }



    public void GOver()
    {
        GO.SetActive(true);
        GamoverAudio.SetActive(true);
        GameAudio.SetActive(false);
        Spwaners.SetActive(false);
        Destroy(DClouds);
        Destroy(CloudsParent);
    }


}
