using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //public Camera Cam;
    public Transform bulletPos;
    public GameObject bullet;


    [SerializeField] private float damage = 10.0f;
    [SerializeField] private Camera Cam;
    [SerializeField] GameObject HitVfx;




    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out RaycastHit hitInfo))
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.GetDamage(damage);
            }

            Vector3 dir = hitInfo.point - bulletPos.transform.position;
            GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation); //Instantiate : 이미 만들어진 게임 오브제 실시간 리필
            Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = bulletPos.forward * 30; // bulllet 속도

            Destroy(intantBullet, 1.0f);

            GameObject hitVfx = Instantiate(HitVfx, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitVfx, 1.0f);

        }
    }
}
