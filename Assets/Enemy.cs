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
    [SerializeField] private float chaseRange;

    public enum State
    {
        None,
        Idle,
        Attack,
        Chase,
        Walk,
    }

    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone = false;
    private bool chaseDone = false;
    private int curIndex;

    public NavMeshAgent navMeshAgent;
    public GameObject player;
    public GameObject pushVfx;
    public GameObject attackedVfx;
    public GameObject[] Waypoints;// = new GameObject[6];


    private void Start()
    {
        state = State.None;
        nextState = State.Idle;
        player = GameObject.Find("Player");
        attackedVfx = GameObject.Find("Debuff");

        curIndex = Random.Range(0, Waypoints.Length);
        navMeshAgent.SetDestination(Waypoints[curIndex].transform.position);

    }

    private void Update()
    {
        
        //1. 스테이트 전환 상황 판단
        if (nextState == State.None)
        {
            switch (state)
            {
                case State.Idle:
                    this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    nextState = State.Walk;
                    //1 << 6인 이유는 Player의 Layer가 6이기 때문    
                    /*if (Physics.CheckSphere(transform.position, chaseRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Chase;
                    }*/
                    break;
                case State.Walk:
                    //this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                    //1 << 6인 이유는 Player의 Layer가 6이기 때문    
                    if (Physics.CheckSphere(transform.position, chaseRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Chase;
                    }
                    else if (navMeshAgent.velocity.sqrMagnitude >= 0.2f && navMeshAgent.remainingDistance <= 0.5f)
                    {
                        curIndex = Random.Range(0, Waypoints.Length);
                        navMeshAgent.SetDestination(Waypoints[curIndex].transform.position);
                    }

                    break;
                case State.Attack:
                    if (attackDone && !Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Chase;
                        attackDone = false;
                    }
                    else
                    {
                        nextState = State.Attack;
                    }
                    break;
                case State.Chase:
                    navMeshAgent.SetDestination(player.transform.position);
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Attack;
                    }
                    else if (!Physics.CheckSphere(transform.position, chaseRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Walk;
                        navMeshAgent.SetDestination(Waypoints[curIndex].transform.position);
                    }
                    else
                    {
                        nextState = State.Chase;
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
                    attackedVfx.SetActive(false);
                    animator.SetBool("idle", true);
                    animator.SetBool("attack", false);
                    animator.SetBool("walk", false);
                    break;
                case State.Walk:
                    attackedVfx.SetActive(false);
                    animator.SetBool("idle", false);
                    animator.SetBool("attack", false);
                    animator.SetBool("walk", true);
                    break;
                case State.Attack:
                    Debug.Log("attack");
                    attackedVfx.SetActive(true);
                    attackedVfx.transform.position = player.transform.position;
                    animator.SetBool("idle", false);
                    animator.SetBool("attack", true);
                    animator.SetBool("walk", false);
                    Attack();
                    break;
                case State.Chase:
                    attackedVfx.SetActive(false);
                    Debug.Log("chase");
                    animator.SetBool("idle", false);
                    animator.SetBool("attack", false);
                    animator.SetBool("walk", true);
                    break;

                    //insert code here...
            }
        }

        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }

    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        //attackedVfx.SetActive(true);
        //attackedVfx.transform.position = player.transform.position;
        attackDone = true;

        player.GetComponent<MoveControl>().playerHp--;


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
        Gizmos.DrawSphere(transform.position, chaseRange);
    }

    public void PushSkill()
    {
        if (state == State.Attack || state == State.Chase)
        {

            Vector3 direction = this.transform.position - player.transform.position;
            direction = direction.normalized;
            this.GetComponent<Rigidbody>().AddForce(direction * 1800, ForceMode.Impulse);

            GameObject vfx = Instantiate(pushVfx) as GameObject;
            vfx.transform.position = this.transform.position;
        }
    }

}
