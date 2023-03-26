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
        //총알의 damage 를 5 -> 10으로 상향 조정
        player.GetComponent<PlayerAttack>().damage = 10;
    }

    void ModifySpeed()
    {
        //플레이어의 속도를 5 높임
        player.GetComponent<MoveControl>().moveSpeed += 5;
    }

}
