using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Mathematics;

public class Ending : MonoBehaviour
{
    public Image white;
    public GameObject birthCert;
    public float time;
    public bool ended = false, isWhite = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            ended = true;
        }
    }
    private void Update()
    {
       if(ended) 
        {
            print("einde");
            if(white.color.a < 1 && !isWhite)
            {
                white.color = new Color(white.color.r, white.color.g, white.color.b, white.color.a + Time.deltaTime * time);
            }
            else if(!isWhite)
            {
                isWhite = true;
                birthCert.SetActive(true);
            }
            else if (white.color.a > 0)
            {
                white.color = new Color(white.color.r, white.color.g, white.color.b, white.color.a - Time.deltaTime * time);
            }
        }
    }
}
