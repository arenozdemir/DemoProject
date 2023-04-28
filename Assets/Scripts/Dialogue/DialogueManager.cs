using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    DialogueButton currentDialogueNode;
    [SerializeField] TextMeshProUGUI currentText;
    [SerializeField] Transform buttonsParent;
    [SerializeField] TextMeshProUGUI textArea;
    [SerializeField] GameObject UIParent;
    [SerializeField] Transform blackFrame;
    float timer;
    bool isWorking;
    public static DialogueManager Instance{get;private set;}
    private void Awake() {
        Instance = this;
    }
    public void OpenUI()
    {
        UIParent.SetActive(true);
        isWorking = true;
    }
    public void CloseUI()
    {
        UIParent.SetActive(false);
    }
    private void Update() {
        if(isWorking)
            timer+= Time.deltaTime;
        blackFrame.transform.localScale = new Vector3(1,Mathf.Lerp(14,8.3f,timer),1);
    }
    // secim yaptik
    // 1 sn bos kaldi
    //uzun cevap gorunuyor
    //bir saniye bekle
    //bizim uzun cevap yok ol response al


    public void SelectDialogue(DialogueButton dialogue)
    {
        currentDialogueNode = dialogue;
       // currentText.text = dialogue.response;
       // GenerateButtons();
       Invoke("DeleteButtons",0.5f);
       StartCoroutine(DialogueRoutine(1f));
    }
    void ShowLongText()
    {
        textArea.text = currentDialogueNode.longDescriptedText;
    }
    void ShowResponse()
    {
        textArea.text = currentDialogueNode.response;
    }
    void DeleteButtons()
    {
        foreach (Transform item in buttonsParent)
        {
            Destroy(item.gameObject);
        }
    }
    IEnumerator DialogueRoutine(float waitTİme)
    {
        yield return null;
        ShowLongText();
        yield return new WaitForSeconds(waitTİme);
        ShowResponse();
        yield return new WaitForSeconds(1f);
        GenerateButtons();
        
    }

    void GenerateButtons()
    {
        
        foreach (var item in currentDialogueNode.children)
        {
            Instantiate(item,buttonsParent);
        }
    }
}
