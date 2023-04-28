using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuzGoLeaf : Leaf
{
    public override Status Process()
    {
        Begin();
        if(Vector3.Distance(npc.transform.position,destination)<= 0.2f)
        {
             animator.SetBool("isWalking",false);
            return Status.SUCCESS;
        }
        Vector3 dir = (destination - npc.transform.position).normalized;
        npc.transform.forward = Vector3.Lerp(npc.transform.forward,dir,Time.deltaTime * 10f);
        npc.transform.position += npc.transform.forward * Time.deltaTime *2.5f;
        return Status.RUNNING;
    }
    bool isbeginned;
    [SerializeField] Transform target;
    Vector3 destination;
    NPCBehaviour npc;
    void Begin()
    {
        if(!isbeginned)
        {
            npc = GetComponentInParent<NPCBehaviour>();
            animator.SetBool("isWalking",true);
            destination = target.position;
            isbeginned = true;
        }
    }
}
