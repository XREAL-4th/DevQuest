using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusItemCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("���� �������̶� ���� ������Ʈ:"+ collision.gameObject.tag);


        if (collision.gameObject.tag == "Player")
        {
            print("�������� �÷��̾�� ��Ҵ�.");

            GameManager.instance.AttackMinus();
            print("�÷��̾��� ���ݷ�: " + GameManager.instance.playerAttack);

            Destroy(this.gameObject); //�ڱ��ڽ��� �ı�


        }
    }
}
