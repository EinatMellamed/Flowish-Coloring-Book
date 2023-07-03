using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OpenColoringPage : MonoBehaviour
{

    [SerializeField] GameObject currentColoringPage;
  
   async public void OpenCurrentColoringPage()
    {

        await Task.Delay(10);
        currentColoringPage.SetActive(true);
    }
}
