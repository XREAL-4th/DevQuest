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
            print(deadEnemy +"��");

        }*/


    }


    
    void OnCollisionEnter(Collision collision)
    {
        //print("�浹!!!");
        //print(collision.gameObject.tag + "�� �浹");


        if (collision.gameObject.tag == "Bullet") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
        {
            print("�Ѿ˰� �浹!!!!");

            GameObject spark = Instantiate(VFX);
            //GameObject spark = Instantiate(VFX);
            spark.transform.position = collision.transform.position;

            ///Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            //enemy.hp -= 10; //enemy ��ũ��Ʈ�� hp -10

            //print(enemy.hp + "���� HP");

            //hp -= 10;
            
            Destroy(spark, 1);
            Destroy(collision.gameObject);
            //GameManager.instance.minusHP(); // hp -10����

        }

    }

   


}
