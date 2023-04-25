using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBehaviour : NPCBehaviour
{
    private void Start()
    {
        animator.SetFloat("cycleOffset", Random.Range(0, 1f));
    }
}
