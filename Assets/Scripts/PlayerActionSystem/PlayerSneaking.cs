using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSneaking : MonoBehaviour, IObserver
{
    private NavMeshAgent playerNavMeshAgent;
    private Animator animator;

    bool isSneaking;
    public void OnNotify(PlayerActionsEnum action)
    {
        if (action == PlayerActionsEnum.Sneaking)
        {
            isSneaking = true;
        }
        else if (action == PlayerActionsEnum.Standing) isSneaking = false;
    }
    private void Update()
    {
        Debug.Log(isSneaking);
        Sneaking();
    }
    private void Sneaking()
    {
        if (isSneaking)
        {
            if (playerNavMeshAgent.velocity.magnitude > .1f)
            {
                animator.SetBool("isSneaking", true);
            }
            if (playerNavMeshAgent.velocity.magnitude < .1f)
            {
                animator.CrossFade("Male Crouch Pose", 0.1f);
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
