using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    GuardBehaviour gb;
    [SerializeField] StateBase distorbedState;
    void Start()
    {
        gb = (GuardBehaviour)npc;
    }

    // Update is called once per frame
    void Update()
    {
        if (gb.isDistorbed)
            GoToNextState(distorbedState);

    }
}
