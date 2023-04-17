using System;
using UnityEngine;

public class KeyCard : ITakeable, InteractableObjectsInterface
{
    public CardData cardData;
    public void NotifyInteractableObjects()
    {
        Debug.Log("KeyCard: NotifyInteractableObjects");
        ObjectControl();
    }
}
