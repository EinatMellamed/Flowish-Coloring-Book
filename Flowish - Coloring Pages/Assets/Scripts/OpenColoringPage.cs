using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class OpenColoringPage : MonoBehaviour
{
    [SerializeField] GameObject currentColoringPage;
    public void OpenCurrentColoringPage()
    {
        currentColoringPage.SetActive(true);
    }
}
