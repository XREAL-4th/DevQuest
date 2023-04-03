using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtnClick: MonoBehaviour
{

    public static bool IsPause = false;
    public GameObject Popup;

    public void BtnClick()
    {
        IsPause = true;
        Popup.SetActive(true);
        
    }
}
