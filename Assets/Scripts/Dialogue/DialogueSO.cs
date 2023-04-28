using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialoge Text",menuName ="Dialoge")]
public class DialogueSO : ScriptableObject
{
    public string text;

    public DialogueSO[] children;
}
