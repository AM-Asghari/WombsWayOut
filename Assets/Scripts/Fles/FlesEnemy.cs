using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlesEnemy : MonoBehaviour
{
    public bool isrunning;
    public Animator animator;
    public bool hit;

    void Update()
    {
            animator.SetBool("running", isrunning);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            hit = true;
        }
    }

}
