using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        shadowImage.color = Color.HSVToRGB(H, S * 0.8f, V);
        backImage.color = new Color(11, 11, 11);
    }

    private void Update()
    {
        frontImage.rectTransform.SetLeft(-progress * rect.sizeDelta.x);

        Timer.Instance.SetTimeout(1, () => shadowImage.rectTransform.SetLeft(-progress * rect.sizeDelta.x));
    }
}
