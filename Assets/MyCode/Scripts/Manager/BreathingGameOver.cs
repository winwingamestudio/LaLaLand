using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BreathingGameOver : MonoBehaviour
{
    public GameObject GOCanvas;
    public GameObject BreathingCanvas;
    public GameObject GameAudio;
    public GameObject GameOverAudio;
    public GameObject BreathingBar;
    public GameObject DBreathingBar;
    public GameObject DBreathingBarInit;
    public Animator animBreathingPractice;
    public GameObject micVolume;



    public
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GOver()
    {
        GOCanvas.SetActive(true);
        GameOverAudio.SetActive(true);
        BreathingCanvas.SetActive(false);
        GameAudio.SetActive(false);
        Destroy(BreathingBar);
        Destroy(DBreathingBar);
        //FindObjectOfType<TimeToWin>().stop();


    }

    public void begin()
    {
        //FindObjectOfType<TimeToWin>().start();
        GameOverAudio.SetActive(false);
        GameAudio.SetActive(true);
        GOCanvas.SetActive(false);
        var c = Instantiate(DBreathingBarInit);

        this.DBreathingBar = c;
        BreathingBar = new GameObject();
        BreathingCanvas.SetActive(true);
        animBreathingPractice.enabled = true;

    }

}
