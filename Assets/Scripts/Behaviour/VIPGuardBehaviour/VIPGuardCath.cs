using UnityEngine;

public class VIPGuardCath : Leaf
{
    public override Status Process()
    {
        Debug.Log("Catching");
        return Status.SUCCESS;
    }
}
