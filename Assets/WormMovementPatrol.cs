using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormMovementPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;


    [SerializeField]
    private List<Vector3> destinations;

    private Vector3 currentDestination;
    private int indexOfCurrentDestination;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        indexOfCurrentDestination = 0;
        currentDestination = destinations[indexOfCurrentDestination];
        navMeshAgent.SetDestination(currentDestination);
    }

    void Update()
    {
        if (Vector3.Distance(currentDestination, gameObject.transform.position) < 0.5f)
        {
            indexOfCurrentDestination++;
            if (indexOfCurrentDestination == 2)
            {
                indexOfCurrentDestination = 0;
            }
            currentDestination = destinations[indexOfCurrentDestination];
            navMeshAgent.SetDestination(currentDestination);
            gameObject.transform.LookAt(currentDestination);

        }
    }
}
