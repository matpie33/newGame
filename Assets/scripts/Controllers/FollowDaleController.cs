using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDaleController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private GameObject dale;

    [SerializeField]
    private float minimumDistanceToFollowPlayer = 5;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
    }

    void Update()
    {
        Vector3 direction = Vector3.Normalize(dale.transform.position - navMeshAgent.transform.position);
        navMeshAgent.destination = dale.transform.position - direction;
        if (Vector3.Distance(dale.transform.position, gameObject.transform.position) < minimumDistanceToFollowPlayer)
        {
            gameObject.transform.LookAt(dale.transform);
        }



    }


}
