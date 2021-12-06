using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallsCollisionDetector : MonoBehaviour
{

    private GameObject dale;

    [SerializeField]
    private float minimumDistanceToHit = 0.03f;

    public void Start()
    {
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
    }


    public void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, dale.transform.position) < minimumDistanceToHit)
        {
            GameManagement.instance.DecreasePlayerHP();
            Destroy(gameObject);
        }
    }

}
