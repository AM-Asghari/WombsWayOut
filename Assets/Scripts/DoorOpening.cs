using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public Transform doorPivot;
    public float multiplier;
    void Start()
    {
        
    }

    void Update()
    {
        if(doorPivot.rotation.w > 0.175) 
        {
            doorPivot.Rotate(new Vector3(0, Time.deltaTime * multiplier, 0));
        }
    }
}
