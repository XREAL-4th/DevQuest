using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Preset")]
    public Transform outTransform;

    [Header("Setting")]
    [SerializeField] private GameObject currentBulletPref;
    [SerializeField] private BulletType currentBulletType;
    public float damagetMultiplier = 1;
    public float recoilAmount = 10f, recoilDownAmount = 30f; //TODO: make SO

    [Header("Debug")]
    [SerializeField] private float recoil = 0f;

    public void Shoot()
    {
        Bullet bullet = BulletPoolManager.Main.Get<Bullet, BulletType>(currentBulletType);
        bullet.parent = this;
        bullet.direction = outTransform.right;
        bullet.transform.position = outTransform.position;
        bullet.stateTime = 0;
        recoil += recoilAmount;
    }

    private void Update()
    {
        if (recoil > 0f) recoil -= Time.deltaTime * recoilDownAmount;
        
        transform.localRotation = Quaternion.Euler(new(0, -90, recoil));
    }
}
