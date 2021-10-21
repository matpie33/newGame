using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class DaleRigsHandler : MonoBehaviour
{

    public Rig PickingUpObjectsHandsRig;

    public bool ChangeRigWeightTowardsValue { private get; set; }

    private float TargetRigWeight;

    [SerializeField]
    private float RigWeightChangingSpeed;

    void Start()
    {
        PickingUpObjectsHandsRig.weight = 0f;
    }

    public void EnablePickupObjectRig()
    {
        TargetRigWeight = 1f;
        ChangeRigWeightTowardsValue = true;
    }
    public void DisablePickupObjectRig()
    {
        TargetRigWeight = 0f;
        ChangeRigWeightTowardsValue = true;
    }

    void Update()
    {
        if (ChangeRigWeightTowardsValue)
        {
            PickingUpObjectsHandsRig.weight = Mathf.MoveTowards(PickingUpObjectsHandsRig.weight, TargetRigWeight, Time.deltaTime * RigWeightChangingSpeed);
        }
    }

}
