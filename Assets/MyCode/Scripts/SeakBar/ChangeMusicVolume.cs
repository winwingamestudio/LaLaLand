using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{

  //public Slider Volume1;
  public Image[] volume;
  public AudioSource[] myMusic;
  public RectTransform[] button;

  public int numberOfMusic;

  /*public Slider Volume2;
  public AudioSource myMusic2;
  public Slider Volume3;
  public AudioSource myMusic3;
  public Slider Volume4;
  public AudioSource myMusic4;*/
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      for(int i = 0; i < numberOfMusic; i++)
      {
        myMusic[i].volume = volume[i].fillAmount;
        float buttonAngle = volume[i].fillAmount * 360;
        button[i].localEulerAngles = new Vector3(0,0, -buttonAngle);
      }

    }
}
