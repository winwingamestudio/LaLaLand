using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

  public bool comeFromOut;//for breathinpractice to show start in the beginig of practice

  public GameObject audioOnIcon;
  public GameObject audioOffIcon;

  public AudioSource ring;
  public AudioSource gitar;

  public GameObject gameCanvas;
  public GameObject homeDay;
  public GameObject homeDayMusic;
  public GameObject outsideHome;
  public GameObject cloudFeelingPractice;
  public GameObject breathingPractice;
  public GameObject breathingPracticeRoom;
  public GameObject natureScene;
  public GameObject shopScene;
  public GameObject friendScene;
  public GameObject dreamboxScene;
  public GameObject friendDreamboxScene;
  public GameObject insideHomeIcone;



  public bool doorKey = false;
  public Image dialogueText;
  public Sprite textAskKey;//Text for asking if you have key or not yet to open the door
  public GameObject finger;
  public Image black;
  public Animator fadingAnim;
  public int numberOfKnocking;
  public GameObject BGMusic;

  public GameObject montainPanel;
  public GameObject lakePanel;
  public GameObject seaPanel;

  public int homeState;
  public int natureState;

  public GameObject thinking;

  public GameObject[] energyHealthImage;
  public float energyHealthValue;

  public int currentScore;
  public Text scoreText;

  public bool ballonHasAir = true;
  public  bool IAmInGame = false;

  private static GameManager _instance = null;
  public static GameManager Instance{
    get{if(_instance == null){
      _instance = new GameManager();
      }
      return _instance;
    }
  }

  private GameManager(){
    _instance = this;
  }

public void start()
{
  GameConstants.HOMESTATE = 3;
  GameConstants.NATURESTATE = 0;
  currentScore = 0;

}

private float startTime;
public Text timerText;
public bool timerStart;
string minutes;
string seconds;

public int level;
public Text TxtLevel;

