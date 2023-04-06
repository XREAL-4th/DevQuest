using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject firePos;  //총알 생성 위치
    public GameObject PrefabBullet;
    //총알 속도
    private float force = 5;
    public int damage = 5;
    
    Vector3 dir;
    private Vector3 ScreenCenter;


    void Update()
    {
        ////마우스 클릭 시
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        //    ScreenCenter.z = Camera.main.farClipPlane; //카메라가 보는 방향과 시야에 z값 맞추기
        //    //에임 좌표 받아오기
        //    dir = Camera.main.ScreenToWorldPoint(ScreenCenter);
        //    Shoot();
        //}
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(PrefabBullet);    //프리팹 총알 생성
        bullet.GetComponent<Bullet>().damage = this.damage;
        bullet.transform.position = firePos.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(dir * force);
    }
}
