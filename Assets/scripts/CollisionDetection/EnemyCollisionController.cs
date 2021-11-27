﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionController : MonoBehaviour
{
    private GameObject player;
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
        if (navMeshAgent == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < navMeshAgent.stoppingDistance)
        {
            gameManagement.DecreasePlayerHP();

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = collision.collider.GetComponent<Rigidbody>();
        if (rigidBody != null && collision.relativeVelocity.magnitude > 10)
        {
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);

        }

    }

}
