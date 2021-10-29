using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class DaleRigsHandler : MonoBehaviour
{
    [SerializeField]
    private Rig pickingUpObjectsHandsRig;

    public bool ChangeRigWeightTowardsValue { private get; set; }

    private float targetRigWeight;

    [SerializeField]
    private float rigWeightChangingSpeed;

    void Start()
    {
        pickingUpObjectsHandsRig.weight = 0f;
    }

    public void EnablePickupObjectRig()
    {
        targetRigWeight = 1f;
        ChangeRigWeightTowardsValue = true;
    }
    public void DisablePickupObjectRig()
    {
        targetRigWeight = 0f;
        ChangeRigWeightTowardsValue = true;
    }

    void Update()
    {
        if (ChangeRigWeightTowardsValue)
        {
            pickingUpObjectsHandsRig.weight = Mathf.MoveTowards(pickingUpObjectsHandsRig.weight, targetRigWeight, Time.deltaTime * rigWeightChangingSpeed);
        }
    }

}
