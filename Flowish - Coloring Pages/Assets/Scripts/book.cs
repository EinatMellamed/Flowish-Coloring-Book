using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;


public class book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
   

    [SerializeField] GameObject backButton, forwardButton;
    private void Start()
    {
        InitialState();
        
    }

    public void InitialState()
    {

        for(int i = 0; i < pages.Count; i++)
        {

            pages[i].transform.rotation= Quaternion.identity;
            pages[i].GetComponent<PageFlip>().FlipPage();
        }
        pages[0].SetAsLastSibling();
        backButton.SetActive(false);
       
    }
    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180f;
        ForwardButtonActions();
        pages[index].SetAsLastSibling();
        
        StartCoroutine(Rotate(angle, true));

        
            pages[index].GetComponent<PageFlip>().FlipPage();
       
           
       
       


    }


    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {

            backButton.SetActive(true);

        }
        if (index == pages.Count - 1)
        {
            forwardButton.SetActive(false);

        }


    }
   public void RotateBack()
    {

        if (rotate == true) { return; }
        float angle = 0;
        pages[index].SetAsLastSibling();
       
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));



        
            pages[index].GetComponent<PageFlip>().FlipPage();
       

    }

    public void BackButtonActions()
    {

        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true);

        }
        if (index - 1 == -1)
        {

            backButton.SetActive(false);


        }

    }
    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while(true)
        {
            rotate = true;
            Quaternion targetRotatoion = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotatoion, value);
           
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotatoion);
            
            if (angle1< 0.1f)
            {

                if(forward== false)
                {

                    index--;

                }
                rotate= false;
                break;
            }
            
            yield return null;
        }

    }

    
}
