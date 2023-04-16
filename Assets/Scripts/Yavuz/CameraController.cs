using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    float ortografiSize = 7.5f;
    [SerializeField] float minDistance, maxDistance;
    float snappedOrtograficSize;
    private void Start()
    {
        snappedOrtograficSize = ortografiSize;
    }
    void Update()
    {
        snappedOrtograficSize += Input.mouseScrollDelta.y;
        float zoomSpped = 10f;
        snappedOrtograficSize = Mathf.Clamp(ortografiSize, maxDistance, maxDistance);
        ortografiSize = Mathf.Lerp(ortografiSize, snappedOrtograficSize, Time.deltaTime*zoomSpped);
        

        virtualCamera.m_Lens.OrthographicSize = ortografiSize;
      
    }
}
