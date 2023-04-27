using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : StateBase
{
    GuardBehaviour gb;
    [SerializeField] StateBase lookForPlayer;
    [SerializeField] GameObject bubble;

    void Start()
    {
        gb =(GuardBehaviour)npc;
        
    }
    private void OnEnable() {
        bubble.gameObject.SetActive(true);
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
