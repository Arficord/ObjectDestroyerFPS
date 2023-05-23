using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform anchor;
    [SerializeField] private Vector3 anchorOffset;
    [SerializeField] private Camera controlledCamera;
    [SerializeField][Range(0,1)] private float positionLerpFactor = 0.5f;
    
    private Transform _cameraTransform;
    private float _cameraXRotation = 0f;

    private void Awake() 
    {
        _cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        var desiredPosition = anchor.position + anchorOffset;
        _cameraTransform.position = Vector3.Lerp(transform.position, desiredPosition, positionLerpFactor);
    }

    public void ClampRotate(float rotation)
    {
        _cameraXRotation -= rotation;
        _cameraXRotation = Mathf.Clamp(_cameraXRotation, -90, 90);
        
        _cameraTransform.rotation = Quaternion.Euler(_cameraXRotation, anchor.rotation.eulerAngles.y, 0);
    }
    
    public Vector3 GetLookDirection()
    {
        return _cameraTransform.forward;
    }

    public Vector3 GetPosition()
    {
        return _cameraTransform.position;
    }
}
