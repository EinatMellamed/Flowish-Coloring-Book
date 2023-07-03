using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{

    [SerializeField] Slider slider; 
  
    [SerializeField] TextMeshProUGUI sliderText;

    [SerializeField] GameObject draw;

    public float value;

  

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1f;
        slider.onValueChanged.AddListener((v) =>
        {
            sliderText.text = v.ToString("0.00");
            value = v;
            draw.GetComponent<Drawing>().currentColor.a = v;
            draw.GetComponent<Drawing>().brushSize= v;
           
        });
        sliderText.text = slider.value.ToString();
        draw.GetComponent<Drawing>().currentColor.a = slider.value;
        draw.GetComponent<Drawing>().brushSize = slider.value;
       
    }

   
}
