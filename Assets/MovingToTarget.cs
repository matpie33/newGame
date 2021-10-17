using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingToTarget : MonoBehaviour
{
    private Vector3 targetPosition;
    public delegate void Callback();
    public Callback callback { private get; set; }

    public bool isMovingToTarget { get; private set; }

    public void setTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        isMovingToTarget = true;
    }

    void Start()
    {

    }

    void Update()
    {
        if (isMovingToTarget && Vector3.Distance(gameObject.transform.position, targetPosition) > 1f)
        {
            CharacterController characterController = gameObject.GetComponent<CharacterController>();
            characterController.Move(gameObject.transform.forward);
        }
        else
        {
            isMovingToTarget = false;
            if (callback != null)
            {
                callback.Invoke();
                callback = null;
            }
        }
    }


}
