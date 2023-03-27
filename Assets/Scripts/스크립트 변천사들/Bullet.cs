//안쓰는 스크립트 입니다

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
    public class Bullett : MonoBehaviour {
 
    public GameObject Bullet;
    public Transform FirePos;
    public float speed;
    public GameObject Hitvfx;
 
    void Update () 
    {
        if (Input.GetMouseButtonDown (0))
        {
            //복제한다. //'Bullet'을 'FirePos.transform.position' 위치에 'FirePos.transform.rotation' 회전값으로.
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }

       

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
}

public class Bullet : MonoBehaviour {
 
    void Update () {
        //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의 힘만큼 날아가라
        transform.Translate(Vector3.forward * 1f);
    }
}