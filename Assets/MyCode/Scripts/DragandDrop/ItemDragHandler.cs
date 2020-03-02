using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
  //public GameObject happy, happyBlack;
  public GameObject happy, happyBlack;
  Vector2 happyInitialPos;

    // Start is called before the first frame update

    void Start()
    {
      happyInitialPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    public void OnEndDrag(PointerEventData eventData)
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
