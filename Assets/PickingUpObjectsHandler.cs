using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpObjectsHandler : MonoBehaviour
{
    private bool IsPickingUpObject;
    public BoxCollider ObjectsInFrontDetectingCollider;
    public DaleRigsHandler RigsHandler { get; private set; }

    public GameObject ParentPositionObject;
    public GameObject ObjectToPickup { get; set; }

    private Animator Animator;

    void Start()
    {
        RigsHandler = GetComponent<DaleRigsHandler>();
        Animator = GetComponent<Animator>();
    }

    public void MarkPickingUpObjectTrue()
    {
        SetPickingUpObject(true);
    }

    public void SetPickingUpObject(bool isPickingObject)
    {
        IsPickingUpObject = isPickingObject;
    }

    public bool GetIsPickingUpObject()
    {
        return IsPickingUpObject;
    }

    public void PickupObject()
    {

        ObjectToPickup.GetComponent<Rigidbody>().isKinematic = true;
        ObjectsInFrontDetectingCollider.enabled = false;
        ObjectToPickup.transform.parent = ParentPositionObject.transform;
        Animator.SetBool("pickupObjects", false);
        RigsHandler.EnablePickupObjectRig();
    }

    public void ReleaseObject()
    {
        RigsHandler.DisablePickupObjectRig();
        Animator.SetBool("pickupObjects", false);
        ObjectToPickup.transform.parent = null;
        ObjectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        ObjectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
    }


}
