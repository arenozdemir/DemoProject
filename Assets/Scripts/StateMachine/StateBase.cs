using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public Node tree;
    protected NPCBehaviour npc;
    private void Awake() {
        npc = GetComponentInParent<NPCBehaviour>();
    }
    public void GoToNextState(StateBase nextState)
    {
        npc.currentState = nextState;
        gameObject.SetActive(false);
        nextState.gameObject.SetActive(true);
    }
   
}
