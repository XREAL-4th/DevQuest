using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Pool;


public class Weapon : MonoBehaviour
{
    [Header("Preset")]
    public Transform outTransform;

    [Header("Setting")]
    [SerializeField] private GameObject currentBulletPref;
    [SerializeField] private BulletType currentBulletType;
    public WeaponType type;

    [Header("Debug")]
    [SerializeField] private float recoil = 0f;
    [SerializeField] private bool isReloading = false;
    public float damagetMultiplier = 1;
    public int ammo = 10, maganizes = 5;
    public float shootTime = 0;

    public void Shoot()
    {
        if (!IsShootable() || shootTime > 0) return;

        Bullet bullet = BulletPoolManager.Main.Get<Bullet, BulletType>(currentBulletType);
        bullet.parent = this;
        bullet.direction = outTransform.right;
        bullet.transform.position = outTransform.position;
        bullet.stateTime = 0;

        shootTime = type.shootDelay;
        recoil += type.recoilAmount;
        ammo--;
    }

    public bool IsShootable() => ammo > 0 && !isReloading;
    public bool IsReloadable() => maganizes > 0 && !isReloading;
    public BulletType GetBulletType() => currentBulletType;

    private void Reload()
    {
        isReloading = true;
        ReloadMask.Main.StartReload(type.reloadTime);
        Timer.Main.SetTimeout(type.reloadTime, () =>
        {
            isReloading = false;
            maganizes--;
            ammo = type.ammoPerMaganize;
        });
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && IsReloadable()) Reload();
        
        if (recoil > 0) recoil -= Time.deltaTime * type.recoilDownAmount;
        if (shootTime > 0) shootTime -= Time.deltaTime;

        transform.localRotation = Quaternion.Euler(new(0, -90, recoil));
    }
}
