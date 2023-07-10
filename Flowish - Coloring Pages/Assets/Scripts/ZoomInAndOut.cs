using Cinemachine;
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

    [SerializeField] float bookMaxX;
    [SerializeField] float bookMinX;
    [SerializeField] float bookMaxY;
    [SerializeField] float bookMinY;

   

   
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

    private Vector3 ClampCamera(Vector3 targetPos)
    {

         float newX = Mathf.Clamp(Camera.main.transform.position.x, bookMinX, bookMaxX);
       float newY =  Mathf.Clamp(Camera.main.transform.position.y, bookMinY, bookMaxY);

        return new Vector3(newX, newY, Camera.main.transform.position.z);
    }

  

 
}




