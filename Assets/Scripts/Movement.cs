using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed,cameraRotationSpeed;
    public AudioSource walk;
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0|| Input.GetAxis("Vertical") != 0)
        {
            Move();
        }
        if (Input.GetAxis("Fire1") > 0 || Input.GetAxis("Fire2")>0)
        {
            Rotation();
        }
        if((Input.GetAxis("Fire1") > 0 || Input.GetAxis("Fire2") > 0|| Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)&& !walk.isPlaying)
        {
            walk.Play();
        }
        else if(!(Input.GetAxis("Fire1") > 0 || Input.GetAxis("Fire2") > 0 || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            walk.Pause();
        }
        if(Input.GetAxis("Fire3") > 0 && Input.GetAxis("Fire4") > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    void Move()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized);
    }
    void Rotation()
    {
        transform.Rotate(0, (Input.GetAxis("Fire1") - Input.GetAxis("Fire2")) * Time.deltaTime * cameraRotationSpeed, 0);
    }
}
