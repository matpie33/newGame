using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


class HandsReferenceCalculator : MonoBehaviour

{
    [SerializeField]
    private GameObject leftHandReference;

    [SerializeField]
    private GameObject rightHandReference;

    public void CalculateHandsReference(GameObject objectToPickup)
    {

        Vector3 objectToPickupPosition = objectToPickup.transform.position;
        Vector3 dalePosition = transform.position;

        Vector3 objectToPickupSize = objectToPickup.GetComponent<Renderer>().bounds.size;
        Vector3 leftHandReferencePosition;
        Vector3 rightHandReferencePosition;
        if (Vector3.Distance(GetValueAlongXAxis(dalePosition), GetValueAlongXAxis(objectToPickupPosition)) <
            Vector3.Distance(GetValueAlongZAxis(dalePosition), GetValueAlongZAxis(objectToPickupPosition)))
        {
            if (objectToPickupPosition.z > dalePosition.z)
            {
                setLeftAndRightHandReferencePositionAlongX(objectToPickupPosition, objectToPickupSize, out leftHandReferencePosition, out rightHandReferencePosition, -1);
            }
            else
            {
                setLeftAndRightHandReferencePositionAlongX(objectToPickupPosition, objectToPickupSize, out leftHandReferencePosition, out rightHandReferencePosition, +1);

            }

        }
        else
        {
            if (objectToPickupPosition.x > dalePosition.x)
            {
                setLeftAndRightHandReferencePositionAlongZ(objectToPickupPosition, objectToPickupSize, out leftHandReferencePosition, out rightHandReferencePosition, 1);
            }
            else
            {
                setLeftAndRightHandReferencePositionAlongZ(objectToPickupPosition, objectToPickupSize, out leftHandReferencePosition, out rightHandReferencePosition, -1);

            }
        }
        leftHandReference.transform.position = leftHandReferencePosition;
        rightHandReference.transform.position = rightHandReferencePosition;

    }

    private void setLeftAndRightHandReferencePositionAlongX(Vector3 objectToPickupPosition, Vector3 objectToPickupSize, out Vector3 leftHandReferencePosition, out Vector3 rightHandReferencePosition, int multiplier)
    {
        leftHandReferencePosition = objectToPickupPosition + GetValueAlongXAxis(objectToPickupSize) / 2 * multiplier;
        rightHandReferencePosition = objectToPickupPosition - GetValueAlongXAxis(objectToPickupSize) / 2 * multiplier;
    }
    private void setLeftAndRightHandReferencePositionAlongZ(Vector3 objectToPickupPosition, Vector3 objectToPickupSize, out Vector3 leftHandReferencePosition, out Vector3 rightHandReferencePosition, int multiplier)
    {
        leftHandReferencePosition = objectToPickupPosition + GetValueAlongZAxis(objectToPickupSize) / 2 * multiplier;
        rightHandReferencePosition = objectToPickupPosition - GetValueAlongZAxis(objectToPickupSize) / 2 * multiplier;
    }

    private Vector3 GetValueAlongZAxis(Vector3 dalePosition)
    {
        return Vector3.Scale(dalePosition, Vector3.forward);
    }

    private Vector3 GetValueAlongXAxis(Vector3 vector)
    {
        return Vector3.Scale(vector, Vector3.right);
    }
}
