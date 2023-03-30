using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private Type type;
    [SerializeField] private int hp;
    [SerializeField] private float moveSpeed;

    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    
    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;

    [Header("Sys")]
    [SerializeField] private GameObject sys;
    [SerializeField] private GameObject targetPlayer;
    private MissionManager missionManager;
    private Rigidbody rb;

    public enum State 
    {
        None,
        Idle,
        Wander,
        Chase,
        Charge,
        AttackLong,
        AttackShort,
        Stun
    }

    private enum Type
    {
        NORMAL,
        METAL
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;
    private bool stunDone;

    private void Start()
    { 
        rb = GetComponent<Rigidbody>();
        state = State.None;
        nextState = State.Idle;
        switch(type)
        {
            case Type.NORMAL:
                hp = 20;
                break;
            case Type.METAL:
                hp = 40;
                break;
            default: break;
        }

        sys = GameObject.FindGameObjectWithTag("SysObj");
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        missionManager = sys.GetComponent<MissionManager>();
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
                        nextState = State.AttackShort;
                    }
                    else if(Physics.CheckSphere(transform.position, chaseRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState= State.Chase;
                    }
                    break;
                case State.Chase:
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.AttackShort;
                    }
                    else if (!Physics.CheckSphere(transform.position, chaseRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Idle;
                    }
                    else
                    {
                        Vector3 dir = targetPlayer.transform.position- transform.position;
                        dir.y = 0;
                        dir.Normalize();
                        transform.rotation = Quaternion.LookRotation(dir);
                        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);

                    }
                    break;
                case State.AttackShort:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                case State.Stun:
                    if(true)
                    {
                        nextState = State.Idle;
                        stunDone= false;
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
                    Idel();
                    break;
                case State.Chase:
                    Walk();
                    break;
                case State.AttackShort:
                    Attack();
                    break;
                case State.Stun:
                    Stun();
                    break;
                //insert code here...
            }
        }

        //3. 글로벌 & 스테이트 업데이트
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Debug.Log("Enemy Destroyed");
        if(missionManager.missionStep == MissionManager.Steps.MISSION_1)
        {
            missionManager.MissionFunction();
        }
    }

    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }
    private void Walk()
    {
        animator.SetBool("walk", true);
    }
    private void Idel()
    {
        animator.SetBool("idle", true);
    }
    private void Stun()
    {
        animator.SetBool("stun",true);
    }

    public void InstantiateFx() //Unity Animation Event 에서 실행됩니다.
    {
        Instantiate(splashFx, transform.position, Quaternion.identity);
    }
    
    public void WhenAnimationDone() //Unity Animation Event 에서 실행됩니다.
    {
        attackDone = true;
    }

    public void TakeDamage(int dmg, Transform bullet)
    {
        if (state != State.AttackShort) nextState = State.Stun;
        Vector3 dir = transform.position - bullet.position;
        dir.y = 0;
        rb.AddForce(dir.normalized*dmg*4,ForceMode.VelocityChange);
        //transform.Translate(dir.normalized*dmg/4);
        hp -= dmg;
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos를 사용하여 공격 범위를 Scene View에서 확인할 수 있게 합니다. (인게임에서는 볼 수 없습니다.)
        //해당 함수는 없어도 기능 상의 문제는 없지만, 기능 체크 및 디버깅을 용이하게 합니다.
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
        Gizmos.color = new Color(0f, 0f, 1f, 0.3f);
        Gizmos.DrawSphere(transform.position, chaseRange);
    }
}
