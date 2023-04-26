using UnityEngine;
using UnityEngine.AI;

public class Seeking : Sequence
{
    public FieldOfView fieldOfView;
    [SerializeField] VIPGuardCath cath;
    public override Status Process()
    {
        //if fieldOfView.visibleTargets.Count > 0 then return success
        if (fieldOfView.visibleTargets.Count > 0)
        {
            cath.target = fieldOfView.visibleTargets[0];
            transform.root.GetComponent<NavMeshAgent>().ResetPath();
            transform.root.GetComponent<Animator>().CrossFade("Standing W_Briefcase Idle", 0.03f);
            return Status.FAILURE;
        }
        return base.Process();
    }
}
