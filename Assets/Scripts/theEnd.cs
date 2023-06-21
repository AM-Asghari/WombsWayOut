using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class theEnd : MonoBehaviour
{
    public Image white;
    public GameObject birthCert;
    public AudioSource vicSound, loopSound;
    public float time, time2;
    private float currTime2;
    public bool ended = false, isWhite = false, soundplaying = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            ended = true;
        }
    }
    private void Update()
    {
        if (ended)
        {
            print("einde");
            if (white.color.a < 1 && !isWhite)
            {
                white.color = new Color(white.color.r, white.color.g, white.color.b, white.color.a + Time.deltaTime * time);
            }
            else if (!isWhite)
            {
                isWhite = true;
                birthCert.SetActive(true);
            }
            else if (white.color.a > 0)
            {
                white.color = new Color(white.color.r, white.color.g, white.color.b, white.color.a - Time.deltaTime * time);
                if (white.color.a > 0.1f)
                {
                    vicSound.Play();
                }
            }
            else if (!soundplaying)
            {
                soundplaying = true;
                loopSound.Pause();
            }
            else if (currTime2 < time2)
            {
                currTime2 += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

