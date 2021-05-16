using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    public CharacterController characterController;

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical == 1)
        {
            characterController.Move(transform.forward * Time.deltaTime);
        }


    }
}
