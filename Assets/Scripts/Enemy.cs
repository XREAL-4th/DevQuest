using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("Preset Fields")] 
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject splashFx;
    [SerializeField] private GameObject hitFx;

    [Header("Settings")]
    [SerializeField] private float attackRange;

    public enum State 
    {
        None,
        Idle,
        Attack,
        Flee,
    }
    
    [Header("Debug")]
    public int life = 3;

    private GameObject player;
    private GameObject bullet;
    private float fleeTime;
    private GameObject hit;

    private State state = State.None;
    private State nextState = State.None;
    private bool attackDone;
    private bool fleeDone;

    public GameObject prefabBar;
    private GameObject HPbar;
    private GameObject HP;
    Vector3 padding = new Vector3(0.0f, 2.6f, 0.0f);

    private void Start() {
        state = State.Idle;
        nextState = State.Idle;
        bullet = GameObject.Find("Bullet");
        player = GameObject.Find("Player");       
        HPbar = Instantiate(prefabBar, transform.position + padding, transform.rotation);
        HPbar.transform.SetParent(transform);
        HP = HPbar.transform.GetChild(1).gameObject;
    }

    private void Update() {
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
        UpdateHP();
    }

    private void UpdateHP() {
        HPbar.transform.position = transform.position + padding;
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
    public void InstantiateFx() {
        Instantiate(splashFx, transform.position, Quaternion.identity);
    }
    
    // Runs in Unity Animation Event
    public void WhenAnimationDone() {
        attackDone = true;
    }

    // Check Attack Range in Scene View using Gizmos
    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }

    private void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        Vector3 collidePos = contact.point;
        Quaternion collideRot = Quaternion.FromToRotation(Vector3.up, contact.normal);

        Attack();
        life -= 1;
        GameManager.instance.score += 1;
        HP.GetComponent<Image>().fillAmount -= 0.3333f;

        hit = Instantiate(hitFx, collidePos, collideRot);
        Destroy(hit, 1);
        //Destroy(collision.gameObject, 10);
    }

    private void CheckLife() {
        if (life == 0) {
            Destroy(gameObject);
            Destroy(HPbar);
            Destroy(HP);
        }
    }
}
