using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneChat : MonoBehaviour
{
    public GameObject phone;
    public GameObject content;
    public GameObject myMessage;
    public GameObject theirMessage;
    public Message[] messages;

    private int messageIndex;
    private GameObject _myMessage;
    private GameObject _TheirMessage;

    void Start()
    {

    }

    public void NextMessage()
    {
        if (messages[messageIndex].type == Message.MessageType.mine)
        {
            _myMessage = Instantiate(myMessage, content.transform);
            _myMessage.GetComponentInChildren<Text>().text = messages[messageIndex].text;
        }
        else
        {
            _TheirMessage = Instantiate(theirMessage, content.transform);
            _TheirMessage.GetComponentInChildren<Text>().text = messages[messageIndex].text;
        }

        messageIndex++;
    }
}

[Serializable]
public class Message
{
    public enum MessageType
    {
        mine,
        theirs
    }

    public MessageType type;
    public string text;
}
