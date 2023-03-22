using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Fire : MonoBehaviour {
 
    public GameObject Bullet;
    public Transform FirePos;

    
 
    // 마우스 좌클릭 입력을 받아 FirePos에 bulletclone을 생성한 후 일정 시간이 지난 후 파괴
    void Update () {
        if (Input.GetMouseButtonDown (0))
        {
            GameObject bulletclone = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            Destroy(bulletclone,1.5f);
            
        }
    }
}