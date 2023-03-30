using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCtrl : MonoBehaviour
{
    public float speed = 1000;
    private float time = 0.0f;
    public GameObject VFX;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        /*
        if (time >= 3)
        {


            GameObject spark = Instantiate(VFX);
            //GameObject spark = Instantiate(VFX);
            spark.transform.position = transform.position;
            Destroy(spark, 1);
            Destroy(gameObject);
            Debug.Log("폭탄 터짐");
        }
        */



        //3초 지나서 그 반경에 있는 collider 가진 enemy에게 hp -20을 준다.

        //그리고 VFX가 실행되고

        /*
        if (time >= 1.5)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        */
    }

    void OnTriggerStay(Collider collision) //내가 collider를 두 개 썼는데, 하나는 collider 큰거 (반경용) 인데 이거 on trigger 해놨음. 이거 안하면 구가 떠있어서. 근데 이걸 감지하려면 collision enter 가 아니라 trigger 써야 함.
    {
        //enter 쓰고 안되면 stay.왜냐면 시간이 지난거라 충돌할 때 가 아니라 이미 충돌 상태니까.
        //하 그래 enter 가 아니라 stay가 맞다...
        // 그래 OverlapSphere같은 어려운거 쓰지말고 그냥 collider 크기를 늘리자 !!!

        if (time >= 3) //3초가 지났을 때
        {

            print("폭탄과 닿은 tag 이름:" + collision.gameObject.tag);
            if (collision.gameObject.tag == "Enemy") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
            {
                print("폭탄이 터질 때 enemy에 영향");

                collision.gameObject.GetComponent<Enemy>().hp -= 20; //닿은 오브젝트의 enemy 스크립트에서 hp를 가져와 -20 감소시킨다.
                print("폭탄을 맞은 후 적의 HP: " + collision.gameObject.GetComponent<Enemy>().hp);

                //spark.transform.position = collision.gameObject.transform.position; //폭탄 맞은 enemy도 vfx 효과 주기
                //Destroy(spark, 1);



            }

            GameObject spark = Instantiate(VFX);
            spark.transform.position = transform.position;
            Destroy(spark, 1);
            Destroy(gameObject);
            Debug.Log("폭탄 터짐");

        }

        



        /* 일단 보류 잠시만 
        if (time >= 3.0) //3초가 지났을 때
        {
            //Destroy(gameObject);
            Debug.Log("3초가 지나서 폭파");

            if (Physics.CheckSphere(transform.position, 3, 1 << 7, QueryTriggerInteraction.Ignore)) //폭탄 위치로부터 3반경 이내에 있는 enemy와 닿으면
            {

            }
        }
        잠시만 */

        /*
        if (collision.gameObject.tag == "Enemy") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
        {
            print("총알과 충돌!!!!");

            GameObject spark = Instantiate(VFX);
            //GameObject spark = Instantiate(VFX);
            spark.transform.position = collision.transform.position;

            ///Enemy enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

            Destroy(spark, 1);
            Destroy(collision.gameObject);

        }
        */

    }
}
