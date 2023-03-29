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
    [SerializeField] private float chasingRedBallRange;
    [SerializeField] private float chasingPlayerRange;
    
    public enum State 
    {
        None,
        Idle,
        Attack,
        ChasingRedBall,
        ChasingPlayer
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;

    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;
    }

    private void Update()
    {
        //1. 스테이트 전환 상황 판단
        if (nextState == State.None) 
        {
            switch (state) 
            {
                case State.Idle:
                    CheckArea();
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                case State.ChasingPlayer:
                    CheckArea();
                    break;
                case State.ChasingRedBall:
                    CheckArea();
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
                case State.ChasingPlayer:
                    ChasingPlayer();
                    break;
                case State.ChasingRedBall:
                    ChasingRedBall();
                    break;
                //insert code here...
            }
        }
        
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }

    private void CheckArea()
    {
        //1 << 6인 이유는 Player의 Layer가 6이기 때문
        if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
        {
            nextState = State.Attack;
        }else if (Physics.CheckSphere(transform.position,chasingPlayerRange,1<<6,QueryTriggerInteraction.Ignore))
        {
            // Chasing Player
            nextState = State.ChasingPlayer;
        }else if (Physics.CheckSphere(transform.position,chasingRedBallRange,1<<9,QueryTriggerInteraction.Ignore))
        {
            // Chasing RedBall
            nextState = State.ChasingRedBall;
        }
    }
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }

    private void ChasingPlayer()
    {
        Debug.Log("chasingPlayer");
    }
    private void ChasingRedBall()
    {
        Debug.Log("chasingRedBall");
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
        Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
        Gizmos.DrawSphere(transform.position, chasingPlayerRange);
        Gizmos.color = new Color(0f, 0f, 1f, 0.1f);
        Gizmos.DrawSphere(transform.position, chasingRedBallRange);
    }
}
