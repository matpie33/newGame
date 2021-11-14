using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtils
{
    public static Vector3 GetObjectBounds(GameObject gameObject)
    {
        return gameObject.GetComponentInChildren<Renderer>().bounds.size;
    }

}
