using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float lookRadius = 10f;
    private Transform player;
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(TagsManager.PLAYER).transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < lookRadius)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
