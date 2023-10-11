using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public bool open;
    public Animator animator;
    public AudioSource[] doors;
    void Start()
    {
    }

    void Update()
    {
        animator.enabled = open;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Haak"))
        {
            open = true;
            if (!open)
            {
                foreach (var door in doors)
                {
                    door.Play();
                }
            }
        }
    }
}
