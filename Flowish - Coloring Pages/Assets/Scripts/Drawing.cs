using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Drawing : MonoBehaviour
{

    [SerializeField] Camera camera;
    [SerializeField] GameObject brush;
    [SerializeField] GameObject eraser;
    public int brushCount;
    public LineRenderer currentLineRenderer;
    public List<GameObject> lines = new List<GameObject>();
   

    Vector2 lastPos;
    public Color currentColor;
    public float brushSize;
   
   public SliderScript sizeSliderScript;
    public SliderScript opacitySliderScript;
   
   

    private void Start()
    {
       
        brushCount = 0;
        currentColor = Color.black;
        brushSize = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Coloring();
    }
    void AddPoint(Vector2 pointPos)
    {

        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);

    }
    void PointToMousePos()
    {

        Vector2 mousPos = camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousPos)
        {

            AddPoint(mousPos);
            lastPos = mousPos;

        }
    }
    public void Coloring()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            if (brushCount == 0)
            {

                CreateBrush();
            }
            if (brushCount == 1)
            {

                CreateEraser();
            }




        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {


            PointToMousePos();
        }
        else
        {

            currentLineRenderer = null;

        }
    }


    public void CreateBrush()
    {


        GameObject brushInstance = Instantiate(brush);
        //determained the color of the linerenderer by picking with the mouse a color in a ui image
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        // 2 points are requiered to start a line renderer
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
        lines.Add(brushInstance);
        currentColor.a = opacitySliderScript.value;

        currentLineRenderer.SetColors(currentColor, currentColor);
       

        currentLineRenderer.startWidth = sizeSliderScript.value;

       
      

    }

    public void CreateEraser()
    {


        GameObject brushInstance = Instantiate(eraser);
        //the color of the lineRenderer is the color of the background ( a warm very light beige)
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        // 2 points are requiered to start a line renderer
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
       

    }

 

}

