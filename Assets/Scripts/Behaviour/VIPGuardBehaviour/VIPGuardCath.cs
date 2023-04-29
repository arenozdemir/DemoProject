using UnityEngine;
using UnityEngine.AI;

public class VIPGuardCath : Leaf
{
    [HideInInspector] public Transform target;
    GuardBehaviour behaviour;
    bool isbeginned;
    [SerializeField] StateBase CatchState;
    public override Status Process()
    {
        Begin();
        if (Vector3.Distance(behaviour.transform.position, behaviour.player.transform.position) < 1f)
        {
            PlayerScript playerScript = FindObjectOfType<PlayerScript>();
            playerScript.GetComponent<NavMeshAgent>().ResetPath();
            playerScript.enabled = false;
            behaviour.currentState.GoToNextState(CatchState);
            return Status.SUCCESS;
        }
        behaviour.agent.SetDestination(behaviour.GetPlayer().transform.position);
        return Status.RUNNING;
    }
    void Begin()
    {
        if (!isbeginned)
        {
            behaviour = GetComponentInParent<GuardBehaviour>();
            animator.SetBool("isWalking",true);
            isbeginned = true;
        }
    }

}
