using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject currentBulletPref;
    [DoNotSerialize] public ObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new(
            () => Instantiate(currentBulletPref).GetComponent<Bullet>(),
            bullet => bullet.gameObject.SetActive(true),
            bullet => bullet.gameObject.SetActive(false),
            bullet => Destroy(bullet.gameObject)
        );
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) Shoot();
    }

    public void Shoot()
    {
        Bullet bullet = bulletPool.Get();
        bullet.Init(gameObject);
        bullet.transform.position = new(bullet.transform.position.x, bullet.transform.position.y + 1, bullet.transform.position.z);
    }
}