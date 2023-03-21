using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Preset Fields")]
    public BulletType type;
    public Rigidbody rigid;
    private float stateTime;

    protected void OnCollisionEnter(Collision collision) => OnHit(collision);

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        stateTime += Time.deltaTime;
        if (stateTime > type.lifetime) OnDespawn();
    }

    public virtual void Init(GameObject parent) {
        transform.position = parent.transform.position;
    }
    public virtual void OnHit(Collision collision) => Release();
    public virtual void OnDespawn() => Release();
    public void Release()
    {
        BulletPool.Instance.bulletPool.Release(this);
    }
}
