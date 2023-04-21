using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerScript : ObserverManager
{
    [SerializeField] GameObject testObject;

    List<Signals> signals = new List<Signals>();

    private NavMeshAgent playerNavMeshAgent;

    [SerializeField]
    [Range(0, 15)] private float interactRange = 1f;
    
    private InputManager playerInput;
    private void Awake()
    {
        playerNavMeshAgent = GetComponent<NavMeshAgent>();
        playerInput = new InputManager();

        playerInput.FindAction("Interact").started += Interact;
        
        playerInput.FindAction("Sneaking").started += Sneaking;
        playerInput.FindAction("Sneaking").canceled += Sneaking;
        
        playerInput.FindAction("Signals").started += Signals;
        playerInput.FindAction("Signals").canceled += Signals;

        playerInput.FindAction("Move").started += Move;
        playerInput.FindAction("Move").canceled += Move;
    }
    private void Start()
    {
        //Buraya dikkat
        foreach (MonoBehaviour signal in FindObjectsOfType<MonoBehaviour>())
        {
            if (signal.TryGetComponent(out Signals signalComponent))
            {
                signals.Add(signalComponent);
            }
        }
        signals.ForEach(x => x.Hide());
    }
    void Update()
    {
        RotatePlayer();
    }
    #region Sneaking
    
    private void Sneaking(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            NotifyObservers(PlayerActionsEnum.Sneaking);
        }
    }
    #endregion
    
    #region moving
    private void Move(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            NotifyObservers(PlayerActionsEnum.Moving);
        }
    }
    #endregion

    #region rotating
    private void RotatePlayer()
    {
        //Vector3 direction = playerNavMeshAgent.steeringTarget - transform.position;
        //direction.y = 0;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerNavMeshAgent.steeringTarget - transform.position), Time.deltaTime * 5);
    }
    #endregion

    #region Interact
    private void Interact(InputAction.CallbackContext context)
    {
        EnvironmentDetecting();
    }

    private void Signals(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            signals.ForEach(x => x.Show());
        }
        else if (context.canceled)
        {
            signals.ForEach(x => x.Hide());
        }
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
//public static class AnimationSetter
//{
//    public delegate void AnimationState(PlayerScript player, AnimationState animation);
//    public static AnimationState animationState;
//    public enum States { idle, Walking, Running, Snake }
    
//    static AnimationState[] animations = { idle, Walking, Running, Snake };
//    public static AnimationState GetFunction(States name) => animations[(int)name];
//    public static void idle(PlayerScript player, AnimationState animation)
//    {
//        player.GetComponentInParent<Animator>().CrossFade("Standing W_Briefcase Idle", 0.03f);
//    }
//    public static void Walking(PlayerScript player, AnimationState animation)
//    {
//        player.GetComponentInParent<Animator>().CrossFade("Walking", 0.03f);
//    }
//    public static void Running(PlayerScript player, AnimationState animation)
//    {
//        //do something
//    }
//    public static void Snake(PlayerScript player, AnimationState animation)
//    {
//        //do something
//    }
    
//}