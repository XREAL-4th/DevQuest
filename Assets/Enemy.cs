using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    public Transform target;
    NavMeshAgent agent; //agent : 네비게이션 메시 위에서 길을 찾아서 움직일 오브젝트
    public Animator anim;

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;
    [SerializeField] private float hp = 30.0f;
    private float curHp;
    private Vector3 curPos;




    public enum State 
    {
        None,
        Idle,
        Walk,
        Attack,
        Chase
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;

    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;

        // 게임이 시작되면 게임 오브젝트에 부착된 NavMeshAgent 컴포넌트를 가져온닽
        agent = GetComponent<NavMeshAgent>();

        curHp = hp;

        curPos = transform.position;
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
                    if (Physics.CheckSphere(transform.position, chaseRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        animator.SetTrigger("walk");
                        nextState = State.Chase;
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                case State.Chase:
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    if(distance > chaseRange)
                    {
                        nextState = State.Idle;
                        agent.speed = 0;
                    }
                    if (distance < attackRange)
                    {
                       nextState = State.Attack;
                        agent.speed = 3.5f;
                        agent.destination = target.transform.position;
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
            }
        }
        
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }

    private void Chase()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        //a와 b사이에 거리를 측정해 반환하는 함수
        if (distance <= chaseRange)
        {
            animator.SetTrigger("walk");
        }
        agent.speed = 3.5f;
        agent.destination = target.transform.position;

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

    public void GetDamage(float damage)
    {
        curHp -= damage;

        Debug.Log(curHp);
        if (curHp <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnDrawGizmosSelected()
    {
        //Gizmos를 사용하여 공격 범위를 Scene View에서 확인할 수 있게 합니다. (인게임에서는 볼 수 없습니다.)
        //해당 함수는 없어도 기능 상의 문제는 없지만, 기능 체크 및 디버깅을 용이하게 합니다.
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }
}
