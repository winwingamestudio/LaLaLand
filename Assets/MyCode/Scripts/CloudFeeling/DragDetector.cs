using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDetector : MonoBehaviour
{
    public float TimeToPushBack = 0.5f;
    public Text debugText;
    public float Force;


    public void DetectDrag(SwipeState state, Rigidbody obj)
    {
        Rigidbody rigidbody = obj;

        if (rigidbody)
        {
            debugText.text = "rigidbody of object not found";


//            throw new NullReferenceException("rigidbody of object not found");
        }

        switch (state)
        {
            case SwipeState.SwipeRight:
                MoveObj(rigidbody, Vector3.right);
                debugText.text = "right";
                rigidbody.gameObject.GetComponent<Cloud>().scoreGetting = true;
                break;

            case SwipeState.SwipeLeft:
                MoveObj(rigidbody, Vector3.left);
                debugText.text = "left";
                rigidbody.gameObject.GetComponent<Cloud>().scoreGetting = true;
                break;

            case SwipeState.NotSwipe:
                debugText.text = "default";
                break;

      }
    }

    public void MoveObj(Rigidbody rb, Vector3 dirction)
    {
        rb.gameObject.GetComponent<Animator>().SetTrigger("touch");
        rb.drag = 0.4f;
//        rb.gameObject.GetComponent<Cloud>().StopToForce = true;
        rb.AddForce(dirction * Force* Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(startback(rb));
    }

    IEnumerator startback(Rigidbody rb)
    {
        yield return new WaitForSeconds(TimeToPushBack);
        rb.drag = 0;
        rb.velocity = Vector3.zero;
        rb.gameObject.GetComponent<Cloud>().force();

    }

}
