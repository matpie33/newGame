using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpController : MonoBehaviour
{

    private int hpAmount = 10;

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = collision.collider.GetComponent<Rigidbody>();
        if (rigidBody != null && collision.relativeVelocity.magnitude > 10)
        {
            hpAmount--;
            Destroy(collision.collider.gameObject);
            Debug.Log("hp: " + hpAmount);
        }

    }

    public void Update()
    {
        if (hpAmount == 0)
        {
            Debug.Log("killed");
        }
    }

}
