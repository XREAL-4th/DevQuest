﻿using System.Collections;
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
        //플레이어가 아이템을 먹으면
        if (collision.gameObject == player)
        {
            //당근을 먹었을 때
            if(itemData.name == "carrot")
            {
                ModifyDamage();
                Destroy(gameObject);
            }
            //선물 상자를 먹었을 때
            if (itemData.name == "giftBox")
            {
                ModifySpeed();
                Destroy(gameObject);
            }
        }
    }

    void ModifyDamage()
    {
        //총알의 damage 를 5 높임
        player.GetComponent<shoot>().damage += itemData.damage;
    }

    void ModifySpeed()
    {
        //vr 플레이어의 속도를 10 높임
        player.GetComponent<PlayerContinuousMove>().speed += itemData.speed;
    }

}
