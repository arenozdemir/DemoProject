using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{

    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();
        if (childStatus == Status.SUCCESS)
        {
        //    Debug.Log("Selector: success");
            return Status.SUCCESS;
        }
        else if (childStatus == Status.FAILURE)
        {
            
            currentChild++;
            
            if (currentChild >= children.Count)
            {
                currentChild = 0;
            //    Debug.Log("Selector: fail");
                return Status.FAILURE;
            }
            else
            {
              //  Debug.Log("Selector: running");
                return Status.RUNNING;
            }
        }
        else
        {
          //  Debug.Log("Selector: running");
            return Status.RUNNING;
        }
        
    }

}
