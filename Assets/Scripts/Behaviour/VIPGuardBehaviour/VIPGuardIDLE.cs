using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIPGuardIDLE : Leaf
{
    public bool isIdle = true;
    public override Status Process()
    {
        if (!isIdle)
        {
            Debug.Log("AAA");
         return Status.SUCCESS;
        }
        Debug.Log("BBB");
        return Status.RUNNING;
    }
}
