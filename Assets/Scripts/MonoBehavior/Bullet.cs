using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의힘으로 날아간다
        transform.Translate(Vector3.forward * 0.1f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Enemy")){
            gameObject.SetActive(false);
        }
    }
}
