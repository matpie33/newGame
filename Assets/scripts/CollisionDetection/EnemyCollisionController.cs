using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionController : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private DaleHpController daleHpController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        daleHpController = FindObjectOfType<DaleHpController>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();

    }

    void Update()
    {
        if (navMeshAgent == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < navMeshAgent.stoppingDistance)
        {
            daleHpController.DecreasePlayerHP();

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
