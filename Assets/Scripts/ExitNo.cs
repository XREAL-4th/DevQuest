using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNo : MonoBehaviour
{
    public GameObject Popup;
    public void click()
    {
        Popup.SetActive(false);
        ExitBtnClick.IsPause = false;
        Cursor.visible = false;
    }

}
