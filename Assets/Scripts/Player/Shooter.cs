using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    GameObject bullet;

    private void Update()
    {
        if (Input.GetMouseButton(0)) Shoot();
    }

    public void Shoot()
    {
        Bullet bullet = BulletPool.Instance.bulletPool.Get();
        bullet.Init(gameObject);
        bullet.transform.position = new(bullet.transform.position.x, bullet.transform.position.y + 1, bullet.transform.position.z);
    }
}