using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float rotationY;
    private float rotationX;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private float _mouseSensitivity = 2.5f;
    [SerializeField]
    private float _smoothTime = 0.5f;
    [SerializeField]
    private Vector2 _rotationXMinMax = new Vector2(-100, 50);
    [SerializeField]
    private Vector2 _rotationYMinMax = new Vector2(0, 40);
    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        Quaternion playerRotation = playerTransform.rotation;

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        rotationX += mouseX;
        rotationY -= mouseY;

        rotationX = Mathf.Clamp(rotationX, _rotationXMinMax.x, _rotationXMinMax.y);
        rotationY = Mathf.Clamp(rotationY, _rotationYMinMax.x, _rotationYMinMax.y);
        Vector3 nextRotation = new Vector3(rotationY, rotationX);

        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, _smoothTime);
        transform.rotation = playerRotation * Quaternion.Euler(currentRotation);
    }
}