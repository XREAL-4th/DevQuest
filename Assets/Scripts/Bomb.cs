using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float damage = 20.0f;

    private void OnCollisionEnter(Collision other)
    {
        Enemy target = other.gameObject.GetComponent<Enemy>();
        if (target != null)
        {
            target.TakeDamage(damage);
            // VFX
            GameObject vfxPrefab = Resources.Load<GameObject>("Prefabs/Stones hit");
            GameObject effect = Instantiate(vfxPrefab, other.transform.position, other.transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this);
        }
    }
}
