using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAgent : MonoBehaviour
{
    public GameObject destination;
    public GameObject train;
    public NavMeshAgent player;
    //public Camera trainCamera;
    //public Camera stationCamera;

    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (destination.transform.position == train.transform.position)
        {
            player.SetDestination(destination.transform.position);
        }
    }
}
