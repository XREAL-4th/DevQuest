using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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
    
    //에너미 상태 상수
    public enum State 
    {
        None,
        Idle,
        Attack,
        Move,
        Return
    }

    //플레이어 발견 범위
    public float findDistance = 8f;
    Transform player;

    //이동 속도
    public float moveSpeed = 4f;

    //공격 가능 범위
    public float attackDistance = 2f;

    CharacterController cc;


    //초기 위치 저장용 변수
    Vector3 originPos;
    //이동 가능 범위
    public float moveDistance = 20f;



    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;

    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;

        //플레이어의 트랜스폼 컴포넌트 받아옴
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();

        //적의 초기 위치 값 저장
        originPos = transform.position;

    }

    private void Update()
    {
        //1. 스테이트 전환 상황 판단
        if (nextState == State.None) 
        {
            //현재 상태 체크해 상태별로 정해진 기능 수행
            switch (state)
            {

                case State.Idle:
                    Idle();
                    break;
                case State.Move:
                    Move(); 
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Return:
                    Return(); 
                    break;



                /*
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
                case State.Move:
                    Move();
                    break;
                case State.Return:
                    Return();
                    break;
                */

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
    void Idle()
    {
        //만약 플레이어와의 거리가 findDistance 이내라면 Move 상태로 전환

        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            nextState = State.Move;
            print("상태 전환 : Idle -> Move");
        }
    }
    void Move()
    {
        //만약 현재 위치가 초기 위치에서 moveDistane 값을 넘어간다면 복귀 상태로 전환
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            nextState = State.Return;
            print("상태 전환 : Move -> Return");
        }
        
        //만약 플레이어와의 거리가 공격 범위 밖이라면 플레이어를 향해 이동
        else if(Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            //이동 방향 설정
            Vector3 dir = (player.position - transform.position).normalized;
            //플레이어를 향해 이동, 캐릭터 컨트롤러 컴포넌트 사용
            cc.Move(dir * moveSpeed * Time.deltaTime);
            
            animator.SetTrigger("walk");

        }
        //현재 상태를 공격 상태로 전환
        else
        {
            nextState = State.Attack;
            print("상태 전환 ; Move -> Attack");
        }
    }
    void Return()
    {
        //만약 초기 위치에서의 거리가 0.1f 이상이라면 초기 위치로 이동
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        //적의 위치를 초기 위치로 조정, 현재 상태를 대기로 전환
        else
        {
            transform.position = originPos;
            nextState = State.Idle;
            print("상태 전환 : Return -> Idle");
            animator.SetTrigger("idle");
        }
    }




    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        //만약 플레이어가 공격 범위 이내에 있다면 플레이어 공격
       if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            animator.SetTrigger("attack");
        }
        //현재 상태를 이동으로 전환, 재추격
        else
        {
            nextState = State.Move;
            print("상태전환 : Attack -> Move");

        }
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
