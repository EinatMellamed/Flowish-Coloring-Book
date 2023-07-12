using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorControl : MonoBehaviour
{
    public float currentHue, currentSat, currentVal;
    [SerializeField] RawImage hueImage, satValImage, outputImage;

    [SerializeField] Slider hueSlider;
    [SerializeField] TMP_InputField hexInputField;

    private Texture2D hueTexture, svTexture, outputTexture;


    [SerializeField] MeshRenderer changeThisColor;


    private void Start()
    {
        CreateHueImage();

        CreateSVImage();

        CreateOutputImage();

        UpdateOutputImage();
    }
    public void CreateHueImage()
    {

        hueTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";

        for(int i = 0; i<hueTexture.height; i++)
        {

            hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / hueTexture.height, 1, 0.05f));

        }

        hueTexture.Apply();
        currentHue = 0;
        hueImage.texture = hueTexture;
    }


    public void CreateSVImage() 
    {
        svTexture = new Texture2D(16, 16);
        svTexture.wrapMode = TextureWrapMode.Clamp;
        svTexture.name = "SatValtexture";

        for(int y = 0; y < svTexture.height; y++)
        {

            for (int x = 0; x < svTexture.width; x++)
                svTexture.SetPixel(x, y, Color.HSVToRGB(
                 currentHue,
                 (float)x/svTexture.width,
                 (float)y/svTexture.height));




        }
        svTexture.Apply();
        currentSat = 0; 
        currentVal = 0;

        satValImage.texture = svTexture;


    
    }

    public void CreateOutputImage()
    {
        outputTexture = new Texture2D(1, 16);
        outputTexture.wrapMode = TextureWrapMode.Clamp;
        outputTexture.name = "OutputTexture";

        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for(int i = 0; i< outputTexture.height; i++)
        {


            outputTexture.SetPixel(0,i, currentColor);
        }

        outputTexture.Apply();

        outputImage.texture = outputTexture;    



    }

    public void UpdateOutputImage()
    {

        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {


            outputTexture.SetPixel(0, i, currentColor);
        }
        outputTexture.Apply();

        hexInputField.text = ColorUtility.ToHtmlStringRGB(currentColor);

        changeThisColor.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", currentColor);
    }

    public void SetSV(float S, float V)
    {


        currentSat= S;
        currentVal= V;

        UpdateOutputImage();
    }

    public void UpdateSVImage()
    {

        currentHue = hueSlider.value;
        for (int y = 0; y < svTexture.height; y++)
        {

            for (int x = 0; x < svTexture.width; x++)
                svTexture.SetPixel(x, y, Color.HSVToRGB(
                 currentHue,
                 Mathf.InverseLerp(0, svTexture.width,x),
               Mathf.InverseLerp(0, svTexture.height,y)));




        }
        svTexture.Apply();

        UpdateOutputImage();
    }


    public void OnTextInput()
    {

        if(hexInputField.text.Length<6) { return; }

        Color newCol;

        if(ColorUtility.TryParseHtmlString("#" + hexInputField.text, out newCol))
            Color.RGBToHSV(newCol, out currentHue, out currentSat, out currentVal);

        hueSlider.value = currentHue;

        hexInputField.text = "";

        UpdateOutputImage();
    }
}
