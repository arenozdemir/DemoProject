using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUp : Leaf
{
    [SerializeField] string dialog;
    bool isBeginned;
    public override Status Process()
    {
        Begin();
        return Status.SUCCESS;
    }
    private void Begin()
    {
        if (isBeginned) return;
        TextBoxScript.instance.GetComponentInChildren<TextMeshProUGUI>().text = dialog;
        TextBoxScript.instance.FadeIn();
        isBeginned = true;
    }
}
