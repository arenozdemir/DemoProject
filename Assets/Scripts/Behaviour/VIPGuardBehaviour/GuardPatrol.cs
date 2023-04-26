using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardPatrol : Leaf
{
    [SerializeField] List<Transform> patrolPoints;
    public int currentPoint = 0;
     public float timer = 3;
    bool isBeginned;

    void Begin()
    {
        if (!isBeginned)
        {
            animator.SetBool("isWalking", true);
            isBeginned = true;
        }
    }
    public override Status Process()
    {
        Begin();
        return Patrol();
    }
    private Node.Status Patrol(){
        
        Status s = Status.RUNNING;
        float distance = Vector3.Distance(transform.root.position, patrolPoints[currentPoint].position);
        if(distance<1f)
        {
            timer += Time.deltaTime;
            animator.SetBool("isWalking", false);
            Quaternion look = Quaternion.Slerp(transform.root.rotation, Quaternion.LookRotation(Vector3.forward), 10f * Time.deltaTime);
            transform.root.rotation = currentPoint == 1 ? look : Quaternion.Slerp(transform.root.rotation, Quaternion.LookRotation(Vector3.left), 5f * Time.deltaTime);
        }
        if (s != Status.SUCCESS)
        {
            if (timer > 5)
            {
                currentPoint++;
                timer = 0;
                if (currentPoint >= patrolPoints.Count)
                {
                    currentPoint = 0;
                }
                animator.SetBool("isWalking", true);
            }
            
            transform.root.GetComponent<NavMeshAgent>().SetDestination(patrolPoints[currentPoint].position);
            //  timer += Time.deltaTime;

        }
        return s;
    }
}
