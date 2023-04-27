using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBubbleLeaf : MonoBehaviour
{
    [SerializeField] Transform canvasRotator;
    float timer;
    float clamped;
    bool isGrowing = true;
    private void OnEnable() {
        timer = 0;
        isGrowing = true;
        canvasRotator.gameObject.SetActive(true);
    }
    void Update()
    {
        if(isGrowing)
            timer += Time.deltaTime;
        else
            timer -= Time.deltaTime;
        clamped = Mathf.Clamp01(timer);
        canvasRotator.localScale = Vector3.one * clamped;
        
        if(timer >=2)
        {
            isGrowing = false;   
        }
        if(timer <-0.1f)
        {
            canvasRotator.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
        }
        
    }
}
