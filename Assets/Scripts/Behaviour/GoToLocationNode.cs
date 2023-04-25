using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static NPCBehaviour;

public class GoToLocationNode : Leaf
{
    [SerializeField] Transform target;

    private NPCBehaviour behaviour;
    private void OnEnable()
    {
        behaviour = GetComponentInParent<NPCBehaviour>();
    }
    public override Status Process()
    {
        Node.Status status = GoToLocation(target.position);
        return status;
    }
    Node.Status GoToLocation(Vector3 destination)
    {
        destination.y = behaviour.transform.position.y;
        float distanceToTarget = Vector3.Distance(behaviour.transform.position, destination);
        if (behaviour.state == ActionState.IDLE)
        {
            animator.SetBool("isWalking", true);
            behaviour.agent.SetDestination(destination);
            behaviour.state = ActionState.WORKING;
        }
        else if (Vector3.Distance(behaviour.agent.pathEndPosition, destination) >= 2f)
        {
            animator.SetBool("isWalking", false);
            behaviour.state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget <= 1f)
        {
            animator.SetBool("isWalking", false);
            behaviour.state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}
