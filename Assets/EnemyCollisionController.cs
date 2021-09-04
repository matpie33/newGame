using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    private GameObject player;
    public float stoppingDistance = 1.2f;
    private GameManagement gameManagement;

    void Start()
    {
        player = GetPlayer.instance.player;
        gameManagement = FindObjectOfType<GameManagement>();

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < stoppingDistance)
        {
            gameManagement.DecreasePlayerHP();

        }
    }

}
