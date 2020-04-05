using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomActivities : MonoBehaviour
{
    public Image[] sitting;
    public Image onBed;
    public Image planting;
    public Image standing;

    private string lastActivity;

    void Start()
    {
        RandomActivity();
    }

    void RandomActivity()
    {
        Color c = new Color(1, 1, 1, 0);

        for(int i = 0; i < sitting.Length; i++)
            sitting[i].color = c;
        onBed.color = c;
        planting.color = c;
        standing.color = c;

        int r = UnityEngine.Random.Range(0, 4);
        string callback;

        if (r == 0)
            callback = "Sitting";
        else if (r == 1)
            callback = "OnBed";
        else if (r == 2)
             callback = "Planting";
        else
            callback = "Standing";

        lastActivity = callback;
        FadeUI(callback, 0, 1);
    }

    public void FadeIn(string callback)
    {
        FadeUI(lastActivity, 1, 0);
        lastActivity = callback;
        FadeUI(callback, 0, 1);
    }

    void FadeUI(string callback, float from, float to)
    {
        iTween.ValueTo(this.gameObject, iTween.Hash("from", from, "to", to, "time", 1, "onupdate", callback));
    }
    void Sitting(float val)
    {
        for(int i = 0; i < sitting.Length; i++)
        {
            Color c = sitting[i].color;
            c.a = val;
            sitting[i].color = c;
        }
    }
    void OnBed(float val)
    {
        Color c = onBed.color;
        c.a = val;
        onBed.color = c;
    }
    void Planting(float val)
    {
        Color c = planting.color;
        c.a = val;
        planting.color = c;
    }
    void Standing(float val)
    {
        Color c = standing.color;
        c.a = val;
        standing.color = c;
    }
}
