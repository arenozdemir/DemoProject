using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class NPCBehaviour : MonoBehaviour
{
    public Node tree;

    public NavMeshAgent agent;

    protected Animator animator;
    public StateBase currentState;
    public enum ActionState
    {
        IDLE,
        WORKING
    }
    public ActionState state = ActionState.IDLE;

     Node.Status treeStatus = Node.Status.RUNNING;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        if (treeStatus != Node.Status.SUCCESS)
        {
            treeStatus = currentState.tree.Process();
        }
    }
}
