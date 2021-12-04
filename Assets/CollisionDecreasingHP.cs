using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDecreasingHP : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float distanceOnWhichDecreaseHp = 0.8f;

    private GameManagement gameManagement;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
        gameManagement = GameManagement.instance;
    }

    public void Update()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < distanceOnWhichDecreaseHp)
        {
            gameManagement.DecreasePlayerHP();
        }
    }


}
