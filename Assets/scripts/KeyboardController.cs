﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{

    public bool IsJumpKeyPressed { get; private set; }
    public bool IsPickupOrReleaseObjectsKeyPressed { get; private set; }
    public bool IsThrowingObjectKeyPressed { get; private set; }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsJumpKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumpKeyPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            IsPickupOrReleaseObjectsKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            IsPickupOrReleaseObjectsKeyPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsThrowingObjectKeyPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsThrowingObjectKeyPressed = false;
        }

    }


}
