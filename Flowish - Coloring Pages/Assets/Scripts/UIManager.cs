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
    [SerializeField] GameObject currentColoringPage;

    // Start is called before the first frame update
    void Start()
    {

        CloseColorPanels();
        UI[4].SetActive(true);
        DisableDrawing();
    }

    public void OpenColorPalletePanel()
    {
        CloseAllUI();
        UI[1].SetActive(true);

    }
    public void OpenColorTablePanel()
    {
        CloseAllUI();
        UI[2].SetActive(true);
    }
    public void CloseAllUI()
    {

        foreach (GameObject ui in UI)
        {

            ui.SetActive(false);
        }

    }
    public void CloseColorPanels()
    {
        EnableDrawing();
        CloseAllUI();
        UI[0].SetActive(true);

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
        brush.SetActive(false);
        eraser.SetActive(false);

    }
    public void EnableDrawing()
    {
        brush.SetActive(true);
        eraser.SetActive(true);
    }

    public void OpenBrushOptionsPanel()
    {
        DisableDrawing();
        CloseAllUI();
        UI[3].SetActive(true);

    }

    public void OpenMainMenu()
    {
        DisableDrawing();
        CloseAllUI();
        UI[5].SetActive(true);
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



}
