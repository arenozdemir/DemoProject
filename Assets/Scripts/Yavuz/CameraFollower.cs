using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float followSpeed = 5f;
    bool isRotating;
    float lastYValue;
    float lerpValue;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * followSpeed);
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            isRotating = true;
            lastYValue = transform.eulerAngles.y;
            Debug.Log(lastYValue);
            lerpValue = 0;
        }
        if (isRotating)
        {
            lerpValue += Time.deltaTime;
            float endYvalue = Mathf.Lerp(lastYValue, lastYValue + 90, lerpValue);
            transform.rotation = Quaternion.Euler(0, endYvalue, 0);
            if (lerpValue >= 1)
                isRotating = false;
        }

    }
}
