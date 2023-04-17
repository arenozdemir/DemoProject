using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LookingForCard : Leaf
{
    float timer = 0;
    public override Status Process()
    {
        while (timer <= 5)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            Debug.Log("Looking for card");
            return Status.RUNNING;
        }
        return Status.SUCCESS;
    }
}
