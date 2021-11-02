using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDaleController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private Transform playerPosition;

    [SerializeField]
    private float minimumDistanceToFollowPlayer = 5;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(playerPosition.position, gameObject.transform.position) < minimumDistanceToFollowPlayer)
        {
            navMeshAgent.destination = playerPosition.transform.position;
        }



    }


}
