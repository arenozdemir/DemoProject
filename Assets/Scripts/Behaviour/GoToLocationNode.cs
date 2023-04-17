using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static VIPBehaviour;

public class GoToLocationNode : Leaf
{
    [SerializeField] Transform target;

    private VIPBehaviour vipBehaviour;
    private void OnEnable()
    {
        vipBehaviour = GetComponentInParent<VIPBehaviour>();
    }
    public override Status Process()
    {
        Node.Status status = GoToLocation(target.position);
        return status;
    }
    Node.Status GoToLocation(Vector3 destination)
    {
        destination.y = vipBehaviour.transform.position.y;
        float distanceToTarget = Vector3.Distance(vipBehaviour.transform.position, destination);
        if (vipBehaviour.state == ActionState.IDLE)
        {
            animator.CrossFade("Walking", 0.1f);
            vipBehaviour.agent.SetDestination(destination);
            vipBehaviour.state = ActionState.WORKING;
        }
        else if (Vector3.Distance(vipBehaviour.agent.pathEndPosition, destination) >= 2f)
        {
            animator.CrossFade("Standing W_Briefcase Idle", .2f);
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget <= 1f)
        {
            animator.CrossFade("Standing W_Briefcase Idle", .2f);
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}
