using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeButtonText  : MonoBehaviour {

    public Sprite text1; // I attched these from editor
    public Sprite text2;
    public Sprite text3;

    public Animator anim;
    public Image black;
    public GameObject character;

    public int imgNumberCount;


public void start()
{
  GetComponent<Image>().sprite = text1;

}
    public void changeImages() // make sure to attach this to event trigger
    {
        switch (imgNumberCount)
        {

            case 0:
                GetComponent<Image>().sprite = text2;
                imgNumberCount++; //increase count so it gets higher and switches to different sprite
                break;
            case 1:
                GetComponent<Image>().sprite = text3;
                imgNumberCount++;
                break;
            case 2:
                imgNumberCount++;
                GameConstants.HOMESTATE = 0;
                character.SetActive(false);
                GetComponent<Image>().color = new Color(0,0,0,0);
                StartCoroutine(Fading());
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    IEnumerator Fading()
    {
      anim.SetTrigger("Fade");
      yield return new WaitUntil(()=>black.color.a==1);
      SceneManager.LoadScene("_MyRoomScene");
    }
}
