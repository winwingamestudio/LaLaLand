using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
  public int highScore;
  public int level;
  //public float[] position;

  public PlayerData(GameManager player)
  {
    level = player.level;
    // 4 is number of levels
    highScore = player.highScore;
  }

}
