using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float _minCameraDistance = 0.75f;
    [SerializeField]
    private float _maxCameraDistance = 2.5f;
    [SerializeField]
    private float _zoomSpeed = 2f;
    private CinemachineVirtualCamera virtualCamera;
    private Cinemachine3rdPersonFollow follow;
    private Transform playerTransform;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        follow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        HandleZoom();
        AdjustCameraDistance();
    }
    
    private void HandleZoom()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScroll != 0f)
        {
            float targetCameraDistance = follow.CameraDistance - mouseScroll * _zoomSpeed;
            follow.CameraDistance = Mathf.Clamp(targetCameraDistance, _minCameraDistance, _maxCameraDistance);
        }    
    }

     private void AdjustCameraDistance()
    {
        RaycastHit hit;
        Vector3 cameraPosition = virtualCamera.transform.position;
        Vector3 playerPosition = playerTransform.position;
        Vector3 direction = playerPosition - cameraPosition;
        float raycastDistance = _maxCameraDistance;

        int layerMask = ~(1 << LayerMask.NameToLayer("Enemy")); 

        if (Physics.Raycast(cameraPosition, direction, out hit, raycastDistance, layerMask))
        {
            float distanceToObstacle = hit.distance;
            follow.CameraDistance = Mathf.Min(follow.CameraDistance, distanceToObstacle + 1f);
        }
    }
}
