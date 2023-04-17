using UnityEngine;
using System;

public class Book : MonoBehaviour, InteractableObjectsInterface
{
    public event Action OnPlayerTriggered;
    public void NotifyInteractableObjects()
    {
            Debug.Log("Book: NotifyInteractableObjects");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            OnPlayerTriggered?.Invoke();
    }
}
