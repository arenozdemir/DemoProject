using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    float ortografiSize = 7.5f;
    void Update()
    {
        ortografiSize += Input.mouseScrollDelta.y;
        virtualCamera.m_Lens.OrthographicSize = ortografiSize;
      
    }
}
