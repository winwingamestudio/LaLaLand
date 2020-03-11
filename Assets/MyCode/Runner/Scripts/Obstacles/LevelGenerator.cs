using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
  private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

  [SerializeField] private Transform pfTestingPlatform;
  [SerializeField] private List <Transform> levelPartFirstList;
  [SerializeField] private List <Transform> levelPartSecondList;
  [SerializeField] private List <Transform> levelPartThirdList;
  [SerializeField] private List <Transform> levelPartFourthList;


  [SerializeField] public GameObject player;

  private enum Level {
    First,
    Second,
    Third,
    Fourth
  }

  private Vector3 lastEndPosition;
  private int levelPartsSpawned;

  public GameObject parent;

  private void Awake() {
    lastEndPosition = player.transform.position;

    if(pfTestingPlatform != null){
      Debug.Log("Using Debug Testing Platform");
    }
    int startingSpawnLevelParts = 5;
    for (int i = 0; i < startingSpawnLevelParts; i++){
      SpawnLevelPart();
    }
  }

  private void Update(){
    if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART){
      // spawn another level parent
      SpawnLevelPart();
    }
  }

private void SpawnLevelPart(){
  List <Transform> difficultyLevelPartList;
  switch (GetLevel()){
    default:
    case Level.First: difficultyLevelPartList = levelPartFirstList; break;
    case Level.Second: difficultyLevelPartList = levelPartSecondList; break;
    case Level.Third: difficultyLevelPartList = levelPartThirdList; break;
    case Level.Fourth: difficultyLevelPartList = levelPartFourthList; break;
  }

  Transform chosenLevelPart = difficultyLevelPartList[Random.Range(0, difficultyLevelPartList.Count)];

  if(pfTestingPlatform != null) {
    chosenLevelPart = pfTestingPlatform;
  }
  Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
  lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
  levelPartsSpawned++;
}
  private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) {
    Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
    levelPartTransform.transform.parent = parent.transform;
    return levelPartTransform;
  }

  private Level GetLevel ()
  {
    if(levelPartsSpawned >= 150) return Level.Fourth;
    if(levelPartsSpawned >= 100) return Level.Third;
    if(levelPartsSpawned >= 50) return Level.Second;
    return Level.First;



  }
}
