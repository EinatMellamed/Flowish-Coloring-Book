using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInAndOut : MonoBehaviour


{
    Vector3 touchStart;
    [SerializeField] float zoomOutMin = 0.5f;
    [SerializeField] float zoomOutMax = 20f;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 2)
        {
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                if (Mathf.Abs(difference) > 15f)
                {
                    Zoom(difference * 0.05f);
                }
                else
                {
                    Vector2 averageTouchPosition = (touchZero.position + touchOne.position) * 0.5f;
                    Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(averageTouchPosition);
                    Camera.main.transform.position += direction;
                }
            }
            else
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}




