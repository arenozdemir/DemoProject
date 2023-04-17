using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class VIPBehaviour : MonoBehaviour
{
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
