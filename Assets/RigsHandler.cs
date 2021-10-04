using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigsHandler : MonoBehaviour
{

    public Rig RigLayer;

    void Start()
    {
        RigLayer.weight = 0f;
    }

    public void EnablePickupObjectRig()
    {
        RigLayer.weight = 1f;
    }
}
