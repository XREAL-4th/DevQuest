using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Silder class 사용하기 위해 추가합니다.

public class TestSlider : MonoBehaviour
{
    Slider slHP;
    float fSliderBarTime;
    void Start()
    {
        slHP = GetComponent<Slider>();
    }


    void Update()
    {
        if (slHP.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}

