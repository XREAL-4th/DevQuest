using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusItemCtrl : MonoBehaviour
{
    public ItemData itemdata; //SO

    private void OnEnable()
    {
        Debug.LogWarning("이름: " + itemdata.ItemName + "," + " 공격에 영향을 미치는 정도: " + itemdata.affectAttack);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("빨간 아이템이랑 닿은 오브젝트:"+ collision.gameObject.tag);


        if (collision.gameObject.tag == "Player")
        {
            print("아이템이 플레이어와 닿았다.");


            GameObject spark = Instantiate(itemdata.effect); //SO에 저장된 vfx
            spark.transform.position = collision.transform.position;
            Destroy(spark, 1);


            GameManager.instance.AttackMinus();
            print("플레이어의 공격력: " + GameManager.instance.playerAttack);

            Destroy(this.gameObject); //자기자신을 파괴


        }
    }
}
