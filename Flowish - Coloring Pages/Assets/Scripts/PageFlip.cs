using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public GameObject frontImage;
    public GameObject backImage;
   
    public GameObject canvas;


    private bool isFrontSide = true;



    public void FlipPage()
    {
        isFrontSide = !isFrontSide;

        // Activate/deactivate images based on side
        if (isFrontSide)
        {
            frontImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, -180, 0);
            Invoke("FlipForwardDetails", 0.7f);
            canvas.GetComponent<UIManager>().DisableDrawing();

        }
        else
        {

            Invoke("FlipBackDetails", 0.7f);


        }
    }

    private void FlipForwardDetails()
    {
        frontImage.SetActive(true);

       
        backImage.SetActive(false);


    }
    private void FlipBackDetails()
    {

        frontImage.SetActive(false);
       
        backImage.SetActive(true);

    }
}
