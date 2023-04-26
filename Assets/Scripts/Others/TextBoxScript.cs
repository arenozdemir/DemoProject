using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    [SerializeField] Transform fadeInPoint;
    [SerializeField] Transform fadeOutPoint;

    public float timer;
    bool timerBeginned;
    float fadeOutter = 200f;
    float x = 20f;
    TextBoxState textBoxState;
    public static TextBoxScript instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        switch (textBoxState)
        {
            case TextBoxState.FadeIn:
                FadeIn();
                break;
            case TextBoxState.FadeOut:
                FadeOut();
                break;
            case TextBoxState.Idle:
                Idle();
                break;
            case TextBoxState.Null:
                break;
        }
    }

    private void FadeOut()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(fadeInPoint.position, fadeOutPoint.position, timer);
        if (timer >= 1f)
        {
            textBoxState = TextBoxState.Null;
            timer = 0;
        }
    }
    public void FadeIn() 
    {
        textBoxState = TextBoxState.FadeIn;
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(fadeOutPoint.position, fadeInPoint.position, timer);
        if (timer >= 1f)
        {
           
            textBoxState = TextBoxState.Idle;
            timer = 0;
        }
    }
    private void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= 3f)
        {
            textBoxState = TextBoxState.FadeOut;
            timer = 0;
        }
    }
    
}
public enum TextBoxState
{
    Idle,
    FadeIn,
    FadeOut,
    
    Null
}