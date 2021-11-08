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

    private LocationCalculatorForPuttingObjectsInFront locationCalculatorForPuttingObjectsInFront;



    void Start()
    {
        rigsHandler = GetComponent<DaleRigsHandler>();
        animator = GetComponent<Animator>();
        handsReferenceCalculator = GetComponent<HandsReferenceCalculator>();
        locationCalculatorForPuttingObjectsInFront = GetComponent<LocationCalculatorForPuttingObjectsInFront>();
    }

    public void PutObjectInFront()
    {
        ReleaseObject();
        LocationForPuttingObject locationForPuttingObject = locationCalculatorForPuttingObjectsInFront.CalculateLocationWhereToPutObject();
        if (locationForPuttingObject.CanPlaceObject)
        {
            objectToPickup.transform.position = locationForPuttingObject.WhereToPut + 0.5f * objectToPickup.GetComponentInChildren<Renderer>().bounds.size.y * Vector3.up + Vector3.up * 0.5f;
        }
        objectToPickup = null;



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
        objectToPickup.GetComponent<Collider>().enabled = false;
        objectsInFrontDetectingCollider.enabled = false;
        objectToPickup.transform.SetParent(parentPositionObject.transform);
        animator.SetBool("pickupObjects", false);
        rigsHandler.EnablePickupObjectRig();
    }

    public void ReleaseObject()
    {
        rigsHandler.DisablePickupObjectRig();
        animator.SetBool("pickupObjects", false);
        objectToPickup.GetComponent<Collider>().enabled = true;
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
        objectToPickup.GetComponent<Collider>().enabled = true;
        objectToPickup.transform.SetParent(null);
        objectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        objectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
        animator.SetBool("throwObjects", false);
        objectToPickup.GetComponent<Rigidbody>().AddForce(GetInitialSpeedForThrownObject(), ForceMode.VelocityChange);
        objectToPickup = null;

    }


}
