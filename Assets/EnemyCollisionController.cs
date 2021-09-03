using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    private const int SECONDS_BETWEEN_DRAINING_HP = 2;
    private DaleHealth daleHealth;
    private bool timeOffsetPassedBetweenDrainingHP = true;
    private bool isEnemyCollidingWithPlayer = false;
    private GameObject player;
    public float stoppingDistance = 1.2f;

    void Start()
    {
        player = GetPlayer.instance.player;
        daleHealth = GetPlayer.instance.player.GetComponent<DaleHealth>();

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < stoppingDistance)
        {
            isEnemyCollidingWithPlayer = true;
            if (timeOffsetPassedBetweenDrainingHP)
            {
                StartCoroutine(DrainHpFromPlayer());
            }
        }
        else
        {
            isEnemyCollidingWithPlayer = false;
        }
    }



    void OnCollisionExit(Collision collision)
    {
        isEnemyCollidingWithPlayer = false;
    }


    IEnumerator DrainHpFromPlayer()
    {
        while (isEnemyCollidingWithPlayer)
        {
            timeOffsetPassedBetweenDrainingHP = false;
            daleHealth.health = daleHealth.health - 20;
            Debug.Log(daleHealth.health);
            yield return new WaitForSeconds(SECONDS_BETWEEN_DRAINING_HP);
            timeOffsetPassedBetweenDrainingHP = true;
        }


    }


}
