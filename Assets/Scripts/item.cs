using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField]
    public ItemData itemData;
    //public ItemData ItemData { set { itemData = value; } }
    GameObject player;
    void Start()
    {
        player = GameManager.instance.player;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            if(itemData.name == "carrot")
            {
                ModifyDamage();
                Destroy(gameObject);
            }
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
        //�÷��̾��� �ӵ��� 5 ����
        player.GetComponent<MoveControl>().moveSpeed += 5;
    }

}
