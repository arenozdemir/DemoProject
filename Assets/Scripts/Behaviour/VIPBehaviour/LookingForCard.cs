using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LookingForCard : Leaf
{
    float timer = 0;
    bool isBeginned;
    public override Status Process()
    {
        Begin();
        while (timer <= 5)
        {
            timer += Time.deltaTime;
            //    Debug.Log(timer);
            //  Debug.Log("Looking for card");
            return Status.RUNNING;
        }
        return Status.SUCCESS;
    }
    void Begin()
    {
        if (!isBeginned)
        {
            animator.SetBool("isWalking", false);
            isBeginned = true;
        }
    }
}
