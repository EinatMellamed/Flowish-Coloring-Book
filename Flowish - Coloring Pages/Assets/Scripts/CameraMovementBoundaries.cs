using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBoundaries : MonoBehaviour

{
    [SerializeField] private Transform bookBounds;
    [SerializeField] private float minX, maxX, minY, maxY;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        minX = 0f;
        maxX = 1920f;
        minY = 0f;
    }


    private void LateUpdate()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

      

        // Clamp the camera position within the limits
        float clampedX = Mathf.Clamp(cameraPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(cameraPosition.y, minY, maxY);
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, cameraPosition.z);

        mainCamera.transform.position = clampedPosition;
    }
}

