using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    DialogueButton currentDialogueNode;
    [SerializeField] TextMeshProUGUI currentText;
    [SerializeField] Transform buttonsParent;
    [SerializeField] Transform textArea;
    [SerializeField] GameObject UIParent;
    public static DialogueManager Instance{get;private set;}
    private void Awake() {
        Instance = this;
    }
    public void OpenUI()
    {
        UIParent.SetActive(true);
    }
    public void CloseUI()
    {
        UIParent.SetActive(false);
    }

    public void SelectDialogue(DialogueButton dialogue)
    {
        currentDialogueNode = dialogue;
        currentText.text = dialogue.response;
        GenerateButtons();
    }
    void GenerateButtons()
    {
        foreach (Transform item in buttonsParent)
        {
            if(item == textArea) continue;
            Destroy(item.gameObject);
        }
        foreach (var item in currentDialogueNode.children)
        {
            Instantiate(item,buttonsParent);
            
        }
    }
}
