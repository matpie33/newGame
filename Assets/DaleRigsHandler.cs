using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class DaleRigsHandler : MonoBehaviour
{

    public Rig PickingUpObjectsHandsRig;

    void Start()
    {
        PickingUpObjectsHandsRig.weight = 0f;
    }

    public void EnablePickupObjectRig()
    {
        PickingUpObjectsHandsRig.weight = 1f;
    }
    public void DisablePickupObjectRig()
    {
        PickingUpObjectsHandsRig.weight = 0f;
    }
}
