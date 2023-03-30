using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public Transform bulletPosition;
    public GameObject prefabBullet;
    Vector3 direction;
    public int damage = 20;
    public Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Shot();
        direction -= cam.transform.position;
    }
    void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(prefabBullet, bulletPosition.position, bulletPosition.rotation);
            Rigidbody bulletRigid = bullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = bulletPosition.forward * 50;      
        }
    }
}


