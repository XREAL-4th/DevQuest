using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject currentBulletPref;
    public ObjectPool<Bullet> bulletPool;
    public float shootDelay = 3, damagetMultiplier = 1;
    private float stateTime = 0;

    private void Awake()
    {
        bulletPool = new(
            () => Instantiate(currentBulletPref, transform.position + new Vector3(0, 1, 0), Quaternion.identity).GetComponent<Bullet>(),
            bullet => bullet.gameObject.SetActive(true),
            bullet => bullet.gameObject.SetActive(false),
            bullet => Destroy(bullet.gameObject)
        );
    }
    private void Update()
    {
        stateTime += Time.deltaTime;
        if (stateTime > shootDelay)
        {
            stateTime = 0;
            if (Input.GetMouseButton(0)) Shoot();
        }
    }

    public void Shoot()
    {
        bulletPool.Get().Init(this);
    }
}
