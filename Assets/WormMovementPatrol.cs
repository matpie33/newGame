using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WormMovementPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform destinationPoint;

    private List<Vector3> extremePoints = new List<Vector3>();

    private Vector3 destinationToWhichWeCurrentlyMove;
    private int indexOfCurrentDestination;

    void Start()
    {
        extremePoints.Add(destinationPoint.position);
        extremePoints.Add(gameObject.transform.position);
        navMeshAgent = GetComponent<NavMeshAgent>();
        indexOfCurrentDestination = 0;
        destinationToWhichWeCurrentlyMove = extremePoints[indexOfCurrentDestination];
        navMeshAgent.SetDestination(destinationToWhichWeCurrentlyMove);
    }

    void Update()
    {
        if (Vector3.Distance(destinationToWhichWeCurrentlyMove, gameObject.transform.position) < 0.5f)
        {
            indexOfCurrentDestination++;
            if (indexOfCurrentDestination == 2)
            {
                indexOfCurrentDestination = 0;
            }
            destinationToWhichWeCurrentlyMove = extremePoints[indexOfCurrentDestination];
            navMeshAgent.SetDestination(destinationToWhichWeCurrentlyMove);

        }
        gameObject.transform.LookAt(destinationToWhichWeCurrentlyMove);
    }
}
