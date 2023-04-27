using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistorbedState : StateBase
{
    GuardBehaviour gb;
    [SerializeField] StateBase ChaseState;
    void Start()
    {
        gb = (GuardBehaviour) npc;
    }

    // Update is called once per frame
    void Update()
    {
        if(gb.DidSeePlayer())
        {
            GoToNextState(ChaseState);
        }
    }
}
