using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{

    [SerializeField] List<GameObject> UI;
    [SerializeField] List<GameObject> ColoringPagesPanels;
    [SerializeField] GameObject draw;
    [SerializeField] GameObject brush, eraser;
    [SerializeField] GameObject book;
    
    //[SerializeField] GameObject currentColoringPage;

    // Start is called before the first frame update
    void Start()
    {
        CloseAllUI();
       
        UI[4].SetActive(true);
        DisableDrawing();
    }

    public void OpenColorPalletePanel()
    {
       
        UI[1].SetActive(true);
        UI[2].SetActive(false);

    }
    public void OpenColorTablePanel()
    {
      
        UI[2].SetActive(true);
        UI[1].SetActive(false);
    }
    public void CloseAllUI()
    {

        foreach (GameObject ui in UI)
        {

            ui.SetActive(false);
        }

    }
    public void CloseColorAndBrushPanels()
    {

        UI[3].SetActive(false);
        UI[2].SetActive(false);
        UI[1].SetActive(false);
       


    }
    public void OpenColorOptions()
    {
        EnableDrawing();
        UI[0].SetActive(true);
        UI[5].SetActive(false);
      
      
    }
    public void UseEraser()
    {

        draw.GetComponent<Drawing>().brushCount = 1;
        Debug.Log("erase");
    }
    public void UseColor()
    {

        draw.GetComponent<Drawing>().brushCount = 0;
    }
    public void DisableDrawing()
    {
        draw.SetActive(false);
        brush.SetActive(false);
        eraser.SetActive(false);

    }
    public void EnableDrawing()
    {
        draw.SetActive(true);
        brush.SetActive(true);
        eraser.SetActive(true);
    }

    public void OpenBrushOptionsPanel()
    {
        
       
        UI[3].SetActive(true);

    }

    public void OpenBook()
    {
        DisableDrawing();
        CloseAllUI();
        UI[5].SetActive(true);
        book.SetActive(true);
       
       
    }
    public void CloseAllColoringPages()
    {
        foreach (GameObject coloringPage in ColoringPagesPanels)
        {
            coloringPage.SetActive(false);
            //save changes players prefs
        }
    }
    public void OpenColoringPage()
    {
        CloseAllUI();
        UI[0].SetActive(true);
        CloseAllColoringPages();

        EnableDrawing();


    }
    public void CloseButtonsPanel()
    {

        UI[0].SetActive(false);
        UI[5].SetActive(true);
       

    }

    
}
