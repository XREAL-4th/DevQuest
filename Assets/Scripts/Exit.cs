using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static Exit instance;

    public GameObject PopUp;

    private void Start()
    {
        instance = this;
    }

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
