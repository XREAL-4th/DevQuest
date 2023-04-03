using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletType", menuName = "Bullets/BulletType", order = 1)]
public class BulletType : ScriptableObject
{
    public GameObject hitEffect, despawnEffect;
    public float lifetime = 1, bulletSpeed = 30, damage = 10, radius = 0.5f;
}
