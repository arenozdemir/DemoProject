using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    float timer;
    bool timerBeginned;
    float fadeOutter = 200f;
    float x = 20f;
    void Start()
    {
        StartCoroutine(FadeOut());

    }
    private void Update()
    {
        if (timerBeginned)
        {
            fadeOutter -= Time.deltaTime * 1000;
            x +=  Time.deltaTime * fadeOutter;
            
            x = Mathf.Clamp(x, -500, 300);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);    
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            FadeIn();
        }
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.5f);
        timerBeginned = true;
    }
    public void FadeIn() 
    {
        fadeOutter = 1000;
    }
}
