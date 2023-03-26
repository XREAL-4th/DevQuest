using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Information : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text[] ClockText;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = (GameManager.instance.GameScore).ToString();
        timer = GameManager.instance.GameTime;

        ClockText[0].text = (((int)timer / 60 % 60)).ToString();
        ClockText[1].text = ((int)timer % 60).ToString("D2");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

