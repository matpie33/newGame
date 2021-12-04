using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpController : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 10;

    [SerializeField]
    private Slider slider;

    public void Start()
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = collision.collider.GetComponent<Rigidbody>();
        if (rigidBody != null && collision.relativeVelocity.magnitude > 10)
        {
            slider.value--;
            Destroy(collision.collider.gameObject);
        }

    }



    public void Update()
    {


    }



}
