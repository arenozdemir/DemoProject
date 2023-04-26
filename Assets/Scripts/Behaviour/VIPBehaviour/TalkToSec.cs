using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class TalkToSec : Leaf
{
    [SerializeField] private List<VIPGuardIDLE> guardIdles;
    [SerializeField] private GameObject security;
    bool isBeginned;
    float timer = 0;
    public override Status Process()
    {
        Begin();
        timer += Time.deltaTime;
        if(timer > 2)
        {
            guardIdles.ForEach(x => x.isIdle = false);
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
    private void Begin()
    {
        if (!isBeginned)
        {
            transform.root.GetComponent<NavMeshAgent>().ResetPath();
            transform.root.LookAt(security.transform);
            animator.CrossFade("Talking", 0.1f);
            isBeginned = true;
        }
    }
}
