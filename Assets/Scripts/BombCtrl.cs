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
            Debug.Log("��ź ����");
        }
        */



        //3�� ������ �� �ݰ濡 �ִ� collider ���� enemy���� hp -20�� �ش�.

        //�׸��� VFX�� ����ǰ�

        /*
        if (time >= 1.5)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        */
    }

    void OnTriggerStay(Collider collision) //���� collider�� �� �� ��µ�, �ϳ��� collider ū�� (�ݰ��) �ε� �̰� on trigger �س���. �̰� ���ϸ� ���� ���־. �ٵ� �̰� �����Ϸ��� collision enter �� �ƴ϶� trigger ��� ��.
    {
        //enter ���� �ȵǸ� stay.�ֳĸ� �ð��� �����Ŷ� �浹�� �� �� �ƴ϶� �̹� �浹 ���´ϱ�.
        //�� �׷� enter �� �ƴ϶� stay�� �´�...
        // �׷� OverlapSphere���� ������ �������� �׳� collider ũ�⸦ �ø��� !!!

        if (time >= 3) //3�ʰ� ������ ��
        {

            print("��ź�� ���� tag �̸�:" + collision.gameObject.tag);
            if (collision.gameObject.tag == "Enemy") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
            {
                print("��ź�� ���� �� enemy�� ����");

                collision.gameObject.GetComponent<Enemy>().hp -= 20; //���� ������Ʈ�� enemy ��ũ��Ʈ���� hp�� ������ -20 ���ҽ�Ų��.
                print("��ź�� ���� �� ���� HP: " + collision.gameObject.GetComponent<Enemy>().hp);

                //spark.transform.position = collision.gameObject.transform.position; //��ź ���� enemy�� vfx ȿ�� �ֱ�
                //Destroy(spark, 1);



            }

            GameObject spark = Instantiate(VFX);
            spark.transform.position = transform.position;
            Destroy(spark, 1);
            Destroy(gameObject);
            Debug.Log("��ź ����");

        }

        



        /* �ϴ� ���� ��ø� 
        if (time >= 3.0) //3�ʰ� ������ ��
        {
            //Destroy(gameObject);
            Debug.Log("3�ʰ� ������ ����");

            if (Physics.CheckSphere(transform.position, 3, 1 << 7, QueryTriggerInteraction.Ignore)) //��ź ��ġ�κ��� 3�ݰ� �̳��� �ִ� enemy�� ������
            {

            }
        }
        ��ø� */

        /*
        if (collision.gameObject.tag == "Enemy") //other.gameObject.tag=="Enemy" //collision.collider.tag == "Enemy"
        {
            print("�Ѿ˰� �浹!!!!");

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
