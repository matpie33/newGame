using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpController : MonoBehaviour
{
    [SerializeField]
    private int hpAmount = 10;


    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = collision.collider.GetComponent<Rigidbody>();
        if (rigidBody != null && collision.relativeVelocity.magnitude > 10)
        {
            hpAmount--;
            Destroy(collision.collider.gameObject);
        }

    }



    public void Update()
    {


    }



}
