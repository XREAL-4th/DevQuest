using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject preFabBullet;
    public bool canShoot = false;

    public static Camera cam; // 메인카메라

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if(Input.GetMouseButtonDown(0)){

            Ray ray = cam.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                GameObject bullet = Instantiate(preFabBullet, new Vector3(0f, 0f, 0f), Quaternion.identity);
                bullet.transform.position = hit.point;
                // print(bullet.layer);
                Destroy(bullet, 0.3f);
            }
        }
    }
}
