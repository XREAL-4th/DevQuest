using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
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
        Stun
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    [SerializeField]
    private int hp;
    [SerializeField]
    private CapsuleCollider col;

    [SerializeField]
    private GameObject go_enemy;

    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0, 3.0f, 0);

    public Canvas enemyHpBarCanvas;
    public Slider enemyHpBarSlider;
    
    private bool attackDone;
    private bool stunDone;
    GameObject hpBar;

    private void Start()
    {
        SetHpBar();
        enemyHpBarSlider.gameObject.SetActive(true);
        enemyHpBarSlider.maxValue = hp;
        enemyHpBarSlider.value = hp;
        state = State.None;
        nextState = State.Idle;
    }

    public Gun Gun;

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
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                case State.Stun:
                    if(stunDone)
                    {
                        nextState = State.Idle;
                        stunDone = false;
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
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Stun:
                    Stun();
                    break;
                //insert code here...
            }
        }
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }
    
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
    }
    public void Stun()
    {
        animator.SetTrigger("stun");
        WhenAnimationDone();
    }

    public void InstantiateFx() //Unity Animation Event 에서 실행됩니다.
    {
        Instantiate(splashFx, transform.position, Quaternion.identity);
    }
    
    public void WhenAnimationDone() //Unity Animation Event 에서 실행됩니다.
    {
        attackDone = true;
        stunDone = true;
    }

    public void EnemyAttacked()
    {
        hp--;
        enemyHpBarSlider.value = hp;
        nextState = State.Stun;
        if (hp <= 0)
        {
            Destruction();
         }
    }

    public void EnemyMagicAttacked()
    {
        hp -= 2;
        enemyHpBarSlider.value = hp;
        nextState = State.Stun;
        if (hp <= 0)
        {
            Destruction();
        }
    }

    void SetHpBar()
    {
        enemyHpBarCanvas = GameObject.Find("Enemy HpBar Canvas").GetComponent<Canvas>();
        hpBar = Instantiate<GameObject>(hpBarPrefab, enemyHpBarCanvas.transform);
        enemyHpBarSlider = hpBar.GetComponentInChildren<Slider>();
        var _hpbar = hpBar.GetComponent<EnemyHpBar>();
        _hpbar.enemyTr = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;
    }

    private void Destruction()
    {
        col.enabled = false;
        GameObject[] tmptargets = GameManager.instance.targets;
        GameManager.instance.targets = tmptargets.Except(new GameObject[] { go_enemy }).ToArray();
        Debug.Log(go_enemy + "deleted");
        Destroy(go_enemy);
        Destroy(hpBar);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos를 사용하여 공격 범위를 Scene View에서 확인할 수 있게 합니다. (인게임에서는 볼 수 없습니다.)
        //해당 함수는 없어도 기능 상의 문제는 없지만, 기능 체크 및 디버깅을 용이하게 합니다.
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }
}
