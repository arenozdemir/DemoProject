using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wait : Leaf
{
    float timer = 0;
    bool isBeginned;
    public override Status Process()
    {
        timer += Time.deltaTime;
        Begin();
        if (timer > 3)
        {
            GetComponentInParent<NavMeshAgent>().ResetPath();
            return Status.SUCCESS;
        }
        else return Status.RUNNING;
    }
    private void Begin() 
    {
        if (isBeginned) return;
        animator.CrossFade("Standing W_Briefcase Idle", 0.03f);
        isBeginned = true;
    }
}