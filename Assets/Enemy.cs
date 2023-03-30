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

    public Vector3 origin_position;

    NavMeshAgent nav;
    GameObject target;

    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;
        attackDone = true;
        followDone = true;

        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
        origin_position = transform.position;
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
                    } else if (followDone == false)
                    {
                        nextState = State.Follow;
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        attackDone = false;
                        if(followDone)
                        {
                            nextState = State.Idle;
                        } else
                        {
                            nextState = State.Follow;
                        }
                    }
                    break;
                case State.Follow:
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Attack;
                        followDone = true;
                    } else if(followDone == true)
                    {
                        nextState = State.Idle;
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

        //인식 거리 내로 들어왔을 경우 플레이어 쫒기
        Nav_follow();

        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            followDone = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            followDone = true;
        }
    }


    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }

    private void Follow()
    {
        animator.SetBool("bWalk", true);
    }
    private void Idle()
    {
        animator.SetBool("bWalk", false);
    }

    private void Nav_follow()
    {
        if(followDone == true)
        {
            /*            Debug.Log(origin_position);
                        nav.SetDestination(origin_position);*/
            nav.SetDestination(transform.position);
        } else
        {
            if (nav.destination != target.transform.position)
            {
                nav.SetDestination(target.transform.position);
            }
            else
            {
                nav.SetDestination(transform.position);
            }
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
