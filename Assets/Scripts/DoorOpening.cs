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
}
