using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject firePos;  //총알 생성 위치
    public GameObject PrefabBullet;
    //public float force = 5;

    private Ray ray;

    private RaycastHit hit;

    private Vector3 movePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //마우스 커서 좌표 받아오기
        //if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 100.0f, 1 << 8))
        if (Input.GetMouseButtonDown(0))
        {
            movePos = hit.point;
            //Debug.Log(movePos);
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(PrefabBullet);    //프리팹 총알 생성
        bullet.transform.position = firePos.transform.position;
        Rigidbody bulletRigid = bullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = firePos.transform.forward * 50;  //속도
        //bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * force);
    }
}
