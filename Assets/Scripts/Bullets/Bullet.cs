using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Preset Fields")]
    public BulletType type;

    private float stateTime;
    private Shooter parent;
    private Vector3 direction;


    private void Update()
    {
        if (parent == null) return;

        stateTime += Time.deltaTime;
        if (stateTime > type.lifetime) OnDespawn();
        else transform.Translate(Time.deltaTime * type.bulletSpeed * direction);
    }

    public virtual Bullet Init(Shooter parent)
    {
        this.parent = parent;
        direction = parent.transform.forward;
        stateTime = 0;
        transform.position = parent.transform.position + new Vector3(0, 1, 0);
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Instantiate(type.hitEffect, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
            other.GetComponent<IHealthy>()?.Damage(type.damage);
            Release();
        }
    }

    public virtual void OnDespawn()
    {
        Instantiate(type.despawnEffect, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        Release();
    }
    public void Release()
    {
        parent.bulletPool.Release(this);
        parent = null;
        direction = Vector3.zero;
        stateTime = 0;
    }
}
