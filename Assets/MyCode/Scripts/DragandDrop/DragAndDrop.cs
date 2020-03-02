using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
  public GameObject happy, soso, sad,
  happyBlack, sosoBlack, sadBlack, day1, day2, day3, day4, day5, day6, day7;
  Vector2 happyInitialPos, sosoInitialPos, sadInitialPos;

  public AudioSource source;
  public AudioClip[] correct;
  public AudioClip incorrect;

  void Start()
  {
    happyInitialPos = happy.transform.position;
    sosoInitialPos = soso.transform.position;
    sadInitialPos = sad.transform.position;
  }

  public void DragHappy()
  {
    happy.transform.position = Input.mousePosition;
  }

  public void DragSoso()
  {
    soso.transform.position = Input.mousePosition;
  }

  public void DragSad()
  {
    sad.transform.position = Input.mousePosition;
  }

  public void DropHappy()
  {
    float Distance = Vector3.Distance(happy.transform.position, happyBlack.transform.position);
    if(Distance < 50)
    {
      happy.transform.position = happyBlack.transform.position;
      source.clip = correct[Random.Range(0, correct.Length)];
      source.Play();
    }
    else
    {
      happy.transform.position = happyInitialPos;
      source.clip = incorrect;
      source.Play();
    }
  }

  public void DropSoso()
  {
    float Distance = Vector3.Distance(soso.transform.position, sosoBlack.transform.position);
    if(Distance < 50)
    {
      soso.transform.position = sosoBlack.transform.position;
      source.clip = correct[Random.Range(0, correct.Length)];
      source.Play();
    }
    else
    {
      soso.transform.position = sosoInitialPos;
      source.clip = incorrect;
      source.Play();
    }
  }

  public void DropSad()
  {
    float Distance = Vector3.Distance(sad.transform.position, sadBlack.transform.position);
    if(Distance < 50)
    {
      sad.transform.position = sadBlack.transform.position;
      source.clip = correct[Random.Range(0, correct.Length)];
      source.Play();
    }
    else
    {
      sad.transform.position = sadInitialPos;
      source.clip = incorrect;
      source.Play();
    }
  }

}
