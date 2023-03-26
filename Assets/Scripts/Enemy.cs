using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    [SerializeField] private HealthBar healthBar;
    
    [Header("Settings")]
    [SerializeField] private float attackRange;
    public float MaxHealth = 100.0f;
    [SerializeField] private float CurHealth;
    [SerializeField] private Vector3 CurPos;
    [SerializeField] private float delta = 1.0f; // 좌(우)로 이동가능한 (x)최대값
    [SerializeField] private float speed = 1.0f; // 이동속도

    public enum State 
    {
        None,
        Idle,
        Attack
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;

    private void Start()
    {
        state = State.None;
        nextState = State.Idle;

        CurHealth = MaxHealth;
        healthBar.UpdateHealthBar(MaxHealth, CurHealth);

        delta = (float)UnityEngine.Random.Range(1, 4);
        speed = (float)UnityEngine.Random.Range(1, 3); 
        CurPos = transform.position;
    }

    private void Update()
    {
        //1. 스테이트 전환 상황 판단
        if (nextState == State.None) 
        {
            switch (state) 
            {
                case State.Idle:
                    //1 << 6인 이유는 Player의 Layer가 6이기 때문
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Attack;
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                //insert code here...
            }
        }
        
        //2. 스테이트 초기화
        if (nextState != State.None) 
        {
            state = nextState;
            nextState = State.None;
            switch (state) 
            {
                case State.Idle:
                    break;
                case State.Attack:
                    Attack();
                    break;
                //insert code here...
            }
        }

        //3. 글로벌 & 스테이트 업데이트
        //insert code here...

        //+--- [0320] 임시 Idle ---+//
        IdleMove();
    }
    
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }

    //+--- [0320]Task 1-1 ---+//
    public void TakeDamage (float amount) 
    {
        CurHealth -= amount;

        healthBar.UpdateHealthBar(MaxHealth, CurHealth);

        if (CurHealth <= 0.0f) 
        {
            Die();
            GameManager.instance.killEnemy++;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void IdleMove()
    {
        Vector3 vec = CurPos;
        vec.x += delta * Mathf.Sin(Time.time * speed);

        transform.position = vec;
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);

    }


    public void InstantiateFx() //Unity Animation Event 에서 실행됩니다.
    {
        Instantiate(splashFx, transform.position, Quaternion.identity);
    }
    
    public void WhenAnimationDone() //Unity Animation Event 에서 실행됩니다.
    {
        attackDone = true;
    }


    private void OnDrawGizmosSelected()
    {
        //Gizmos를 사용하여 공격 범위를 Scene View에서 확인할 수 있게 합니다. (인게임에서는 볼 수 없습니다.)
        //해당 함수는 없어도 기능 상의 문제는 없지만, 기능 체크 및 디버깅을 용이하게 합니다.
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }
}
