using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageUI : MonoBehaviour
{
    [SerializeField] Book book;
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        book.OnPlayerTriggered += ShowImage;
        testVector = rectTransform.position;
    }

    void ShowImage()
    {
       transform.position = Camera.main.WorldToScreenPoint(book.transform.position);
        testVector = transform.position;
        GetComponent<Image>().enabled = true;
        
    }
    Vector3 testVector = Vector3.zero;
    private void Update()
    {
        rectTransform.position = Mathf.Sin(Time.time) * 10 * Vector3.up + testVector;
    }
}
