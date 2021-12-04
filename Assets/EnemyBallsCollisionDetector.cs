using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallsCollisionDetector : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Player"))
        {
            GameManagement.instance.DecreasePlayerHP();
        }
        Destroy(gameObject);
    }

}
