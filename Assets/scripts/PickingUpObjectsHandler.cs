using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpObjectsHandler : MonoBehaviour
{
    private bool isPickingUpObject;
    [SerializeField]
    private BoxCollider objectsInFrontDetectingCollider;
    private DaleRigsHandler rigsHandler;
    [SerializeField]
    public GameObject parentPositionObject;
    public GameObject objectToPickup { get; set; }

    private Animator animator;
    private HandsReferenceCalculator handsReferenceCalculator;
    [SerializeField]
    private int initialThrowingSpeed = 40;



    void Start()
    {
        rigsHandler = GetComponent<DaleRigsHandler>();
        animator = GetComponent<Animator>();
        handsReferenceCalculator = GetComponent<HandsReferenceCalculator>();
    }

    public void PutObjectInFront()
    {
        ReleaseObject();
        Vector3 daleSize = gameObject.GetComponentInChildren<Renderer>().bounds.size;
        objectToPickup.transform.position = gameObject.transform.position + Vector3.Scale(
            gameObject.transform.forward, daleSize);



    }

    public void MarkPickingUpObjectTrue()
    {
        SetPickingUpObject(true);
    }

    public void SetPickingUpObject(bool isPickingObject)
    {
        isPickingUpObject = isPickingObject;
    }

    public bool GetIsPickingUpObject()
    {
        return isPickingUpObject;
    }

    public void PickupObject()
    {

        handsReferenceCalculator.CalculateHandsReference(objectToPickup);
        objectToPickup.GetComponent<Rigidbody>().isKinematic = true;
        objectsInFrontDetectingCollider.enabled = false;
        objectToPickup.transform.SetParent(parentPositionObject.transform);
        animator.SetBool("pickupObjects", false);
        rigsHandler.EnablePickupObjectRig();
    }

    public void ReleaseObject()
    {
        rigsHandler.DisablePickupObjectRig();
        animator.SetBool("pickupObjects", false);
        objectToPickup.transform.SetParent(null);
        objectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        objectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
    }

    public Vector3 GetInitialSpeedForThrownObject()
    {
        return initialThrowingSpeed
            * (transform.forward + new Vector3(0, 0.01f, 0));
    }

    public void ThrowObject()
    {
        rigsHandler.DisablePickupObjectRig();
        objectToPickup.transform.SetParent(null);
        objectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        objectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
        animator.SetBool("throwObjects", false);
        objectToPickup.GetComponent<Rigidbody>().AddForce(GetInitialSpeedForThrownObject(), ForceMode.VelocityChange);

    }


}
