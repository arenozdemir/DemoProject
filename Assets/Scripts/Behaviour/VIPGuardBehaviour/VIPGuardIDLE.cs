using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPGuardIDLE : Leaf
{
    public bool isIdle = true;
    public override Status Process()
    {
        Debug.Log("YÜRÜ AMK");
        if (!isIdle)
        {
            Debug.Log("YÜRÜ AMK2");
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
}
