using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Silder class ����ϱ� ���� �߰��մϴ�.

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

