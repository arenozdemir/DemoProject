using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    [SerializeField] DialogueButton[] children;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectButton);
    }
    void SelectButton()
    {
        
    }

    
}
