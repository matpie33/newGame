using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallsCollisionDetector : MonoBehaviour
{

    private GameObject dale;

    [SerializeField]
    private float minimumDistanceToHit = 0.03f;
    private DaleHpController daleHpController;

    public void Start()
    {
        dale = GameObject.FindGameObjectWithTag(TagsManager.PLAYER);
    }


    public void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if (Vector3.Distance(transform.position, dale.transform.position) < minimumDistanceToHit)
        {
            daleHpController.DecreasePlayerHP();
            Destroy(gameObject);
        }
    }

}
