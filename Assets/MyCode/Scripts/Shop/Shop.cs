using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
  public GameObject[] items;
  public int[] itemsPrice;
  public GameObject[] itemsButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(int i)
    {
      if(GameManager.Instance.currentScore >= itemsPrice[i])
      {
        items[i].SetActive(true);
        itemsButton[i].SetActive(false);
        GameManager.Instance.LostScore(itemsPrice[i]);
      }

    }
}
