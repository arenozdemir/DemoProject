using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextBoxScript : MonoBehaviour
{
    float timer;
    bool timerBeginned;
    float fadeOutter = 200f;
    void Start()
    {
        StartCoroutine(FadeOut());

    }
    private void Update()
    {
        if (timerBeginned)
        {
            fadeOutter -= Time.deltaTime * 1000;
            transform.position += Vector3.right * Time.deltaTime * fadeOutter;
        }
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3.5f);
        timerBeginned = true;
    }

}
