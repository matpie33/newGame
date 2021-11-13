using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LocationCalculatorForPuttingObjectsInFront : MonoBehaviour
{
    [SerializeField]
    private float distanceAboveDaleCenterForRaycastStart = 0.6f;
    [SerializeField]
    private float howFarToSearchForObstacleFromDale = 3f;
    [SerializeField]
    private LayerMask layerMask;


    public LocationForPuttingObject CalculateLocationWhereToPutObject(GameObject objectToPickup)
    {
        Vector3 daleSize;
        float maximumHeightOnWhichDaleCanPlaceObjects;
        RaycastHit raycastInfo;
        bool isAnyObjectInFrontOfDale;
        CheckIfThereIsObjectInFrontOfDale(out daleSize, out maximumHeightOnWhichDaleCanPlaceObjects, out raycastInfo, out isAnyObjectInFrontOfDale);


        bool canPlaceObject = false;
        Vector3 position = Vector3.zero;
        if (isAnyObjectInFrontOfDale)
        {
            canPlaceObject = FindLocationWhereToPutObject(daleSize, maximumHeightOnWhichDaleCanPlaceObjects, raycastInfo, ref position, objectToPickup);

        }
        else
        {
            canPlaceObject = true;
            position = gameObject.transform.position + 0.5f * Vector3.Scale(gameObject.transform.forward, daleSize) + 0.3f * gameObject.transform.forward;
        }
        return CreateLocationForPuttingObject(canPlaceObject, position);
    }

    private static LocationForPuttingObject CreateLocationForPuttingObject(bool canPlaceObject, Vector3 position)
    {
        LocationForPuttingObject locationForPuttingObject = new LocationForPuttingObject();
        locationForPuttingObject.CanPlaceObject = canPlaceObject;
        locationForPuttingObject.WhereToPut = position;
        return locationForPuttingObject;
    }

    private bool FindLocationWhereToPutObject(Vector3 daleSize, float maximumHeightOnWhichDaleCanPlaceObjects, RaycastHit raycastInfo, ref Vector3 position, GameObject objectToPickup)
    {
        bool canPlaceObject;
        Vector3 originOfRayForCheckingIfThereAreStackedObjects = raycastInfo.point + gameObject.transform.forward * 0.2f;
        int layerBitMask = 1 << layerMask.value;
        int everythingExceptLayerMask = ~layerBitMask;
        RaycastHit[] objectsOnTopOfAnotherRaycastInfo = Physics.RaycastAll(originOfRayForCheckingIfThereAreStackedObjects, Vector3.up, maximumHeightOnWhichDaleCanPlaceObjects, everythingExceptLayerMask);
        if (objectsOnTopOfAnotherRaycastInfo.Length > 1)
        {

            Tuple<Vector3, float> objectYPositionAndHalfOfHeight = GetPropertiesOfObjectOnTopOfAllOther(objectsOnTopOfAnotherRaycastInfo);
            if (objectYPositionAndHalfOfHeight.Item1.y +
                objectYPositionAndHalfOfHeight.Item2 <= gameObject.transform.position.y + 0.5f * daleSize.y)
            {
                canPlaceObject = true;
                position = objectYPositionAndHalfOfHeight.Item1 + Vector3.up * objectYPositionAndHalfOfHeight.Item2;

            }
            else
            {
                canPlaceObject = false;
            }
        }
        else
        {
            GameObject objectInFrontOfDale = raycastInfo.collider.gameObject;
            float heightOfObjectInFrontOfDale = objectInFrontOfDale.GetComponentInChildren<Renderer>().bounds.size.y;
            if (heightOfObjectInFrontOfDale <= maximumHeightOnWhichDaleCanPlaceObjects)
            {
                canPlaceObject = true;
                position = objectInFrontOfDale.transform.position + Vector3.up * 0.5f * heightOfObjectInFrontOfDale + Vector3.Scale(objectToPickup.GetComponentInChildren<Renderer>().bounds.size, Vector3.up) * 0.5f;
            }
            else
            {
                canPlaceObject = false;
            }
        }

        return canPlaceObject;
    }

    private void CheckIfThereIsObjectInFrontOfDale(out Vector3 daleSize, out float maximumHeightOnWhichDaleCanPlaceObjects, out RaycastHit raycastInfo, out bool isAnyObjectInFrontOfDale)
    {
        daleSize = gameObject.GetComponentInChildren<Renderer>().bounds.size;
        maximumHeightOnWhichDaleCanPlaceObjects = daleSize.y;
        float daleSizeHorizontally = Vector3.Scale(daleSize, gameObject.transform.forward).magnitude;
        Vector3 pointSlightlyAboveDaleCenter = gameObject.transform.position + Vector3.up * distanceAboveDaleCenterForRaycastStart;
        Vector3 rayOrigin = pointSlightlyAboveDaleCenter + Vector3.Scale(daleSize, Vector3.down);
        isAnyObjectInFrontOfDale = Physics.Raycast(rayOrigin, gameObject.transform.forward, out raycastInfo, daleSizeHorizontally + howFarToSearchForObstacleFromDale);
    }

    private Tuple<Vector3, float> GetPropertiesOfObjectOnTopOfAllOther(RaycastHit[] raycastInfos)
    {
        Vector3 positionOfHighestObjectInStack = Vector3.zero;
        float maximumY = Mathf.NegativeInfinity;
        float halfBoundY = 0;
        foreach (RaycastHit raycast in raycastInfos)
        {
            if (raycast.collider.gameObject.transform.IsChildOf(gameObject.transform))
            {
                continue;
            }
            GameObject collidingObject = raycast.collider.gameObject;
            if (collidingObject.transform.position.y > maximumY)
            {
                positionOfHighestObjectInStack = collidingObject.transform.position;
                halfBoundY = collidingObject.GetComponentInChildren<Renderer>().bounds.size.y / 2;
            }
        }
        return Tuple.Create(positionOfHighestObjectInStack, halfBoundY);
    }

}
