using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPGuardIDLE : Leaf
{
    public bool isIdle = true;
    public override Status Process()
    {
        Debug.Log("Y�R� AMK");
        if (!isIdle)
        {
            Debug.Log("Y�R� AMK2");
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
}
