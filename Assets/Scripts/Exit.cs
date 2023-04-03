using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject PopUp;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNo()
    {
        PopUpManager.PopUpOn = false;
        PopUp.SetActive(false);
    }

    public void OnClickYes()
    {
        Application.Quit();
    }
}
