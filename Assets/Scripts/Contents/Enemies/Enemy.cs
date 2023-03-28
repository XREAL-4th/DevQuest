using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public enum EnemyState
{
    None,
    Idle,
    Attack
}

public class Enemy : FSMMonoBehaviour<EnemyState>, IHealthy
{
    [Header("Presets")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    
    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private EnemyType type;


    private bool attackDone;
    private float health;
    public float Health { get => health; set => health = value; }

    private void Start()
    {
        health = type.maxHealth;
        state = EnemyState.None;
        nextState = EnemyState.Idle;
    }

    protected override void Update()
    {
        base.Update();
     
        if (Health <= 0) Kill();
    }

    private void Kill() => Destroy(gameObject);
    
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        animator.SetTrigger("attack");
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

    protected override void CheckState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                //1 << 6인 이유는 Player의 Layer가 6이기 때문
                if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    nextState = EnemyState.Attack;
                }
                break;
            case EnemyState.Attack:
                if (attackDone)
                {
                    nextState = EnemyState.Idle;
                    attackDone = false;
                }
                break;
        }
    }

    protected override void InitState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    protected override void UpdateState()
    {
        
    }
}
