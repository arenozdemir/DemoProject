using UnityEngine;
using UnityEngine.AI;

public class Wait : Leaf
{
    float timer = 0;
    bool isBeginned;
    public override Status Process()
    {
        timer += Time.deltaTime;
        Begin();
        if (timer > 3)
        {
            GetComponentInParent<NavMeshAgent>().ResetPath();
            return Status.SUCCESS;
        }
        else return Status.RUNNING;
    }
    private void Begin() 
    {
        if (isBeginned) return;
        animator.SetBool("isWalking", false);
        isBeginned = true;
    }
}
