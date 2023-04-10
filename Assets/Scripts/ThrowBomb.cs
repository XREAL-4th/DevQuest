using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    [Header("Preset Fields")]
    public GameObject shotPoint;
    public GameObject Bomb;
    public LineRenderer lineRenderer;
    private bool isGrabbed;

    [Header("Settings")]
    [Range(15f, 50f)] public float damage = 35.0f;
    [SerializeField] private float range = 100.0f;

    void Start()
    {
        lineRenderer= GetComponent<LineRenderer>();
        isGrabbed = false;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
        {
            if (hit.collider && isGrabbed)
            {
                Vector3 endPosition = hit.point;
                lineRenderer.SetPosition(0, this.transform.position);
                lineRenderer.SetPosition(1, endPosition);
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
            }

            if (OVRInput.GetDown(OVRInput.Button.One) && isGrabbed)
            {
                // 발사체(총구 ~target)
                Vector3 dir = hit.point - this.transform.position;
                GameObject bulletClone = Instantiate(Bomb, shotPoint.transform.position, shotPoint.transform.rotation);
                bulletClone.GetComponent<Rigidbody>().velocity = dir.normalized * 15.0f;
                Destroy(bulletClone, 2.0f);
            }
        }

    }

    // public이어야 Inspector창에서 가져올 수 있음.
    public void isGrabbedTrue()
    {
        isGrabbed = true;
    }

    public void isGrabbedFalse()
    {
        isGrabbed = false;
    }
}
