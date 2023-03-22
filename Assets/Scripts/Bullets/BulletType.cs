using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletType", menuName = "Bullets/BulletType", order = 1)]
public class BulletType : ScriptableObject
{
    public GameObject hitEffect, despawnEffect;
    public float lifetime = 5, bulletSpeed = 30;
}
