using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public class Gun : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] GameObject ShootEffect;
    public GameObject muzzle;
    public LineRenderer lineRenderer;
    private bool isGrabbed;

    [Header("Settings")]
    [Range(15f, 50f)] public float damage = 25.0f;
    [SerializeField] private float range = 100.0f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        isGrabbed = false;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.forward, out hit, range))
        {
            if (hit.collider && isGrabbed)
            {
                Vector3 endPosition = hit.point;
                lineRenderer.SetPosition(0, muzzle.transform.position);
                lineRenderer.SetPosition(1, endPosition);
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }

            if (OVRInput.GetDown(OVRInput.Button.One) && isGrabbed)
            {
                Enemy target = hit.transform.GetComponent<Enemy>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                // VFX
                GameObject effect = Instantiate(ShootEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect, 1.0f);
            }
        }
    }

    public void isGrabbedTrue()
    {
        isGrabbed = true;
    }

    public void isGrabbedFalse()
    {
        isGrabbed = false;
    }
}