public int highScore;
public Text TxtHighScore;


  // Update is called once per frame
  void Update()
  {
    Timer();
  }

  public void Timer()
  {
    if(!timerStart) startTime = Time.time;
    if(timerStart)
    {
      var t = Time.time - startTime;
      minutes = ((int) t / 60).ToString();
      seconds = ((int) t % 60).ToString();
      timerText.text = minutes + ":" + seconds;
    }
  }


  public void Awake(){
    _instance = this;
    homeState = GameConstants.HOMESTATE;
    natureState = GameConstants.NATURESTATE;
    //string strHomeState = "" + homeState;

    //LoadPlayer(strHomeState);

    SwitchHomeState();

    gameCanvas.SetActive(true);
    outsideHome.SetActive(true);
    BGMusic.SetActive(true);
    homeDay.SetActive(false);
    cloudFeelingPractice.SetActive(false);
    breathingPractice.SetActive(false);
    breathingPracticeRoom.SetActive(false);
    natureScene.SetActive(false);
    shopScene.SetActive(false);
    friendScene.SetActive(false);
    dreamboxScene.SetActive(false);
    friendDreamboxScene.SetActive(false);
    finger.SetActive(false);
    StartCoroutine(ActiveFinger());
    insideHomeIcone.SetActive(false);


    //For saving data
    level = GameConstants.LEVEL;
    string strLevel = "" + level;

    LoadPlayer(strLevel);

  }

  IEnumerator ActiveFinger()
  {
    yield return new WaitForSeconds(12f);
    finger.SetActive(true);
  }


  public void playThinking()
  {
  if(thinking.activeSelf)
    thinking.SetActive(false);

    else
    thinking.SetActive(true);
  }

  public void ActiveNatureScene(int _natureState)
  {
    StartCoroutine(Fading());
    natureScene.SetActive(true);
    insideHomeIcone.SetActive(false);
    natureState = _natureState;
    GameConstants.NATURESTATE = natureState;
    SwitchNatureState();
    outsideHome.SetActive(false);
    BGMusic.SetActive(false);
    homeDay.SetActive(false);
    cloudFeelingPractice.SetActive(false);
    breathingPractice.SetActive(false);
    breathingPracticeRoom.SetActive(false);
    shopScene.SetActive(false);
    friendScene.SetActive(false);
    dreamboxScene.SetActive(false);
    friendDreamboxScene.SetActive(false);
    homeDayMusic.SetActive(false);
    timerStart = true;
    InvokeRepeating("Healing", 0, 5f);
  }
  public void Healing()
  {
    if(energyHealthValue < 100)
    {
      energyHealthValue = energyHealthValue + 20f;
      EnergyHealthChange(energyHealthValue);
      Debug.Log("Healing Done!");
    }
  }
  public void HealingGone()
  {
    if(energyHealthValue > 0)
    {
      energyHealthValue = energyHealthValue - 20f;
      if(energyHealthValue < 0)
         energyHealthValue = 0;
      EnergyHealthChange(energyHealthValue);
    }
  }

  public void EnergyHealthChange(float healthValue){
    float amount = (healthValue/100.0f);
    Debug.Log(amount);

      if(amount < 0.2f)
      {
        energyHealthImage[0].SetActive(true);
        energyHealthImage[1].SetActive(false);
      }

      else if(amount >0.2f && amount < 0.4f || amount ==0.2f)
      {
        energyHealthImage[0].SetActive(false);
        energyHealthImage[1].SetActive(true);
        energyHealthImage[2].SetActive(false);

      }

      else if(amount >0.4f && amount < 0.6f || amount ==0.4f)
      {
        energyHealthImage[1].SetActive(false);
        energyHealthImage[2].SetActive(true);
        energyHealthImage[3].SetActive(false);

      }
      else if(amount >0.6f && amount < 0.8f || amount ==0.6f)
      {
        energyHealthImage[2].SetActive(false);
        energyHealthImage[3].SetActive(true);
        energyHealthImage[4].SetActive(false);

      }
      else if(amount >0.8f)
      {
        energyHealthImage[3].SetActive(false);
        energyHealthImage[4].SetActive(true);
      }
    }

  public void SwitchNatureState()
  {
    switch (natureState)
    {

        case 0://Montain
        lakePanel.SetActive(false);
        seaPanel.SetActive(false);
        montainPanel.SetActive(true);

            break;
        case 1://Lake
        montainPanel.SetActive(false);
        seaPanel.SetActive(false);
        lakePanel.SetActive(true);

            break;
        case 2://Sea
        montainPanel.SetActive(false);
        lakePanel.SetActive(false);
        seaPanel.SetActive(true);
            break;
        default:
            Debug.Log("Error");
            break;
    }
  }

//**************Save Data*****************
  public  void SavePlayer (string levelPath)
  {
    SaveSystem.SavePlayer(this, levelPath);
  }

  public void LoadPlayer (string levelPath)
  {

    if(SaveSystem.LoadPlayer(levelPath) == null)
    {
      Levels();
    }

    PlayerData data = SaveSystem.LoadPlayer(levelPath);


    level = data.level;

    highScore = data.highScore;
  }
//*********************************
  public void Levels ()
  {
    int homeState = GameConstants.HOMESTATE;
    string strHomeState = "" + homeState;
    Debug.Log(strHomeState);
    SavePlayer(strHomeState);
  }

  public void ARSceneAdvice(string name)
  {
    SceneManager.LoadScene("ARSceneAdvice");
  }

  public void playRing()
  {
    ring.Play();
  }
  public void StopRing()
  {
    ring.Stop();
  }

  public void playGitar()
  {
    gitar.Play();
  }

//Open the door if key is founded
  public void KnocktheDoor()
  {
    if (doorKey) HomeState(1);
    else
    {
    dialogueText.GetComponent<Image>().sprite = textAskKey;
      HomeState(3);
    }
  }
