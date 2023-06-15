using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SigController : MonoBehaviour
{
    public GameObject sig;
    public GameObject spawned;
    public float time, fogIncrease, colorIncrease;
    private float currTime, colorFade;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        spawned = Instantiate(sig,transform);
        spawned.transform.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawned.GetComponent<SigEnemy>().hit)
        {
            spawned.GetComponent<SigEnemy>().hit=false;
            spawned.transform.position = transform.position;
            hit = true;
        }

        if (hit && currTime < time)
        {
            currTime += Time.deltaTime;
            if (RenderSettings.fogDensity < 0.2)
            {
                RenderSettings.fogDensity += Time.deltaTime * fogIncrease;
            }
            if (colorFade < 1)
            {
                colorFade += Time.deltaTime * colorIncrease;
                RenderSettings.fogColor = new Color(0.9f + 0.1f * colorFade, 0.5f + 0.3f * colorFade, 0.5f + 0.3f * colorFade);
            }
        }
        else if (currTime >= time)
        {

            hit = false;
            currTime = 0;
        }
        else if (RenderSettings.fogDensity > 0.04 || colorFade > 0)
        {
            if (RenderSettings.fogDensity > 0.04)
            {
                RenderSettings.fogDensity -= Time.deltaTime * fogIncrease;
            }
            else
            {
                colorFade -= Time.deltaTime * colorIncrease;
                RenderSettings.fogColor = new Color(0.9f + 0.1f * colorFade, 0.5f + 0.3f * colorFade, 0.5f + 0.3f * colorFade);
            }
        }
    }
}
