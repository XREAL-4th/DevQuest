using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class debudd : MonoBehaviour
{
    private RaycastHit hitInfo;
    private Collider[] colliders;
    void Update()
    {
        /*
        colliders = Physics.OverlapSphere(transform.position, 1f, 1 << 9);
        Debug.Log($"{colliders != null}");
        foreach (var c in colliders)
        {
            if (c.gameObject.layer == 1<<9)
            {
                Debug.Log("yes");
            }
            //Debug.Log(c.gameObject.layer);
            //Debug.Log(c.gameObject.name);
        }
        */
        Debug.Log(Physics.SphereCast(transform.position, 1f, Vector3.up,
            out hitInfo,0f));
        Debug.Log($"hitInfo.layermask : {hitInfo.transform.gameObject.layer}");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
