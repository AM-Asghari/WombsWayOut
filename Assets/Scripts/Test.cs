using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;

    public Transform target;
    Vector3 destination;
    bool playerSeen = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, target) < 0.1f)
        //{
        //IterateWaypointIndex();
        //UpdateDestination();
        //}
        if (playerSeen == true)
        {
            Chase();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerSeen = true;
            Debug.Log("I See You");
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerSeen = false;
            Debug.Log("I Dont See You");
        }
    }

    void Chase()
    {
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }
    }

    void UpdateDestination()
    {
        //target = waypoints[waypointIndex].position;
        //agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
}
