using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PageFlip : MonoBehaviour
{
    public GameObject frontImage;
    public GameObject backImage;
    public GameObject purchaseButton;
    public GameObject canvas;


    private bool isFrontSide = true;
    public void Start()
    {
        purchaseButton.SetActive(true);
    }
    // Other variables and methods...

    public void FlipPage()
    {
     
        
            isFrontSide = !isFrontSide;


      

        // Activate/deactivate images based on side
        if (isFrontSide)
        {
           
            frontImage.SetActive(true);
            frontImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, -180, 0);
            purchaseButton.SetActive(false);
            backImage.SetActive(false);
            canvas.GetComponent<UIManager>().DisableDrawing();

        }
        else
        {
            
            frontImage.SetActive(false);
            purchaseButton.SetActive(true);
            backImage.SetActive(true);
           

        }

        // Perform flipping animation and logic...
    }
}
