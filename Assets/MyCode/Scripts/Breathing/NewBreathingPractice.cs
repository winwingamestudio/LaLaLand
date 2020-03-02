using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Complete Script for Breathing
public class NewBreathingPractice : MonoBehaviour
{
  //public GameObject breathingPracticeAnimation;
  public GameObject ballon;
  public GameObject ballonParent;
  public GameObject ballonPrefab;

  public GameObject micVolume;
  public GameObject circleBreathing;
  public GameObject cloudParent;
  public GameObject cloudsNew;
  public GameObject cloudsPrefabNew;




  public int numClouds;
  public int cloudNum = -1;
  public bool increaseCloudNum;

  public GameObject gameCanvas;
  public GameObject gameOverCanvas;
  [SerializeField] private Text GameOverText;

  public GameObject gameAudio;
  public GameObject gameOverAudio;

  public bool healingDone;

  public GameObject inhaleTxt;
  public GameObject exhaleTxt;
  public GameObject inhaleSound;
  public GameObject exhaleSound;

  public GameObject[] stars;
  public bool[] success;

  public GameObject breathingVideo;
  public GameObject breathingPractice;

  public GameObject replayBtn;







  void Start()
  {
    //Destroy(cloudsNew);
    //Destroy(ballon);
    //OnEnable();
    FindObjectOfType<GameManager>().comeFromOut = true;//for breathing practice to show start of game in the begin
    GameStart();

  }

  IEnumerator WaitFunction()
  {
    yield return new WaitForSeconds(3f);
  }
    // Start is called before the first frame update
    public void OnEnable()
    {
      if(FindObjectOfType<GameManager>().comeFromOut)
      {
        GameOverText.text = " Breathing into your microphone!";
        replayBtn.SetActive(true);
        GameStart();
      }

      else
      {

      StartCoroutine(WaitFunction());
      replayBtn.SetActive(true);
      GameOverText.text = " Breathing into your microphone!";
      Destroy(cloudsNew);
      Destroy(ballon);
      healingDone = false;

      gameAudio.SetActive(true);
      gameOverAudio.SetActive(false);

      //breathingPracticeAnimation.SetActive(true);
      cloudNum = -1;
      increaseCloudNum = true;
      gameCanvas.SetActive(true);
      gameOverCanvas.SetActive(false);

      var cc = Instantiate(cloudsPrefabNew);
      this.cloudsNew = cc;
      this.cloudsNew.transform.SetParent(cloudParent.transform.parent, false);

      var bb = Instantiate(ballonPrefab);
      if(FindObjectOfType<GameManager>().homeState == 9)
      bb.GetComponent<Image>().color = new Color(1, 1, 1, 0.0f);

      this.ballon = bb;
      this.ballon.transform.SetParent(ballonParent.transform.parent, false);


      for(int i = 0; i < numClouds; i ++)
      {
        cloudsNew.transform.GetChild(i).gameObject.GetComponent<Animator>().enabled = false;
        stars[i].SetActive(false);
        success[i] = false;

      }

      inhaleTxt.SetActive(false);
      exhaleTxt.SetActive(false);
    }

    }



    // Update is called once per frame

    void Update()
    {
      if(circleBreathing.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BreathingAnim"))
      {
        inhaleTxt.SetActive(true);
        exhaleTxt.SetActive(false);
        inhaleSound.SetActive(true);
        exhaleSound.SetActive(false);
      }

      if (circleBreathing.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BreathingPauseAnim"))
      {
        increaseCloudNum = true;
        if(cloudsNew.transform.GetChild(cloudNum).gameObject.GetComponent<Image>().color.a<0.1f && !healingDone)
        {
          //GameManager.Instance.Healing();
          var theBarRectTransform = ballon.transform as RectTransform;
          theBarRectTransform.sizeDelta = new Vector2 (theBarRectTransform.sizeDelta.x, theBarRectTransform.sizeDelta.y+40);
          ballon.transform.position = new Vector2(ballon.transform.position.x, ballon.transform.position.y+15);
          healingDone = true;
          GameManager.Instance.Healing();
          stars[cloudNum].SetActive(true);
          success[cloudNum] = true;
        }
        if(cloudNum == (numClouds-1))
        {
          breathingVideo.SetActive(false);
          breathingPractice.SetActive(false);
          StartCoroutine(GameOver());

        }
      }


      if(circleBreathing.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BreathOutAnim"))
      {
        inhaleTxt.SetActive(false);
        exhaleTxt.SetActive(true);
        inhaleSound.SetActive(false);
        exhaleSound.SetActive(true);

        if(increaseCloudNum)
        IncreaseCloudNum();

        if( micVolume.GetComponent<MicrophoneInput>().loudness > 10)
        cloudsNew.transform.GetChild(cloudNum).gameObject.GetComponent<Animator>().enabled = true;

        if( micVolume.GetComponent<MicrophoneInput>().loudness < 2 )
        cloudsNew.transform.GetChild(cloudNum).gameObject.GetComponent<Animator>().enabled = false;
      }

    }



    void IncreaseCloudNum()
    {
      cloudNum++;
      Debug.Log("cloudNum = "+ cloudNum);

      increaseCloudNum = false;
      healingDone = false;
    }

    IEnumerator GameOver()
    {
      if(success[0] && success[1] && success[2])
      {
        GameOverText.text = "Congratulation :)";
        FindObjectOfType<GameManager>().IAmInGame = false;
        replayBtn.SetActive(false);
        FindObjectOfType<GameManager>().ballonHasAir = true;
        Debug.Log("ballonHasAir" + FindObjectOfType<GameManager>().ballonHasAir);
      }

      yield return new WaitForSeconds(3f);
      Debug.Log("GameOveriiiing");
      //Time.timeScale=1; //play
      breathingVideo.SetActive(true);
      breathingPractice.SetActive(true);
      gameAudio.SetActive(false);
      gameOverAudio.SetActive(true);

      Destroy(cloudsNew);
      Destroy(ballon);
      gameCanvas.SetActive(false);
      gameOverCanvas.SetActive(true);
      FindObjectOfType<GameManager>().comeFromOut = false;
      //breathingPracticeAnimation.SetActive(false);
      //var theBarRectTransform = ballon.transform as RectTransform;
      //theBarRectTransform.sizeDelta = new Vector2 (theBarRectTransform.sizeDelta.x, ballonY);
    }

    void GameStart()
    {
      breathingVideo.SetActive(true);
      breathingPractice.SetActive(true);
      gameAudio.SetActive(false);
      gameOverAudio.SetActive(true);

      Destroy(cloudsNew);
      Destroy(ballon);
      gameCanvas.SetActive(false);
      gameOverCanvas.SetActive(true);
      FindObjectOfType<GameManager>().comeFromOut = false;
    }

}
