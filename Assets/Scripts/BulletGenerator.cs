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
            GameObject bullet = Instantiate(BulletPrefeb) as GameObject;
            bullet.transform.position = player.transform.position;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ray class
            Vector3 shooting = ray.direction; // 방향 구하기
            shooting = shooting.normalized * 2000; // 발사하는 힘 설정
            bullet.GetComponent<BulletController>().Shoot(shooting);
        }
    }
}
