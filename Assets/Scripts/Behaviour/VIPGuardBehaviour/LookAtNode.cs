using UnityEngine;

public class LookAtNode : Leaf {
    [SerializeField] float turnSpeed;
    float lerpValue;
    [SerializeField] Transform targetDirection;
    [SerializeField] NPCBehaviour nPCBehaviour;
    bool isBeginned;
    public override Status Process()
    {
        Begin();
        lerpValue += Time.deltaTime * turnSpeed; 
        nPCBehaviour.transform.rotation = Quaternion.Slerp(nPCBehaviour.transform.rotation,targetDirection.rotation,lerpValue);
        if(lerpValue >= 1)
        {
            return Status.SUCCESS;
        }
        return Status.RUNNING;
    }
    void Begin()
    {
        if(!isBeginned)
        {
            nPCBehaviour = GetComponentInParent<NPCBehaviour>();
            isBeginned = true;
        }
    }
}