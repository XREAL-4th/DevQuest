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
    [SerializeField] private GameObject hitFx;

    [Header("Settings")]
    [SerializeField] private float attackRange;

    GameObject hit;
    
    public enum State 
    {
        None,
        Idle,
        Attack,
        Flee,
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;
    private bool fleeDone;

    GameObject bullet;
    public int life = 3;
    public GameObject player;

    float fleeTime;

    private void Start()
    {
        state = State.Idle;
        nextState = State.Idle;
        bullet = GameObject.Find("Bullet");
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        // 1. Chage state & Check state
        switch (state) {
            case State.Idle:
                Idle();
                // 1 << 6 : Player 6 Layers
                if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    nextState = State.Attack;
                }
                if (isNear()) {
                    nextState = State.Flee;
                }
                break;
            case State.Attack:
                if (attackDone)
                {
                    nextState = State.Idle;
                    attackDone = false;
                }
                if (isNear()) {
                    nextState = State.Flee;
                }
                break;
            //insert code here...
        }
        
        // 2. Initialize state
        if (nextState != State.None)
        {
            state = nextState;
            nextState = State.Idle;
            switch (state) {
                case State.Idle:
                    Idle();
                    break;
                case State.Attack:
                    Attack();
                    break;
                case State.Flee:
                    Flee();
                    break;
            }
        }
        
        // 3. Global & state update
        CheckLife();
    }
    
    private void Idle() {
        animator.SetTrigger("idle");
    }

    private void Attack() {
        animator.SetTrigger("attack");
    }

    private void Flee() {
        animator.SetTrigger("flee");
        Vector3 dist = transform.position - player.transform.position;
        transform.position += new Vector3(dist.x / 30.0f, 0.0f, dist.z / 30.0f);
    }

    private bool isNear() {
        return Vector3.Distance(transform.position, player.transform.position) < 5.0;
    }

    // Runs in Unity Animation Event
    public void InstantiateFx()
    {
        Instantiate(splashFx, transform.position, Quaternion.identity);
    }
    
    // Runs in Unity Animation Event
    public void WhenAnimationDone()
    {
        attackDone = true;
    }

    // Check Attack Range in Scene View using Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 collidePos = contact.point;
        Quaternion collideRot = Quaternion.FromToRotation(Vector3.up, contact.normal);

        Attack();
        life -= 1;
        GameManager.instance.score += 1;

        hit = Instantiate(hitFx, collidePos, collideRot);
        Destroy(hit, 1);
    }

    private void CheckLife() {
        if (life == 0) {
            Destroy(gameObject);
        }
    }
}
