using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpObjectsHandler : MonoBehaviour
{
    private bool isPickingUpObject;
    public BoxCollider objectsInFrontDetectingCollider;
    private DaleRigsHandler rigsHandler;
    public GameObject parentPositionObject;
    public GameObject ObjectToPickup { get; set; }

    private Animator animator;
    private HandsReferenceCalculator handsReferenceCalculator;



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

    public void ThrowObject()
    {
        rigsHandler.DisablePickupObjectRig();
        ObjectToPickup.transform.parent = null;
        ObjectToPickup.GetComponent<Rigidbody>().isKinematic = false;
        objectsInFrontDetectingCollider.enabled = true;
        SetPickingUpObject(false);
        animator.SetBool("throwObjects", false);
        ObjectToPickup.GetComponent<Rigidbody>().AddForce(50 * Vector3.Scale(
            transform.forward, new Vector3(1, 0, 1)), ForceMode.Impulse);

    }


}
