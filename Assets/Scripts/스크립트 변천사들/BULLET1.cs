//안쓰는 스크립트 입니다.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET1 : MonoBehaviour
{
 public float speed;
 public GameObject Hitvfx;
 //public GameObject Bullet;

 void Start()
 {
   //Invoke("DestroyBullet", 2);
 }



 void Update()

 {
   if ( Input.GetMouseButtonDown (0))
   {
      RaycastHit hit;

      Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
      
      if (Physics.Raycast(ray,out hit, Mathf.Infinity))
      {
        
        Instantiate(Hitvfx,hit.point, Quaternion.identity);

      }
   }
 }

 void DestroyBullet()
 {
    //Destroy(Bullet);
 }
}
