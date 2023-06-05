using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed,cameraRotationSpeed;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0|| Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(speed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized);
        }
        if(Input.GetAxis("CameraRotation") != 0)
        {
            transform.Rotate(0,Input.GetAxis("CameraRotation") * Time.deltaTime * cameraRotationSpeed, 0);
        }
    }
}
