using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    
    [Header("Settings")]
    [SerializeField] private float attackRange;

//    [SerializeField] private float initHealth = 50;
    [SerializeField] public float health;
    [SerializeField] private Vector3 enemyPosition;
    [SerializeField] private float speed;

    [SerializeField] private EnemyData enemyData;

    public enum State 
    {
        None,
        Idle,
        Attack,
        Run
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;
    private bool chase;
    GameObject player;

    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;
        enemyPosition = gameObject.GetComponent<Transform>().position;
        player = GameManager.instance.player;

        //초기화
        health = enemyData.health;
        attackRange = enemyData.attackRange;
        speed = enemyData.speed;
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
                    //    nextState = State.Attack;
                        nextState = State.Run;
                        
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
                case State.Run:
                    //쫓아올 y값 조정
                    Vector3 target = player.transform.position;
                    target.y = transform.position.y;
                    //범위에 속하는 한 뒤쫓기
                    transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
                    
                    //범위를 벗어나면 Idle 상태로 돌아감
                    if (!Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Idle;
                        animator.SetBool("chase", false);
                    }
                    break;
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
                case State.Run:
                    Chase();
                    break;
            }
        }
        
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }

    //적에게 데미지를 입히는 함수
    public void GetDamage(int damage)
    {
        //데미지 UI 호출
        gameObject.GetComponentInChildren<EnemyHealthBar>().ShowDamage(damage);

        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            //존재하는 적 숫자 줄이기
            GameManager.instance.enemysCount--;

            //체력이 다 하면 적 사라지기
            Destroy(gameObject);
        }
        //넉백 구현
        //if (transform.position.x < bulletX)
        //{
        //    transform.Translate(1f, 0, 0);
        //}
        //else
        //{
        //    transform.Translate(-1f, 0, 0);
        //}
    }

    private void Chase()
    {
        animator.SetBool("chase", true);
    }
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
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
