using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    //�� ü�� ����
    public int hp;
    public int maxHp = 15;

    //�� hp �����̴� ����
    public Slider hpSlider;

    //�� ���� ���
    enum EnemyState
    {
        Damaged,
        Die
    }
    //�� ���� ����
    EnemyState m_State;


    void Start()
    {
        hp = maxHp;
    }

    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Damaged:
                break;
            case EnemyState.Die:
                break;
        }
        Debug.Log(hp);

        //���� ü���� ������ �����̴� ���� �ݿ�
        hpSlider.value = (float)hp / (float)maxHp;
    }
    //������ ���� �Լ�
    public void HitEnemy(int hitPower)
    {
        //���� ��������� ��� �ƹ��� ó�� ���� �ʰ� �Լ� ����
        if(m_State == EnemyState.Die)
        {
            return;
        }

        //�÷��̾� ���ݷ¸�ŭ �� ü�� ����
        hp -= hitPower;
        //�� ü���� 0 ���ϸ� ���
        if (hp <= 0)
        {
            m_State = EnemyState.Die;
            print("���� ��ȯ : Any State -> Die");
            Die();
        }

        void Die()
        {
            // ��� ���� �ڷ�ƾ ����
            StartCoroutine(DieProcess());
        }
    }    
    //��� ���� ó�� ���� �ڷ�ƾ
    IEnumerator DieProcess()
    {
        yield return new WaitForSeconds(0f);
        print("�� �Ҹ�");
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    
}
