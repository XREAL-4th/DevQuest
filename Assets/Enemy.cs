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
        Follow,
        Attack
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;
    public GameObject knifePrefab;

    private Transform target;
    private NavMeshAgent navAgent;
   //public ParticleSystem particleObject;
   //private bool inBound = false;

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
                    //1 << 6인 이유는 Player의 Layer가 6이기 때문
                    if (Physics.CheckSphere(transform.position, followRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Follow;
                    }
                    break;
                case State.Follow:
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        animator.SetBool("walk", false);
                        nextState = State.Attack;
                    }
                    else if (!Physics.CheckSphere(transform.position, followRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        animator.SetBool("walk", false);
                        nextState = State.Idle;
                    }
                    else
                    {
                        nextState = State.Follow;
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        if (Physics.CheckSphere(transform.position, followRange, 1 << 6, QueryTriggerInteraction.Ignore))
                        {
                            animator.SetBool("attack", false);
                            animator.SetBool("walk", true);
                            nextState = State.Follow;
                        }
                        else
                        {
                            animator.SetBool("attack", false);
                            nextState = State.Idle;
                        }
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
                    animator.SetBool("idle", true);
                    navAgent = GetComponent<NavMeshAgent>();
                    navAgent.SetDestination(transform.position);
                    //inBound = false;
                    break;

                case State.Follow:
                    Follow();
                    break;

                case State.Attack:
                    Attack();
                    break;
                //insert code here...
            }
        }

        /*if (inBound)
        {
            particleObject.Play();
        }
        else
        {
            particleObject.Stop();
        }*/

        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }


    private void Follow()
    {
        //inBound = true;
        animator.SetBool("walk", true);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(target.position);
    }
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetBool("attack", true);
    }

    public void InstantiateFx() //Unity Animation Event 에서 실행됩니다.
    {
        Instantiate(splashFx, transform.position, Quaternion.identity);
    }
    
    public void WhenAnimationDone() //Unity Animation Event 에서 실행됩니다.
    {
        GameObject weapon = Instantiate(knifePrefab, new Vector3(transform.position.x,1f, transform.position.z), knifePrefab.transform.rotation) as GameObject;
        Vector3 shooting = (target.position - transform.position).normalized;
        shooting = shooting.normalized * 1000;
        weapon.GetComponent<EnemyWeapon>().Launch(shooting);
        attackDone = true;
    }


    private void OnDrawGizmosSelected()
    {
        //Gizmos를 사용하여 공격 범위를 Scene View에서 확인할 수 있게 합니다. (인게임에서는 볼 수 없습니다.)
        //해당 함수는 없어도 기능 상의 문제는 없지만, 기능 체크 및 디버깅을 용이하게 합니다.
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);

        Gizmos.color = new Color(85f, 211f, 241f, 0.3f);
        Gizmos.DrawSphere(transform.position, followRange);
    }
}
