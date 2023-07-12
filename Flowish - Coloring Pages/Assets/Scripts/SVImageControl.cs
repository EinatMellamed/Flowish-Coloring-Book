using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class SVImageControl : MonoBehaviour , IDragHandler, IPointerClickHandler
{

    [SerializeField] Image PickerImage;

    private RawImage SVImage;

    private ColorControl cc;
    private RectTransform rectTransform, pickerTransform;

  
    private void Awake()
    {
        SVImage = GetComponent<RawImage>();
        cc = FindObjectOfType<ColorControl>();
        RectTransform recTransform = GetComponent<RectTransform>();

        pickerTransform = PickerImage.GetComponent<RectTransform>();
        pickerTransform.position = new Vector2(-(recTransform.sizeDelta.x * 0.5f), -(recTransform.sizeDelta.y * 0.5f));
    } 

    private void UpdateColor(PointerEventData eventData)
    {

        Vector3 pos = rectTransform.InverseTransformPoint(eventData.position);

        float deltaX = rectTransform.sizeDelta.x * 0.5f;
        float deltaY = rectTransform.sizeDelta.y * 0.5f;

        if(pos.x<-deltaX)
        {

            pos.x = -deltaX;
        }
        else if (pos.x > deltaX)
        {
            pos.x = deltaX;

        }
        if(pos.y<deltaY)
        {

            pos.y = deltaY;
        }
        float x = pos.z + deltaX;
        float y = pos.z + deltaX;

        float xNorm = x / rectTransform.sizeDelta.x;
        float yNorm = y / rectTransform.sizeDelta.y;

        pickerTransform.localPosition = pos;
        PickerImage.color = Color.HSVToRGB(0, 0, 1 - yNorm);

        cc.SetSV(xNorm, yNorm);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColor(eventData );
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

}
