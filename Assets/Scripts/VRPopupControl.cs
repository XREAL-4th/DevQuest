using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPopupControl : MonoBehaviour
{
    public GameObject VRpopup;

    void Start()
    {
        VRpopup.SetActive(false);
    }
}
