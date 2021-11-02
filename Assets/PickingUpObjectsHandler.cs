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
    public GameObject ObjectToPickup { get; set; }

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

        handsReferenceCalculator.CalculateHandsReference(ObjectToPickup);
        ObjectToPickup.GetComponent<Rigidbody>().isKinematic = true;
        objectsInFrontDetectingCollider.enabled = false;
        ObjectToPickup.transform.parent = parentPositionObject.transform;
        animator.SetBool("pickupObjects", false);
        rigsHandler.EnablePickupObjectRig();
    }

    public void ReleaseObject()
    {
        rigsHandler.DisablePickupObjectRig();
        animator.SetBool("pickupObjects", false);
        ObjectToPickup.transform.parent = null;
        ObjectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        objectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
    }

    public Vector3 GetInitialSpeedForThrownObject()
    {
        return initialThrowingSpeed * Vector3.Scale(
            transform.forward, new Vector3(1, 0, 1));
    }

    public void ThrowObject()
    {
        rigsHandler.DisablePickupObjectRig();
        ObjectToPickup.transform.parent = null;
        ObjectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        objectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
        animator.SetBool("throwObjects", false);
        ObjectToPickup.GetComponent<Rigidbody>().AddForce(GetInitialSpeedForThrownObject(), ForceMode.VelocityChange);

    }


}
