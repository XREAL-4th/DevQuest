using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;

    [SerializeField] public Slider hpSl;
    [SerializeField] private GameObject damageText;
    
    [Header("Settings")]
    [SerializeField] private float traceRange;
    [SerializeField] private float attackRange;
    
    public enum State 
    {
        None,
        Idle,
        Attack,
        Trace,
        Dead
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;
    public float hp = 15;

    private bool attackDone;
    private bool traceDone;

    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;

    private void Start()
    {
        state = State.None;
        nextState = State.Idle;
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
        animator = this.gameObject.GetComponent<Animator>();

        hpSl.gameObject.SetActive(true);
        hpSl.value = hp;
        hpSl.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3 (0, 3.5f, 0));
    }

    private void Update()
    {
        //1. 스테이트 전환 상황 판단
        if (nextState == State.None) 
        {
            switch (state) 
            {
                case State.Idle:
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
                case State.Dead:
                    nextState = State.Dead;
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
                case State.Dead:
                    nextState = State.Dead;
                    break;
            }
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
        // Debug.Log(hp);
        hpSl.value = hp;
        hpSl.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3 (0, 3f, 0));
        }
    }

    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        attackDone = true;
        animator.SetTrigger("attack");
        // Debug.Log("Attack!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.Dead) {
            // Debug.Log(collision.gameObject.tag);
            // Debug.Log(collision.gameObject.layer == 6);
            if (collision.gameObject.CompareTag("Bullet"))
            {
                hp -= 5;
                takeDamage(5);
                InstantiateFx();
            }
            if (collision.gameObject.CompareTag("Fire"))
            {
                hp -= 15;
                takeDamage(15);
                InstantiateFx();
            }
        }
    }

    public void takeDamage(int damage)
    {
        GameObject txt = Instantiate(damageText, transform.position, Quaternion.identity, GameObject.Find("Canvas").transform); // 생성할 텍스트 오브젝트
        txt.GetComponent<DamageTxt>().damage = damage;
        txt.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3 (0, 4.5f, 0));
    }

    public void InstantiateFx() //Unity Animation Event 에서 실행됩니다.
    {
        if (state != State.Dead){
            if (hp <= 0) {
                hp = 0;
                state = State.Dead;
                nextState = State.Dead;
                GameObject effect = Instantiate(splashFx, transform.position, Quaternion.identity);
                GameManager.CalScore();
                Destroy(effect, 2f); //왜 안 없어지지?
                Destroy(gameObject, 1f);
            }
        }
        // HpControl.hp.value = hp;
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