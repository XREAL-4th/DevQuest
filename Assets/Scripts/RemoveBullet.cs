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
        //print("�浹!!!");
        //print(collision.gameObject.tag + "�� �浹");


        if (collision.gameObject.tag == "Bullet") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
        {
            print("�Ѿ˰� �浹!!!!");

            GameObject spark = Instantiate(VFX);
            //GameObject spark = Instantiate(VFX);
            spark.transform.position = collision.transform.position;

            ///Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

            Destroy(spark, 1);
            Destroy(collision.gameObject);

        }

    }

   


}
