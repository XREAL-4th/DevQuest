using System.Collections;
using UnityEngine;

using Assets.Scripts.Utils.Singletons;
using UnityEngine.Pool;
using Unity.VisualScripting;

public class BulletPool : SingletonMonoBehaviour<BulletPool>
{
    [SerializeField] private GameObject dummyBulletPref;
    [DoNotSerialize] public ObjectPool<Bullet> bulletPool;

    protected override void Awake()
    {
        base.Awake();
        bulletPool = new(
            () => Instantiate(dummyBulletPref).GetComponent<Bullet>(),
            bullet => bullet.gameObject.SetActive(true),
            bullet => bullet.gameObject.SetActive(false),
            bullet => Destroy(bullet.gameObject)
        );
    }
}
