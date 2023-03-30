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
    public float recoilAmount = 10f, recoilDownAmount = 30f, reloadTime = 1.5f; //TODO: make SO: ammoPerMaganize, recoilAmount, recoilDownAmount, reloadTime
    public int ammoPerMaganize = 10, ammo = 10, maganizes = 5;

    [Header("Debug")]
    [SerializeField] private float recoil = 0f;
    [SerializeField] private bool isReloading = false;

    public void Shoot()
    {
        if (!IsShootable()) return;

        Bullet bullet = BulletPoolManager.Main.Get<Bullet, BulletType>(currentBulletType);
        bullet.parent = this;
        bullet.direction = outTransform.right;
        bullet.transform.position = outTransform.position;
        bullet.stateTime = 0;
        recoil += recoilAmount;
        ammo--;
    }

    public bool IsShootable() => ammo > 0 && !isReloading;
    public bool IsReloadable() => maganizes > 0 && !isReloading;

    private void Reload()
    {
        isReloading = true;
        ReloadMask.Main.StartReload(reloadTime);
        Timer.Instance.SetTimeout(reloadTime, () =>
        {
            isReloading = false;
            maganizes--;
            ammo = ammoPerMaganize;
        });
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && IsReloadable()) Reload();
        
        if (recoil > 0f) recoil -= Time.deltaTime * recoilDownAmount;
        
        transform.localRotation = Quaternion.Euler(new(0, -90, recoil));
    }
}
