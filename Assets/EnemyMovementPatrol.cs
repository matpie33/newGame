using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform destinationPoint;

    private List<Vector3> extremePoints = new List<Vector3>();

    private Vector3 destinationToWhichWeCurrentlyMove;
    private int indexOfCurrentDestination;
    private bool initialized;


    void Start()
    {
        extremePoints.Add(destinationPoint.position);

        navMeshAgent = GetComponent<NavMeshAgent>();
        indexOfCurrentDestination = 0;
        destinationToWhichWeCurrentlyMove = extremePoints[indexOfCurrentDestination];

    }

    void Update()
    {
        if (!initialized && navMeshAgent.isOnNavMesh)
        {
            initialized = true;
            extremePoints.Add(gameObject.transform.position);
            navMeshAgent.SetDestination(destinationToWhichWeCurrentlyMove);

        }

        if (Vector3.Distance(destinationToWhichWeCurrentlyMove, gameObject.transform.position) < 1f)
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
