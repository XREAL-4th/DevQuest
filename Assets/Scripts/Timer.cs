using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text[] ClockText;
    float time = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
        }

        ClockText[0].text = (((int)time / 60 % 60)).ToString();
        ClockText[1].text = ((int)time % 60).ToString("D2");
    }
}
