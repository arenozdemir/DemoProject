using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject testObject;
    
    [SerializeField]
    [Range(0, 15)] private float interactRange = 1f;
    
    NavMeshAgent playerNavMeshAgent;
    private InputManager playerInput;
    
    private bool isInteracted;
    [SerializeField] LayerMask groundLayer;
    private void Awake()
    {
        playerInput = new InputManager();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();

        playerInput.FindAction("Interact").started += Interact;
    }
    void Update()
    {
        MoveToPosition();
        RotatePlayer();
    }
    #region moving
    private void MoveToPosition()
    {
        if (Mouse.current.rightButton.IsPressed())
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer)) 
            {
                playerNavMeshAgent.SetDestination(hit.point);
            }
        }
    }
    #endregion

    #region rotating
    private void RotatePlayer()
    {
        Vector3 direction = playerNavMeshAgent.steeringTarget - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5);
    }
    #endregion

    #region Interact
    private void Interact(InputAction.CallbackContext context)
    {
        EnvironmentDetecting();
    }
    private void EnvironmentDetecting()
    {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position + Vector3.up, interactRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out InteractableObjectsInterface interactable))
                {
                    interactable.NotifyInteractableObjects();
                }
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, interactRange);
    }
    #endregion
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    public void SetTestObject(GameObject testObject) 
    {
        if (this.testObject != null)
        {
            this.testObject.SetActive(true);
        }
        this.testObject = testObject;
        testObject.SetActive(false);
    }
    public GameObject GetTestObject() => testObject;
}
