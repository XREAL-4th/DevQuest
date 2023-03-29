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
    [SerializeField] private float traceRange;
    [SerializeField] private float attackRange;
    
    public enum State 
    {
        None,
        Idle,
        Attack,
        Trace
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private int hp;

    private bool attackDone;
    private bool traceDone;

    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;

    private void Start()
    {
        state = State.None;
        nextState = State.Idle;
        hp = 15;

        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();
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
                    } else if (Physics.CheckSphere(transform.position, traceRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Trace;
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                case State.Trace:
                    if (traceDone){
                        nextState = State.Idle;
                        traceDone = false;
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
                    nvAgent.Stop();
                    animator.SetBool("isTrace", false);
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent.Resume();
                    animator.SetBool("isTrace", true);
                    break;
            }
        }
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }

    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        attackDone = true;
        animator.SetTrigger("attack");
        // Debug.Log("Attack!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        // Debug.Log(collision.gameObject.layer == 6);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 5;
            InstantiateFx();
        }
        if (collision.gameObject.CompareTag("Fire"))
        {
            hp -= 15;
            InstantiateFx();
        }
    }

    public void InstantiateFx() //Unity Animation Event 에서 실행됩니다.
    {
        if (hp == 0) {
            GameObject effect = Instantiate(splashFx, transform.position, Quaternion.identity);
            GameManager.CalScore();
            hp = -1;
            Destroy(effect, 2f); //왜 안 없어지지?
            Destroy(gameObject, 1f);
        }
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
