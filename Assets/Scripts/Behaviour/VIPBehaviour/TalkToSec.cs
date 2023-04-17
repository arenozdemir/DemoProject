using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TalkToSec : Leaf
{
    [SerializeField] private GameObject security;
    bool isBeginned;
    public override Status Process()
    {
        Begin();
        return Status.SUCCESS;
    }
    private void Begin()
    {
        if (!isBeginned)
        {
            transform.root.LookAt(security.transform);
            animator.CrossFade("Talking", 0.1f);
            isBeginned = true;
        }
    }
}
