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
        //currentHp = this.gameObject.GetComponent<Enemy>().hp; //�� ��ũ��Ʈ�� ����� ���� ������Ʈ�� Enemy ��ũ��Ʈ���� hp ��������, Enemy �� �� ��ũ��Ʈ�� �����ؾ� ��. this.gameObject ����
        //hpbar.value = currentHp / maxHp;

        hpbar.value = this.gameObject.GetComponent<Enemy>().hp;
    }
}
