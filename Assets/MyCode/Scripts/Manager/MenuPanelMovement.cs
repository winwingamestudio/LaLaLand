using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelMovement : MonoBehaviour
{
  public GameObject MenuOrigPos;
  public GameObject MenuActivePos;
  public GameObject MenuPanel;

  public bool MoveMenuPanel;
  public bool MoveMenuPanelBack;

  public float moveSpeed;
  public float tempMenuPos;

    // Start is called before the first frame update
    void Start()
    {
      MenuPanel.transform.position = MenuOrigPos.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
      if(MoveMenuPanel)
      {
        MenuPanel.transform.position = Vector3.Lerp(MenuPanel.transform.position, MenuActivePos.transform.position, moveSpeed * Time.deltaTime);

        if(MenuPanel.transform.localPosition.x == tempMenuPos)
        {
          MoveMenuPanel = false;
          MenuPanel.transform.position = MenuActivePos.transform.position;
          tempMenuPos = -9999999999999.99f;
        }
      }

      if(MoveMenuPanelBack)
      {
        MenuPanel.transform.position = Vector3.Lerp(MenuPanel.transform.position, MenuOrigPos.transform.position, moveSpeed * Time.deltaTime);

        if(MenuPanel.transform.localPosition.x == tempMenuPos)
        {
          MoveMenuPanelBack = false;
          MenuPanel.transform.position = MenuOrigPos.transform.position;
          tempMenuPos = -9999999999999.99f;
        }
        if(MoveMenuPanelBack)
        {
          tempMenuPos = MenuPanel.transform.position.x;
        }
      }

    }

    public void MovePanel()
    {
      MoveMenuPanelBack = false;
      MoveMenuPanel = true;
    }

    public void MovePanelBack()
    {
      MoveMenuPanelBack = true;
      MoveMenuPanel = false;
    }
}
