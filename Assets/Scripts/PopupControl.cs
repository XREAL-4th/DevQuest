using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
    public GameObject popup;

    void Start()
    {
        popup.SetActive(false);
    }
}
