using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusItemCtrl : MonoBehaviour
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
        print("초록 아이템이랑 닿은 오브젝트:"+collision.gameObject.tag);


        if (collision.gameObject.tag == "Player")
        {
            print("아이템이 플레이어와 닿았다.");

            GameManager.instance.AttackPlus();
            print("플레이어의 공격력: " + GameManager.instance.playerAttack);

            Destroy(this.gameObject); //자기자신을 파괴


        }
    }
}
