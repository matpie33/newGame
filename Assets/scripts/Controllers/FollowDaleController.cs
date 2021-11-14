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
            navMeshAgent.destination = playerPosition.transform.position;
        if (Vector3.Distance(playerPosition.position, gameObject.transform.position) < minimumDistanceToFollowPlayer)
        {
            gameObject.transform.LookAt(playerPosition);
        }



    }


}
