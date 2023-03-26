using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField]
    public ItemData itemData;
    GameObject player;
    void Start()
    {
        player = GameManager.instance.player;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //�÷��̾ �������� ������
        if (collision.gameObject == player)
        {
            //����� �Ծ��� ��
            if(itemData.name == "carrot")
            {
                ModifyDamage();
                Destroy(gameObject);
            }
            //���� ���ڸ� �Ծ��� ��
            if (itemData.name == "giftBox")
            {
                ModifySpeed();
                Destroy(gameObject);
            }
        }
    }

    void ModifyDamage()
    {
        //�Ѿ��� damage �� 5 -> 10���� ���� ����
        player.GetComponent<PlayerAttack>().damage = 10;
    }

    void ModifySpeed()
    {
        //�÷��̾��� �ӵ��� 10 ����
        player.GetComponent<MoveControl>().moveSpeed += 10;
    }

}
