using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    #region Singleton
    public static GetPlayer instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

}
