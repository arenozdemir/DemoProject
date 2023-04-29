using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueButton : MonoBehaviour
{
    public string text;
    public DialogueButton[] children;
    public string response;
    public string longDescriptedText;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectButton);
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
    void SelectButton()
    {
        DialogueManager.Instance.SelectDialogue(this);
        if (children.Length == 0)
        {
            DialogueManager.Instance.HideInTime(2.5f);
        }
    }
    void HideFrame()
    {
        
    }

    
}
