using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    //적 체력 설정
    public int hp;
    public int maxHp = 15;

    //적 hp 슬라이더 변수
    public Slider hpSlider;

    //적 상태 상수
    enum EnemyState
    {
        Damaged,
        Die
    }
    //적 상태 변수
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

        //현재 체력의 비율을 슬라이더 값에 반영
        hpSlider.value = (float)hp / (float)maxHp;
    }
    //데미지 실행 함수
    public void HitEnemy(int hitPower)
    {
        //만약 사망상태일 경우 아무런 처리 하지 않고 함수 종료
        if(m_State == EnemyState.Die)
        {
            return;
        }

        //플레이어 공격력만큼 적 체력 감소
        hp -= hitPower;
        //적 체력이 0 이하면 사망
        if (hp <= 0)
        {
            m_State = EnemyState.Die;
            print("상태 전환 : Any State -> Die");
            Die();
        }

        void Die()
        {
            // 사망 상태 코루틴 실행
            StartCoroutine(DieProcess());
        }
    }    
    //사망 상태 처리 위한 코루틴
    IEnumerator DieProcess()
    {
        yield return new WaitForSeconds(0f);
        print("적 소멸");
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    

    // Update is called once per frame
    
}
