using System.Xml.Serialization;
using UnityEngine;

public class ShootControl : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] public Camera PlayerCam;
    [SerializeField] GameObject HitEffect;

    [Header("Settings")]
    [SerializeField][Range(15f, 50f)] private float damage = 25.0f;
    [SerializeField] private float range = 100.0f;

    void Update()
    {
        //+--- [0320]필수과제2 ---+//
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    // Raycasting(Hitscan 방식)
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }
            GameObject effect = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effect, 1.0f);
        }
    }
}
