using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Vector2 origin;
    [SerializeField] Vector2 difference;
    [SerializeField] Vector2 resetCamera;

    [SerializeField] private bool drag = false;

    private void Start()
    {
        resetCamera = Camera.main.transform.position;   
    }

    private void LateUpdate()
    {
            if(Input.touchCount ==2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);
            difference = (Camera.main.ScreenToWorldPoint(secondTouch.deltaPosition * Camera.main.transform.position * 0.1f));
            if(drag==false)
            {

                drag = true;
                origin = Camera.main.ScreenToWorldPoint(secondTouch.deltaPosition);
            }
        }
        else
        {

            drag= false;    

        }

            if(drag)
        {

            Camera.main.transform.position = origin - difference;

        }
       
    }
}
