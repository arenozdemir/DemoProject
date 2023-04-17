using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorTester : MonoBehaviour, InteractableObjectsInterface
{
    public void NotifyInteractableObjects()
    {
        PlayerScript player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        if (player.GetTestObject().TryGetComponent(out KeyCard keyCard))
        {
            if (keyCard.cardData.typeOfCard == CardData.TypeOfCard.YunusunKartý)
            {
                Debug.Log("DoorTester: NotifyInteractableObjects");
                transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            }
        }
    }
}

