using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHpController : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 10;

    [SerializeField]
    private Slider slider;

    private int currentHp;

    public void Start()
    {
        slider.maxValue = maxHP;
        slider.value = maxHP;
        currentHp = maxHP;
    }

    public void ResetHp()
    {
        slider.value = maxHP;
        currentHp = maxHP;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidBody = collision.collider.GetComponent<Rigidbody>();
        if (rigidBody != null && collision.relativeVelocity.magnitude > 10)
        {
            slider.value--;
            currentHp--;
            Destroy(collision.collider.gameObject);
        }

    }



    public void Update()
    {
        if (currentHp == 0)
        {
            SceneManager.LoadScene("Level1Finished");
        }

    }



}
