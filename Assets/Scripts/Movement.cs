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
            print("movement");
            transform.Translate(speed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized);
        }
        if(Input.GetAxis("Fire1") > 0 || Input.GetAxis("Fire2")>0)
        {
            transform.Rotate(0,(Input.GetAxis("Fire1") - Input.GetAxis("Fire2")) * Time.deltaTime * cameraRotationSpeed, 0);
        }
    }
}
