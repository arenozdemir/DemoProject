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
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectButton);
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
    void SelectButton()
    {
        DialogueManager.Instance.SelectDialogue(this);
    }

    
}
