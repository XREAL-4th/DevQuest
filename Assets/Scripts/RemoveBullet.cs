using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject VFX;
    //public int hp = 50;
    //public int deadEnemy = 0;

    void Update()
    {
        /*if (hp <= 0)
        {
            Destroy(this.gameObject);
            deadEnemy += 1;
            print(deadEnemy +"명");

        }*/


    }


    
    void OnCollisionEnter(Collision collision)
    {
        //print("충돌!!!");
        //print(collision.gameObject.tag + "랑 충돌");


        if (collision.gameObject.tag == "Bullet") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
        {
            print("총알과 충돌!!!!");

            GameObject spark = Instantiate(VFX);
            //GameObject spark = Instantiate(VFX);
            spark.transform.position = collision.transform.position;

            ///Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            //enemy.hp -= 10; //enemy 스크립트의 hp -10

            //print(enemy.hp + "현재 HP");

            //hp -= 10;
            
            Destroy(spark, 1);
            Destroy(collision.gameObject);
            //GameManager.instance.minusHP(); // hp -10감소

        }

    }

   


}
