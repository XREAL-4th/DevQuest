using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class VrShoot : MonoBehaviour
{
    //public Camera Cam;
    public Transform shootPoint;
    public GameObject vrBullet;



    [SerializeField] private float _damage = 10.0f;
    //[SerializeField] private Camera Cam;
    [SerializeField] GameObject VrHitVfx;


    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            VRShoot();
        }

    }

    public void VRShoot()
    {
        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out RaycastHit hitInfo))
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(_damage);
            }

            Vector3 dir = hitInfo.point - shootPoint.transform.position;
            GameObject intantBullet = Instantiate(vrBullet, shootPoint.position, shootPoint.rotation); //Instantiate : �̹� ������� ���� ������ �ǽð� ����
            Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = shootPoint.forward * 30; // bulllet �ӵ�

            Destroy(intantBullet, 1.0f);

            GameObject hitVfx = Instantiate(VrHitVfx, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitVfx, 1.0f);

        }
    }



}
