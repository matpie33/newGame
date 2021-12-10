using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPatrolController : MonoBehaviour
{
    private const float TIME_BETWEEN_CHANGING_POSITION = 4f;
    private bool isWaitingForNextMove;
    private NavMeshAgent navMeshAgent;
    private float distanceHorizontalFromStartingPoint = 5;
    private float distanceVerticalFromStartingPoint = 5;
    private Vector3 startingPoint;
    private List<Vector3> possiblePositionsToMove = new List<Vector3>();
    private GameObject dale;
    private int indexOfCurrentPosition;


    public void Start()
    {
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        navMeshAgent = GetComponent<NavMeshAgent>();
        startingPoint = gameObject.transform.position;
        possiblePositionsToMove.Add(startingPoint + new Vector3(distanceVerticalFromStartingPoint, 0, distanceHorizontalFromStartingPoint));
        possiblePositionsToMove.Add(startingPoint + new Vector3(distanceVerticalFromStartingPoint, 0, -distanceHorizontalFromStartingPoint));
        possiblePositionsToMove.Add(startingPoint + new Vector3(-distanceVerticalFromStartingPoint, 0, -distanceHorizontalFromStartingPoint));
        possiblePositionsToMove.Add(startingPoint + new Vector3(-distanceVerticalFromStartingPoint, 0, distanceHorizontalFromStartingPoint));
        Debug.Log("possible positions: " + possiblePositionsToMove);
    }

    public void Update()
    {
        transform.LookAt(dale.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (!isWaitingForNextMove)
        {
            StartCoroutine(MoveToNextSpot());
        }
    }

    private IEnumerator MoveToNextSpot()
    {
        isWaitingForNextMove = true;
        yield return new WaitForSeconds(TIME_BETWEEN_CHANGING_POSITION);
        int direction = GetRandomIndexChangeDirection();
        ChangeCurrentIndexPosition(direction);
        navMeshAgent.destination = possiblePositionsToMove[indexOfCurrentPosition];
        isWaitingForNextMove = false;
    }

    private void ChangeCurrentIndexPosition(int direction)
    {
        indexOfCurrentPosition += direction;
        if (indexOfCurrentPosition > possiblePositionsToMove.Count - 1)
        {
            indexOfCurrentPosition = 0;
        }
        if (indexOfCurrentPosition < 0)
        {
            indexOfCurrentPosition = possiblePositionsToMove.Count - 1;
        }
    }

    private static int GetRandomIndexChangeDirection()
    {
        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            direction = -1;
        }

        return direction;
    }
}
