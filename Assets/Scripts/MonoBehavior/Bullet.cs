using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitfx_bullet;
    public GameObject hitfx_head;
    public GameObject hitfx_body;
    // Update is called once per frame
    void Update()
    {
        //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의힘으로 날아간다
        transform.Translate(Vector3.forward * 0.1f);
        Instantiate(hitfx_bullet, transform.position, Quaternion.identity);
    }


    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        if(collision.collider.gameObject.CompareTag("Enemy_head")){
            
            
            Instantiate(hitfx_head, collision.transform.position, Quaternion.identity);
            
        }
        
        if(collision.collider.gameObject.CompareTag("Enemy_Body")){
            
            //gameObject.SetActive(false);
            Instantiate(hitfx_body, collision.transform.position, Quaternion.identity);
        }
        
    }
}
