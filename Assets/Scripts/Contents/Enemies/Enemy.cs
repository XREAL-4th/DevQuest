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
    Detect,
    Attack
}

public class Enemy : FSMMonoBehaviour<EnemyState>, IHealthy
{
    [Header("Presets")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    [SerializeField] private NavMeshAgent agent;

    [Header("Settings")]
    [SerializeField] private EnemyType type;


    private bool attackDone;
    private float health;
    public float Health { get => health; set => health = value; }

    protected override EnemyState NoneState => EnemyState.None;

    protected override EnemyState IdleState => EnemyState.Idle;

    protected override void Start()
    {
        base.Start();
        health = type.maxHealth;
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
        Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
        Gizmos.DrawSphere(transform.position, type.detectRange);
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, type.attackRange);
    }

    protected override void CheckState()
    {
        switch (state)
        {
            case EnemyState.Idle:
                if (Physics.CheckSphere(transform.position, type.detectRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    nextState = EnemyState.Detect;
                }
                break;
            case EnemyState.Attack:
                if (attackDone)
                {
                    nextState = EnemyState.Idle;
                    attackDone = false;
                }
                break;
            case EnemyState.Detect:
                if (Physics.CheckSphere(transform.position, type.attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    nextState = EnemyState.Attack;
                }
                break;
        }
    }

    protected override void InitState()
    {
        switch (state)
        {
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    protected override void UpdateState()
    {
        switch (state)
        {
            case EnemyState.Detect:
                animator.SetTrigger("walk");
                agent.SetDestination(Player.Main.transform.position);
                break;
        }
    }
}
