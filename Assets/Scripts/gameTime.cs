using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameTime : MonoBehaviour
{
    private float sec, min, h;
    public TextMeshProUGUI text;
    public Ending ending;
    void Update()
    {
        sec += Time.deltaTime;
        if (sec > 60)
        {
            min++;
            sec -= 60;
        }
        if (min>60)
        {
            h++;
            min -= 60;
        }
        if (h > 0 && !ending.ended)
        {
            text.text = "Hour: " + h + " Min: " + min + " Sec: " + Mathf.Round(sec);
        }
        else if(!ending.ended)
        {
            text.text = "Min: " + min + " Sec: " + Mathf.Round(sec);
        }
    }
}
