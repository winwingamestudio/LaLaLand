using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneChat : MonoBehaviour
{
    public GameObject content;
    public GameObject myMessage;
    public GameObject hisMessage;
    public PhoneMessage[] messages;

    private int messageIndex;
    private GameObject _myMessage;
    private GameObject _hisMessage;

    void Start()
    {
        StartCoroutine(HisNextMessage());
    }

    public void MyNextMessage()
    {
        if (messages[messageIndex].name == PhoneMessage.Sender.Me)
        {
            _myMessage = Instantiate(myMessage, content.transform);
            _myMessage.GetComponentInChildren<Text>().text = messages[messageIndex].text;

            messageIndex++;
            StartCoroutine(HisNextMessage());
        }
    }

    IEnumerator HisNextMessage()
    {
        if (messages[messageIndex].name == PhoneMessage.Sender.He)
        {
            yield return new WaitForSeconds(1);

            _hisMessage = Instantiate(hisMessage, content.transform);
            _hisMessage.GetComponentInChildren<Text>().text = messages[messageIndex].text;

            messageIndex++;
            StartCoroutine(HisNextMessage());
        }
    }
}

[Serializable]
public class PhoneMessage
{
    public enum Sender
    {
        Me,
        He
    }

    public Sender name;
    public string text;
}
