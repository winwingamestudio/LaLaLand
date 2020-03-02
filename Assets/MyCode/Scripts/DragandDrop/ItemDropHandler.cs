using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ItemDropHandler : MonoBehaviour, IDropHandler
{
  public GameObject happy;
  Vector2 happyInitialPos;

    public void OnDrop(PointerEventData eventData)
    {
      float Distance = Vector3.Distance(happy.transform.position, this.transform.position);
      if(Distance < 50)
      {
        happy.transform.position = this.transform.position;
      }
      else
      {
        happy.transform.position = happyInitialPos;
      }
    }

}
