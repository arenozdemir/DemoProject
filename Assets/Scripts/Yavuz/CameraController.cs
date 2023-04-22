using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    float ortografiSize = 7.5f;
    [Range(4.5f, 10f)][SerializeField] float minDistance, maxDistance;
    [SerializeField] Transform player;
    float snappedOrtograficSize;
    private void Start()
    {
        snappedOrtograficSize = ortografiSize;
    }
    void Update()
    {
        snappedOrtograficSize += Input.mouseScrollDelta.y;
        float zoomSpped = 10f;
        snappedOrtograficSize = Mathf.Clamp(snappedOrtograficSize, minDistance, maxDistance);
        ortografiSize = Mathf.Lerp(ortografiSize, snappedOrtograficSize, Time.deltaTime * zoomSpped);
        

       // virtualCamera.m_Lens.OrthographicSize = ortografiSize;
       Camera.main.orthographicSize = ortografiSize;
        
      
    }
}
