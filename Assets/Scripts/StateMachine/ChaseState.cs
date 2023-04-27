using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateBase
{
    GuardBehaviour gb;
    [SerializeField] StateBase lookForPlayer;
    void Start()
    {
        gb =(GuardBehaviour)npc;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gb.DidSeePlayer())
        {
            GoToNextState(lookForPlayer);
        }
    }
}
