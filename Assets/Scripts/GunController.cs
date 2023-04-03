using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{

    public Gun newGun;

    // Use this for initialization
    void Start()
    {
        newGun.BulletMax = 30;
        newGun.BulletNow = 30;
        newGun.BetweenShots = 800f;
        newGun.ReloadTime = 2f;
        newGun.muzzleVelocity = 20f;
        newGun.ReloadValue = false;
    }

    void Update()
    {
        if (newGun.ReloadValue == true && Time.time >= newGun.nextReloadTime)
        {
            newGun.ReloadValue = false;
            newGun.BulletNow = newGun.BulletMax;

            Debug.Log("RELOAD GUN!");
        }
    }

    public void Shoot()
    {
        newGun.Shoot();
    }

    public void Reload()
    {
        newGun.Reload();
    }

    public void MagicShoot()
    {
        newGun.MagicShoot();
    }
}