using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    Vector3 pos;
    Vector3 dir;
    GameObject player;
    GameObject bullet;
    float force = 1;

    void Start()
    {
        player = GameObject.Find("Player");
        bullet = GameObject.Find("Bullet");
    }

    void Update()
    {
        // 마우스 좌클릭 시 목표 위치로 발사
        if (Input.GetMouseButtonDown(0)) {
            pos = Input.mousePosition;
            pos.z = GetComponent<Camera>().farClipPlane;
            dir = GetComponent<Camera>().ScreenToWorldPoint(pos);
            bullet = Instantiate(bullet, player.transform.position, player.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
