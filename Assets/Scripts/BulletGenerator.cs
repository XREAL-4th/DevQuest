using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject BulletPrefeb;
    public GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            Vector3 shooting = ray.direction; 
            shooting = shooting.normalized;

            GameObject bullet = Instantiate(BulletPrefeb) as GameObject;
            bullet.transform.position = Camera.main.transform.position + shooting;
            bullet.GetComponent<BulletController>().Shoot(shooting*2000);

            Destroy(bullet, 3f);
        }
    }
}