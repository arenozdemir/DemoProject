using UnityEngine;
using UnityEngine.AI;

public class GoToDistorber : Leaf {
    GuardBehaviour guard;
    bool isBeginned;
    Vector3 destinationPoint;
    void Begin()
    {
        if(!isBeginned)
        {
            guard = GetComponentInParent<GuardBehaviour>();
            isBeginned = true;
            if(RandomPoint(guard.GetDistorber().position,3f, out destinationPoint))
            {
                guard.agent.SetDestination(destinationPoint);
                animator.SetBool("isWalking",true);
            }
        }
    }
    public override Status Process()
    {
        Begin();
        if(Vector3.Distance(guard.transform.position,destinationPoint)<2f)
        {
            animator.SetBool("isWalking",false);
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere.normalized * range;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}