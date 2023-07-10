using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public GameObject frontImage;
    public GameObject frontUserInput;
    public GameObject backImage;
    public GameObject backUserInput;
   
    public GameObject canvas;


    private bool isFrontSide = true;



    public void FlipPage()
    {
        isFrontSide = !isFrontSide;

        // Activate/deactivate images based on side
        if (isFrontSide)
        {
            frontImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, -180, 0);
            frontUserInput.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, -180, 0);
            Invoke("FlipForwardDetails", 0.3f);
            canvas.GetComponent<UIManager>().DisableDrawing();

        }
        else
        {

            Invoke("FlipBackDetails", 0.3f);


        }
    }

    private void FlipForwardDetails()
    {
        frontImage.SetActive(true);
        frontUserInput.SetActive(true);
       
        backImage.SetActive(false);
       backUserInput.SetActive(false);


    }
    private void FlipBackDetails()
    {

        frontImage.SetActive(false);
        frontUserInput.SetActive(false);

        backImage.SetActive(true);
        backUserInput.SetActive(true);
    }
}
