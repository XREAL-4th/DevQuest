using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUp;
    public static bool PopUpOn = false;

    private void Awake()
    {
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExit()
    {
        PopUpOn = true;
        popUp.SetActive(true);
    }
}
