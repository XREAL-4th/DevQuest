using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.UI;

//agent에게 목적지를 알려줘서 목적지로 이동하게 한다.
public class Enemy : MonoBehaviour
{
    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    [SerializeField] private GameObject hitfx;
    public int hp;

    public Transform target;
    NavMeshAgent agent;
    public Animator anim;

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;
    
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

        //요원 정의해줘서, 생성될 때 player를 찾는다 , 요원에게 목적지를 알려준다.
        agent = GetComponent<NavMeshAgent>();
        //target = GameObject.Find("Player").transform;
        //agent.destination = target.transform.position;
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
                //insert code here...
                case State.Chase:
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    if(distance > chaseRange){
                        nextState = State.Idle;
                        agent.speed = 0;
                    }
                    if(distance < attackRange){
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
                agent.speed = 0;

                target = GameObject.Find("Player").transform;
                    break;
                case State.Attack:
                    Attack();
                    break;
                //insert code here...
                case State.Chase:
                    Chase();
                    break;
            }
        }
        
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }
    
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }

    private void Chase()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance <= chaseRange){
            animator.SetTrigger("walk");
        }
        agent.speed = 3.5f;
        agent.destination = target.transform.position;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("bullet")){
            Instantiate(hitfx, transform.position, Quaternion.identity);
            hp--;
            Debug.Log("enemy damaged");
            if(hp==0){
                gameObject.SetActive(false);
            }
            
        }
    }

}
