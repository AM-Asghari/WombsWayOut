using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FlesController : MonoBehaviour
{
    public GameObject fles;
    public GameObject spawned;
    public Movement movement;
    public float time, distortSpeed, aberrationSpeed;
    private float currTime;
    public bool hit;
    LensDistortion lensDistortion;
    ChromaticAberration aberration;
    public VolumeProfile volumeProfile;

    // Start is called before the first frame update
    void Start()
    {
        spawned = Instantiate(fles, transform);
        spawned.transform.position = transform.position;
        volumeProfile.TryGet<LensDistortion>(out lensDistortion);
        volumeProfile.TryGet<ChromaticAberration>(out aberration);

    }

    // Update is called once per frame
    void Update()
    {
        if (spawned.GetComponent<FlesEnemy>().hit)
        {
            spawned.GetComponent<FlesEnemy>().hit = false;
            movement.speed = -movement.speed;
            movement.cameraRotationSpeed = -movement.cameraRotationSpeed;
            spawned.transform.position = transform.position;
            hit = true;
        }
        if (hit && currTime < time)
        {
            if (lensDistortion.intensity.value < 0.7)
            {
                lensDistortion.intensity.value += Time.deltaTime* distortSpeed;
            }
            if (aberration.intensity.value < 1)
            {
                aberration.intensity.value += Time.deltaTime * aberrationSpeed;
            }
            currTime += Time.deltaTime;
        }
        else if(lensDistortion.intensity.value > 0|| aberration.intensity.value >0)
        {
            if(lensDistortion.intensity.value > 0)
            {
                lensDistortion.intensity.value -= Time.deltaTime * distortSpeed;
            }
            if(aberration.intensity.value > 0)
            {
                aberration.intensity.value -= Time.deltaTime * aberrationSpeed;
            }
        }
        else if (currTime > time)
        {
            hit = false;
            currTime = 0;
            movement.speed = -movement.speed;
            movement.cameraRotationSpeed = -movement.cameraRotationSpeed;
        }

    }
}
