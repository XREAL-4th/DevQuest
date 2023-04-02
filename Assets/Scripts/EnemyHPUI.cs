using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPUI : MonoBehaviour
{
    //public Transform Enemy;
    public Slider hpbar;
    //public float maxHp=50;
    //public float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Enemy.position + new Vector3(0, 0, 0);
        //currentHp = this.gameObject.GetComponent<Enemy>().hp; //이 스크립트에 적용된 게임 오브젝트의 Enemy 스크립트에서 hp 가져오기, Enemy 에 이 스크립트를 적용해야 함. this.gameObject 땜에
        //hpbar.value = currentHp / maxHp;

        hpbar.value = this.gameObject.GetComponent<Enemy>().hp;
    }
}
