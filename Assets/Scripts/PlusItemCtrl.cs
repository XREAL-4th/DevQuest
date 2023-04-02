using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusItemCtrl : MonoBehaviour
{
    public ItemData itemdata; //SO

    private void OnEnable()
    {
        Debug.LogWarning("�̸�: " + itemdata.ItemName + ","+" ���ݿ� ������ ��ġ�� ����: " + itemdata.affectAttack);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("�ʷ� �������̶� ���� ������Ʈ:"+collision.gameObject.tag);


        if (collision.gameObject.tag == "Player")
        {
            print("�������� �÷��̾�� ��Ҵ�.");
            GameObject spark = Instantiate(itemdata.effect); //SO�� ����� vfx
            spark.transform.position = collision.transform.position;
            Destroy(spark, 1);

            GameManager.instance.AttackPlus();
            print("�÷��̾��� ���ݷ�: " + GameManager.instance.playerAttack);

            Destroy(this.gameObject); //�ڱ��ڽ��� �ı�


        }
    }
}