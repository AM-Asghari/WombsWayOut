using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FlesController : MonoBehaviour
{
    public GameObject fles;
    public GameObject spawned;
    public Movement movement;
    public float time;
    private float currTime;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        spawned = Instantiate(fles, transform);
        spawned.transform.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (spawned.GetComponent<FlesEnemy>().hit)
        {
            spawned.GetComponent<FlesEnemy>().hit = false;
            movement.speed = -movement.speed;
            spawned.transform.position = transform.position;
            hit = true;
        }
        if (hit && currTime < time)
        {
            currTime += Time.deltaTime;
        }
        else if (currTime > time)
        {
            hit = false;
            currTime = 0;
            movement.speed = -movement.speed;
        }

    }
}
