using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject backDoor;
    [SerializeField] private GameObject bar;

    public Node vipAiTree;

    public NavMeshAgent agent;
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
    }
    void Update()
    {
        if (treeStatus != Node.Status.SUCCESS)
        {
            treeStatus = vipAiTree.Process();
        }
    }
}
