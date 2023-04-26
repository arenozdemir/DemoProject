using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSneaking : MonoBehaviour, IObserver
{
    private NavMeshAgent playerNavMeshAgent;
    private Animator animator;
    public void OnNotify(PlayerActionsEnum action)
    {
        if(action == PlayerActionsEnum.Sneaking)
        {
            StartCoroutine(Sneaking());
        }
    }
    private IEnumerator Sneaking()
    {
        while (true) 
        {
            if (playerNavMeshAgent.velocity.magnitude > .1f)
            {
                animator.CrossFade("Sneaking Forward", 0.1f);
            }
            else if (playerNavMeshAgent.velocity.magnitude < .1f)
            {
                animator.CrossFade("Male Crouch Pose", 0.1f);
            }
            yield return null;
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
