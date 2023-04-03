using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text[] ClockText;
    public static float timeleft = 90;
    



    // Update is called once per frame
    void Update()
    {
        if (!PopUpManager.PopUpOn)
        {
            timeleft -= Time.deltaTime;
        }

        if (timeleft <= 0)
        {
            timeleft = 0;
        }

        ClockText[0].text = (((int)timeleft / 60 % 60)).ToString();
        ClockText[1].text = ((int)timeleft % 60).ToString("D2");
    }
}