public void HomeState(int _homeState)
{
  CancelInvoke ("Healing");
  timerStart = false;
  homeState = _homeState;
  GameConstants.HOMESTATE = homeState;
  if(homeState == 1)
  {
    if(numberOfKnocking == 0 )
    {
      numberOfKnocking++;
      StartCoroutine(EnterHome());
    }
    else SwitchHomeState();
  }
  else SwitchHomeState();
}

IEnumerator EnterHome()
{
  yield return new WaitForSeconds(2f);
  SwitchHomeState();
}

  public void SwitchHomeState()
  {
    switch (homeState)
    {

        case 0://Outside home
        insideHomeIcone.SetActive(false);
        outsideHome.SetActive(true);
        BGMusic.SetActive(true);
        homeDay.SetActive(false);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(false);
            break;
        case 1://Inside home day
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(true);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(true);
            break;
        case 2://Inside home night
        insideHomeIcone.SetActive(false);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(false);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        homeDayMusic.SetActive(false);
            break;
        case 3://CloudFeelingPractice
        insideHomeIcone.SetActive(false);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(false);
        cloudFeelingPractice.SetActive(true);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(false);
            break;
        case 4://BreathingPractice
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(false);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(true);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(false);
            break;
        case 5://Shoping
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(true);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(true);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(true);
            break;
        case 6://friendScene
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(true);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(true);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(true);
            break;

        case 7://dreamboxScene
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(true);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(true);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(true);
                break;

        case 8://friendDreamboxScene
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(true);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(false);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(true);
        homeDayMusic.SetActive(true);
                break;
        case 9://BreathingPractice
        insideHomeIcone.SetActive(true);
        outsideHome.SetActive(false);
        BGMusic.SetActive(false);
        finger.SetActive(false);
        homeDay.SetActive(false);
        cloudFeelingPractice.SetActive(false);
        breathingPractice.SetActive(false);
        breathingPracticeRoom.SetActive(true);
        natureScene.SetActive(false);
        shopScene.SetActive(false);
        friendScene.SetActive(false);
        dreamboxScene.SetActive(false);
        friendDreamboxScene.SetActive(false);
        homeDayMusic.SetActive(false);
            break;
        default:
            Debug.Log("Error");
            break;
    }
  }

  public void ClosShop()
  {
    shopScene.SetActive(false);
  }

  IEnumerator Fading()
  {
    yield return new WaitUntil(()=>black.color.a==0);
    finger.SetActive(true);
  }


  public void ToggleSound()
  {
      if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
          PlayerPrefs.SetInt ("Muted", 1);
      }
      else
      {

          PlayerPrefs.SetInt ("Muted", 0);
      }

      SetSoundState ();
  }

  private void SetSoundState()
{
    if (PlayerPrefs.GetInt ("Muted", 0) == 0)
    {

        AudioListener.volume = 1;
        audioOnIcon.SetActive (true);
        audioOffIcon.SetActive (false);
    }
            else
    {

        AudioListener.volume = 0;
        audioOnIcon.SetActive (false);
        audioOffIcon.SetActive (true);
    }
}

public void _MyRoomScene()
{
  SceneManager.LoadSceneAsync("_MyRoomScene");
}

IEnumerator FadingOutBreathingScene()
{
  fadingAnim.SetTrigger("Fade");
  yield return new WaitUntil(()=>black.color.a==1);
  SceneManager.LoadScene("breathingPracticeScene");
}

IEnumerator FadingOutNatureScene()
{
  fadingAnim.SetTrigger("Fade");
  yield return new WaitUntil(()=>black.color.a==1);
}

public void GetScore()
{
  currentScore += 1;
  GameConstants.SCORE = currentScore;
  scoreText.text = "" + currentScore;
}

public void LostScore(int i)
{
  currentScore -= i;
  GameConstants.SCORE = currentScore;
  scoreText.text = "" + currentScore;
}

}
