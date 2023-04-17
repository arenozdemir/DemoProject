using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{

    public override Status Process()
    {
        //while (currentChild < children.Count)
        //{
         
        //    Status s = children[currentChild].Process();
        //    if (s != Status.SUCCESS)
        //        return s;
        //    currentChild++;
        //}
        //return Status.RUNNING;
        Status childStatus = children[currentChild].Process();
        if (childStatus == Status.RUNNING) return Status.RUNNING;
        if(childStatus == Status.FAILURE) return Status.FAILURE;
        currentChild++;
        if(currentChild >= children.Count)
        {
            currentChild= 0;
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
    
}
