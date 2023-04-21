using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour, IObserver
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private NavMeshAgent playerNavMeshAgent;
    public void OnNotify(PlayerActionsEnum action)
    {
        if (action == PlayerActionsEnum.Moving)
        {
            transform.root.GetComponent<Animator>().CrossFade("Walking", 0.1f);
        }
    }
    private void Mover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        //if (Mouse.current.rightButton.IsPressed())
        //{
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        //    {
        //        playerNavMeshAgent.SetDestination(hit.point);
        //    }
        //}
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            if (Mouse.current.rightButton.IsPressed()){
                playerNavMeshAgent.SetDestination(hit.point);
            }
            if (Vector3.Distance(hit.point, transform.root.position) < 1f)
            {
                transform.root.GetComponent<Animator>().CrossFade("Idle", 0.1f);
            }
        }
    }
    private void Update()
    {
        Mover();
    }
    //if (Vector3.Distance(transform.root.position, hit.point) < 1f)
    //{
    //    transform.root.GetComponent<Animator>().CrossFade("Idle", 0.1f);
    //}
    //playerNavMeshAgent.SetDestination(hit.point);
    private void OnEnable()
    {
        ObserverManager.Instance.AddObserver(this);
    }
    private void OnDisable()
    {
        ObserverManager.Instance.RemoveObserver(this);
    }
}
