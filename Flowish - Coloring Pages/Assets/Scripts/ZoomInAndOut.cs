using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInAndOut : MonoBehaviour
{
    Camera mainCamera;

    float touchesPrevPosDifference, touchesCurPosDifference, ZoomModifier;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;
    [SerializeField] float zoomModifierSpeed = 0.1f;
    [SerializeField] float maxZoomSize;
    [SerializeField] float minZoonSize;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera= GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount==2)
        {
            Debug.Log("2 fingers");
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
            secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

            touchesPrevPosDifference = (firstTouchPrevPos- secondTouchPrevPos).magnitude;
            touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

            ZoomModifier = (firstTouch.deltaPosition- secondTouch.deltaPosition).magnitude * zoomModifierSpeed; 

            if(touchesPrevPosDifference> touchesCurPosDifference)
            {

                mainCamera.orthographicSize += ZoomModifier;

            }
            if (touchesPrevPosDifference < touchesCurPosDifference)
            {

                mainCamera.orthographicSize -= ZoomModifier;

            }
        }

        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoonSize, maxZoomSize);
    }
}
