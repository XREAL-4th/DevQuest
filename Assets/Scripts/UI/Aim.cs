using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : SingletonMonoBehaviour<Aim>
{
    [Header("Presets")]
    public Image image;
    public GameObject speedImage;
    public Sprite strenthSprite, originSprite;
}
