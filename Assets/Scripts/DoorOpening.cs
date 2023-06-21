using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public bool open;
    public Animator animator;
    void Start()
    {
    }

    void Update()
    {
        animator.enabled = open;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit");
        if (other.gameObject.CompareTag("Haak"))
        {
            open = true;
            print("haak");

        }
    }
}
