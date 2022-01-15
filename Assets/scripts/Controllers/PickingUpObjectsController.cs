using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpObjectsController : MonoBehaviour
{
    private bool isPickingUpObject;
    [SerializeField]
    private BoxCollider objectsInFrontDetectingCollider;
    private DaleRigsController rigsHandler;
    [SerializeField]
    public GameObject parentPositionObject;
    public GameObject objectToPickup { get; set; }

    private Animator animator;
    private HandsReferenceCalculator handsReferenceCalculator;
    [SerializeField]
    private int initialThrowingSpeed = 40;

    [SerializeField]
    private Camera thirdPersonCamera;

    private CharacterController characterController;

    private LocationCalculatorForPuttingObjectsInFront locationCalculatorForPuttingObjectsInFront;




    void Start()
    {
        rigsHandler = GetComponent<DaleRigsController>();
        animator = GetComponent<Animator>();
        handsReferenceCalculator = GetComponent<HandsReferenceCalculator>();
        locationCalculatorForPuttingObjectsInFront = GetComponent<LocationCalculatorForPuttingObjectsInFront>();
        characterController = GetComponent<CharacterController>();
    }

    public void CalculatePlayerPositionForPickingUpObject()
    {
        Vector3 objectToPickupSize = MathUtils.GetObjectBounds(objectToPickup);
        Vector3 objectToPickupPosition = objectToPickup.transform.position;

        Vector3 positionInFrontX = objectToPickupPosition + objectToPickupSize.x * Vector3.right;
        Vector3 positionBehindX = objectToPickupPosition - objectToPickupSize.x * Vector3.right;
        Vector3 positionInFrontZ = objectToPickupPosition + objectToPickupSize.z * Vector3.forward;
        Vector3 positionBehindZ = objectToPickupPosition - objectToPickupSize.z * Vector3.forward;
        Vector3 dalePosition = gameObject.transform.position;

        float distanceToBehindZ = Vector3.Distance(dalePosition, positionBehindZ);
        float distanceToFrontZ = Vector3.Distance(dalePosition, positionInFrontZ);
        float distanceToBehindX = Vector3.Distance(dalePosition, positionBehindX);
        float distanceToFrontX = Vector3.Distance(dalePosition, positionInFrontX);

        float minimumValue = Mathf.Min(new float[] { distanceToBehindX, distanceToBehindZ, distanceToFrontX, distanceToFrontZ });
        Vector3 destination;
        if (minimumValue == distanceToBehindZ)
        {
            destination = positionBehindZ;
        }
        else if (minimumValue == distanceToFrontZ)
        {
            destination = positionInFrontZ;
        }
        else if (minimumValue == distanceToBehindX)
        {
            destination = positionBehindX;
        }
        else
        {
            destination = positionInFrontX;
        }
        destination.y = gameObject.transform.position.y;

        characterController.enabled = false;
        characterController.transform.position = destination;
        characterController.enabled = true;
        Vector3 objectToPickupPositionWithYEqualToDestinationY = new Vector3(objectToPickupPosition.x, destination.y, objectToPickupPosition.z);
        characterController.transform.rotation = Quaternion.LookRotation(objectToPickupPositionWithYEqualToDestinationY - destination);

    }

    public bool PutObjectInFront()
    {

        LocationForPuttingObject locationForPuttingObject = locationCalculatorForPuttingObjectsInFront.CalculateLocationWhereToPutObject(objectToPickup);
        if (locationForPuttingObject.CanPlaceObject)
        {
            objectToPickup.transform.position = locationForPuttingObject.WhereToPut;
            ReleaseObject();
            objectToPickup = null;
            return true;
        }
        else
        {
            return false;
        }



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
        objectToPickup.transform.rotation = Quaternion.identity;
        SetPickingUpObject(false);

    }

    public Vector3 GetInitialSpeedForThrownObject()
    {
        return initialThrowingSpeed
            * (thirdPersonCamera.transform.forward + new Vector3(0, 0.01f, 0));
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
