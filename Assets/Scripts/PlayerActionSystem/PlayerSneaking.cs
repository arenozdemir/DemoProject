using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSneaking : MonoBehaviour, IObserver
{
    private NavMeshAgent playerNavMeshAgent;
    public void OnNotify(PlayerActionsEnum action)
    {
        if (action == PlayerActionsEnum.Sneaking)
        {
            StartCoroutine(Sneaking());
        }
        else if (action == PlayerActionsEnum.Standing)
        {
            StopCoroutine(Sneaking());
            if (playerNavMeshAgent.velocity.magnitude < 0.1f)
            {
                GetComponentInParent<Animator>().CrossFade("Idle", 0.1f);
            }
            else
            {
                GetComponentInParent<Animator>().CrossFade("Walking", 0.1f);
            }
        }
    }
    private IEnumerator Sneaking()
    {
        while (true)
        {
            if (playerNavMeshAgent.velocity.magnitude < 0.1f)
            {
                GetComponentInParent<Animator>().CrossFade("Female Crouch Pose", 0.1f);
            }
            else
            {
                GetComponentInParent<Animator>().SetBool("isSneaking", true);
            }
            yield return null;
        }
    }
    private void Awake()
    {
        playerNavMeshAgent = GetComponentInParent<NavMeshAgent>();
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
