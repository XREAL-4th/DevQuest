using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeControl : MonoBehaviour
{
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, 6.0f);
        foreach (Collider c in hit) {
            if (c.name.Substring(0, 5) == "Enemy") {
                Destroy(c.gameObject);
                GameManager.instance.score += 3;
            }
        }
    }
}
