using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    private Animator animator;
    private GravityHandler gravityHandler;


    void Start()
    {
        animator = FindObjectOfType<Animator>();
        gravityHandler = FindObjectOfType<GravityHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumpKeyPressed = false;
        }

    }

    public bool isJumpKeyPressed { get; private set; }

}
