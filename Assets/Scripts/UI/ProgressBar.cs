using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ProgressBar : MonoBehaviour
{
    [Header("Presets")]
    [SerializeField] private RectTransform rect;
    [SerializeField] private Image frontImage, shadowImage, backImage;

    [Header("Config")]
    public Color color;
    
    [Header("Inspect")]
    [Range(0,1)] public float progress = 1;


    private void Awake()
    {
        frontImage.color = color;
        Color.RGBToHSV(color, out float H, out float S, out float V);
        shadowImage.color = Color.HSVToRGB(H, S * 0.5f, V);
        backImage.color = new Color(125, 125, 125);
    }

    private void Update()
    {
       
        frontImage.fillAmount = Mathf.Lerp(frontImage.fillAmount, progress, Time.deltaTime * 5);
        shadowImage.fillAmount = Mathf.Lerp(shadowImage.fillAmount, progress, Time.deltaTime * 2);
    }
}
