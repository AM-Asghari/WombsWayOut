using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SigEnemy : MonoBehaviour
{
    public bool hit;
    public AudioSource hoest;
    private void Start()
    {
        hoest = GameObject.Find("Player").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            hit = true;
            hoest.Play();
        }
    }

}
