using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : SingletonMonoBehaviour<Aim>
{
    public Sprite strenthSprite, originSprite;
    public GameObject speedImage;
    public Image image;

    protected override void Awake()
    {
        base.Awake();
        image = GetComponent<Image>();
        originSprite = image.sprite;
    }
}
