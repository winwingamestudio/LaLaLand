using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogBox : MonoBehaviour
{
    public GameObject myDialog;
    public GameObject hisDialog;
    public Dialog[] dialogs;

    private int dialogIndex;

    void Start()
    {
        NextDialog();
    }

    public void NextDialog()
    {
        if(dialogs[dialogIndex].name == Dialog.Speaker.Me)
        {
            hisDialog.SetActive(false);
            myDialog.SetActive(true);
            myDialog.GetComponentInChildren<Text>().text = dialogs[dialogIndex].text;
        }
        else
        {
            hisDialog.SetActive(true);
            myDialog.SetActive(false);
            hisDialog.GetComponentInChildren<Text>().text = dialogs[dialogIndex].text;
        }
        
        dialogIndex++;
    }
}

[Serializable]
public class Dialog
{
    public enum Speaker
    {
        Me,
        He
    }

    public Speaker name;
    public string text;
}
