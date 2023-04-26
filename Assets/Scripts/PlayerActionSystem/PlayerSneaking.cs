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
        if (playerNavMeshAgent.velocity.magnitude >= 0.1f)
        {
            animator.SetBool("isSneaking", true);
        }
        else if(playerNavMeshAgent.velocity.magnitude < 0.1f)
        {
            animator.SetBool("isCrouch", true);
        }
        yield return null;
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
