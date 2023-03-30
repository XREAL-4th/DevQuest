using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : VariationContentMonoBehaviour, IHasScriptableObject<BulletType>
{
    private BulletType _type;
    public BulletType Type { get => _type; set => _type = value; }

    public float stateTime;
    public Weapon parent;
    public Vector3 direction;


    private void Update()
    {
        if (parent == null) return;

        stateTime += Time.deltaTime;
        if (stateTime > Type.lifetime) OnDespawn();
        else transform.Translate(Time.deltaTime * Type.bulletSpeed * direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && isAlive)
        {
            OnHit(other.gameObject);
        
        }
    }

    public void OnHit(GameObject target)
    {
        Instantiate(Type.hitEffect, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        target.GetComponent<IHealthy>()?.Damage(Type.damage * parent.damagetMultiplier);
        Release();
    }

    public virtual void OnDespawn()
    {
        Instantiate(Type.despawnEffect, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
        Release();
    }
    public void Release()
    {
        BulletPoolManager.Main.Release(this);
        parent = null;
        direction = Vector3.zero;
        stateTime = 0;
    }
}
