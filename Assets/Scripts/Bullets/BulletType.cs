using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    // GameObject hitEffect, despawnEffect;
    [SerializeField] private float lifetime;
    private float stateTime;
    public Rigidbody rigid;

    protected void OnCollisionEnter(Collision collision) => OnHit(collision);

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        stateTime += Time.deltaTime;
        if (stateTime > lifetime) OnDespawn();
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
