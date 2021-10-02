﻿using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isPickupOrReleaseObjectsKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isPickupOrReleaseObjectsKeyPressed = false;
        }

    }

    public bool isJumpKeyPressed { get; private set; }
    public bool isPickupOrReleaseObjectsKeyPressed { get; private set; }

}
