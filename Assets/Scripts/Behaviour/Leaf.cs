using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

}
