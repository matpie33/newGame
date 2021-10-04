using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRootMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController.isGrounded)
        {
            //GetComponent<Animator>().applyRootMotion = true;
        }
        else
        {
            //GetComponent<Animator>().applyRootMotion = false;

        }
    }
}
