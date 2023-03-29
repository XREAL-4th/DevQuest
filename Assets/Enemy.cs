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
    [SerializeField] private float followRange;

    public enum State 
    {
        None,
        Idle,
        Attack,
        Follow
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    [SerializeField]
    private bool attackDone;

    [SerializeField]
    private bool followDone;

    [SerializeField]
    private float _walkSpeed = 1.0f;
    private float _distanceCheck = 0.1f;
    private bool _move = false;
    private Vector3 _targetPos;

    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;
        attackDone = true;
        followDone = true;
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
                    if (Physics.CheckSphere(transform.position, followRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                        {
                            nextState = State.Attack;
                        } else
                        {
                            Debug.Log("IDLE -> followRange 들어온 것 인식");
                            nextState = State.Follow;
                        }
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        attackDone = false;
                        if (Physics.CheckSphere(transform.position, followRange, 1 << 6, QueryTriggerInteraction.Ignore))
                        {
                            nextState = State.Follow;
                        } else
                        {
                            nextState = State.Idle;
                        }
                    }
                    break;
                case State.Follow:
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Attack;
                        followDone = true;
                    }
                    if (!Physics.CheckSphere(transform.position, followRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Idle;
                        followDone = true;
                    }
                    followDone = false;
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
                    Debug.Log("IDLE ssss 실행");
                    Idle();
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Follow:
                    Follow();
                    break;
                //insert code here...
            }
        }
        
        if(!followDone)
        {
            Follow_move();
        }

        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }
    
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }

    private void Follow()
    {
        animator.SetTrigger("walk");
    }

    private void Follow_move()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore);
        foreach (Collider col in colliders)
        {
            //if (col.name == "Sphere" /* 자기 자신은 제외 */) continue;
            Debug.Log("콜라이더 이름" + col.name);
            if (col.name == "Player") _targetPos = col.transform.position;
        }
        _move = MoveToPosition(_targetPos);
    }

    private bool MoveToPosition(Vector3 _targetPos)
    {
        if (Vector3.Magnitude(transform.position - _targetPos) < _distanceCheck)
        {
            // arrived. cancel move.
            Debug.Log("arrived! stop moving!");
            return false;
        }
        // should move towards target
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, Time.deltaTime * _walkSpeed);
        transform.LookAt(_targetPos, Vector3.up);
        return true;
    }


    private void Idle()
    {
        Debug.Log("IDLE 함수 실행");
        animator.SetTrigger("idle");
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

        Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, followRange);
    }
}
