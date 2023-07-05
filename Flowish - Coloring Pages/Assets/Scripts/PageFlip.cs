using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public GameObject frontImage;
    public GameObject backImage;


    private bool isFrontSide = true;

    // Other variables and methods...

    public void FlipPage()
    {
        isFrontSide = !isFrontSide;
      
        // Activate/deactivate images based on side
        if (isFrontSide)
        {
            frontImage.SetActive(true);
            frontImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, -180, 0);

            backImage.SetActive(false);
        }
        else
        {
            frontImage.SetActive(false);

            backImage.SetActive(true);


        }

        // Perform flipping animation and logic...
    }
}
