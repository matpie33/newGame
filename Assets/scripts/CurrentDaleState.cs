using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDaleState : MonoBehaviour
{
    private DaleStates daleState;

    public void Start()
    {
        daleState = DaleStates.WALKING;
    }

    public void UpdateState (DaleStates newState)
    {
        this.daleState = newState;
    }

    public DaleStates GetState()
    {
        return daleState;
    }
   
}
