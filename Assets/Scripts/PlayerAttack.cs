using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject firePos;  //총알 생성 위치
    public GameObject PrefabBullet;
    //총알 속도
    private float force = 5;
    
    Vector3 dir;
    private Vector3 ScreenCenter;


    void Update()
    {
        //마우스 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            //CameraControl에서 커서가 정중앙에 고정된 상태
            Vector3 mos = Input.mousePosition;
            mos.z = Camera.main.farClipPlane; //카메라가 보는 방향과 시야에 z값 맞추기
            //마우스 지점 좌표 받아오기
            dir = Camera.main.ScreenToWorldPoint(mos);

            //Q1.왜 이 코드에서는 objPosition 값이 거의 고정되어서 나오는지 -> z값 때문인가요???
            //float distance = Camera.main.WorldToScreenPoint(transform.position).z;
            //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            //objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(PrefabBullet);    //프리팹 총알 생성
        bullet.transform.position = firePos.transform.position;
        //Q2. 총알이 마우스 커서랑 살짝 어긋나게 발사되는데 아래 코드를 수정해서 개선할 수 있을까요 ???
        bullet.GetComponent<Rigidbody>().AddForce(dir * force);
    }
}
