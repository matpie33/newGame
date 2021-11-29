using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtils
{
    public static Vector3 GetObjectBounds(GameObject gameObject)
    {
        return gameObject.GetComponentInChildren<Renderer>().bounds.size;
    }

    public static float GetLengthOfObjectInGiventDirection (GameObject gameObject, Vector3 forwardTransform)
    {
        Vector3 size =  gameObject.GetComponentInChildren<Renderer>().bounds.size;
        return Vector3.Scale(size, forwardTransform).magnitude;
    }


}
