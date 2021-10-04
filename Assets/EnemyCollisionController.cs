using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionController : MonoBehaviour
{
    private GameObject player;
    public float stoppingDistance = 1.2f;
    private GameManagement gameManagement;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        player = GetPlayer.instance.player;
        gameManagement = FindObjectOfType<GameManagement>();
        navMeshAgent = FindObjectOfType<NavMeshAgent>();

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < navMeshAgent.stoppingDistance)
        {
            gameManagement.DecreasePlayerHP();

        }
    }

}
