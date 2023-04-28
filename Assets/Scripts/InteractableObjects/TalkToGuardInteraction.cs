using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToGuardInteraction : MonoBehaviour,InteractableObjectsInterface
{
    [SerializeField] DialogueButton firstDialogueText;
    public void NotifyInteractableObjects()
    {
        DialogueManager.Instance.SelectDialogue(firstDialogueText);
        DialogueManager.Instance.OpenUI();
    }
}
