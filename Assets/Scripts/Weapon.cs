using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public GameObject bulletPosition;
    public GameObject prefabBullet;
    float bulletSpeed = 5;
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
        direction = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.transform.position.z));
    }
    void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(prefabBullet);
            bullet.transform.position = bulletPosition.transform.position;
            bullet.gameObject.GetComponent<Rigidbody>().AddForce(direction * bulletSpeed, ForceMode.Impulse);
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit rayHit;
            //if (Physics.Raycast(ray, out rayHit, 100))
            //{
            //    Vector3 nextVector = rayHit.point - transform.position;
            //    nextVector.y = 0;
            //    transform.LookAt(transform.position + nextVector);
            //}
        }
    }
}


