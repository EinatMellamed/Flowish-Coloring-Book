using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ColorPicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Color currentOutput;
    [SerializeField] GameObject draw;
    [SerializeField] GameObject otherPallet;

    [SerializeField] GameObject previousColorImage1;
    [SerializeField] GameObject NewColorImage1;
    [SerializeField] GameObject previousColorImage2;
    [SerializeField] GameObject NewColorImage2;

    void Start()
    {
        previousColorImage1.GetComponent<Image>().color =Color.black;
        previousColorImage2.GetComponent<Image>().color =Color.black;
        NewColorImage1.GetComponent<Image>().color = Color.white;
        NewColorImage2.GetComponent<Image>().color = Color.white;

    }
    public Color ColorPick(Vector2 screenPiont, Image imageTtoPick)
    {

        Vector2 point;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageTtoPick.rectTransform, screenPiont, Camera.main, out point);
        point += imageTtoPick.rectTransform.sizeDelta / 2;
        Texture2D t = GetComponent<Image>().sprite.texture;
        Vector2Int m_point = new Vector2Int((int)((t.width * point.x) / imageTtoPick.rectTransform.sizeDelta.x), (int)((t.height * point.y) / imageTtoPick.rectTransform.sizeDelta.y));
        return t.GetPixel(m_point.x, m_point.y);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        currentOutput = ColorPick(Camera.main.WorldToScreenPoint(eventData.position), GetComponent<Image>());
        draw.GetComponent<Drawing>().currentColor = currentOutput;
      NewColorImage1.GetComponent<Image>().color = currentOutput;
      NewColorImage2.GetComponent<Image>().color = currentOutput;
      
    }
  
    public void UpdateNewColorImage()
    {

        previousColorImage1.GetComponent<Image>().color = currentOutput;
        previousColorImage2.GetComponent<Image>().color = currentOutput;


    }
}

