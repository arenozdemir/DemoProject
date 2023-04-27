using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStanding : MonoBehaviour, IObserver
{
    private NavMeshAgent playerNavMeshAgent;
    private Animator animator;
    
    bool isStanding;
    public void OnNotify(PlayerActionsEnum action)
    {
        if (action == PlayerActionsEnum.Standing)
        {
            isStanding = true;
        }
        //else isWalking = false;
    }
    private void Update()
    {
        Standing();
    }
    private void Standing()
    {
        if (isStanding)
        {
            if (playerNavMeshAgent.velocity.magnitude > .1f)
            {
                animator.SetBool("isWalking", true);
            }
            if (playerNavMeshAgent.velocity.magnitude < .1f)
            {
                animator.SetBool("isIdle", true);
            }
        }
    }
    private void Awake()
    {
        playerNavMeshAgent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        ObserverManager.Instance.AddObserver(this);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveObserver(this);
    }
}
