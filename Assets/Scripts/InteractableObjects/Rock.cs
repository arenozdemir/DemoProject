using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, InteractableObjectsInterface
{
    public void NotifyInteractableObjects()
    {
            Debug.Log("Rock: NotifyInteractableObjects");
    }
}
