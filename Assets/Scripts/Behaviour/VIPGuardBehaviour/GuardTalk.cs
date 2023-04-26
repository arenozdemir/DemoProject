using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardTalk : Leaf
{
    [SerializeField] private List<VIPGuardIDLE> guardIdle;
    bool isBeginned;
    float timer = 0;
    public override Status Process()
    {
        Begin();
        timer += Time.deltaTime;
        if (timer > 4)
        {
            guardIdle[currentChild].isIdle = false;
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
    private void Begin()
    {
        if (!isBeginned)
        {
            transform.root.GetComponent<NavMeshAgent>().ResetPath();
            isBeginned = true;
        }
    }
}