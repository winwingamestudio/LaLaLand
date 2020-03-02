using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

  public void Select (int level)
  {

  //  GameManager.highScore = highScore;
    SceneManager.LoadScene("MyRoomScene");
    GameConstants.LEVEL = level;
    string strLevel = "" + level;

  }
}
