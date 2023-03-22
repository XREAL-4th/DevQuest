using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{// Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().isKinematic = true;
        //시작과 동시에 물체가 추락하지 않도록 하기 위한 코드

    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetMouseButtonDown(0)) // 마우스 클릭시 발동
        //{
        //   GetComponent<Rigidbody>().isKinematic = false;
        //물체가 여러 물리력을 받도록 허용하는 코드
        //  Shoot();
        // 발사!!
        //   }


    }
    public void Shoot(Vector3 speed)
    {   //Y축으로 200만큼 Z 축으로 2000만큼의 힘으로 발사시키는 함수
        GetComponent<Rigidbody>().AddForce(speed);
    }
}
