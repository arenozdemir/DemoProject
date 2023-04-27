using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPGuardIDLE : Leaf
{
    public bool isIdle = true;
    [SerializeField] StateBase lookForPlayer;
    public override Status Process()
    {
        
        if (!isIdle)
        {
            GetComponentInParent<GuardBehaviour>().currentState.GoToNextState(lookForPlayer);

            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
}
