using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject VFX;

    void Update()
    {


    }


    
    void OnCollisionEnter(Collision collision)
    {
        //print("충돌!!!");
        //print(collision.gameObject.tag + "랑 충돌");


        //왜냐면 얘가 enemy에 적용된 스크립트라서 Enemy입장에서 bullet에 닿았을 때.
        if (collision.gameObject.tag == "Bullet") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
        {
            print("총알과 충돌!!!!");

            GameObject spark = Instantiate(VFX);
            //GameObject spark = Instantiate(VFX);
            spark.transform.position = collision.transform.position;

            ///Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

            Destroy(spark, 1);
            Destroy(collision.gameObject);

        }

    }

   


}
