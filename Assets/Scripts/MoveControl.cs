using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveControl : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private CapsuleCollider col;
    
    [Header("Settings")]
    [SerializeField][Range(1f, 10f)] private float moveSpeed;
    [SerializeField][Range(1f, 10f)] private float jumpAmount;

    public enum State {
        None,
        Idle,
        Jump
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;
    public bool landed = false;
    public bool moving = false;
    
    private float stateTime;
    private Vector3 forward, right;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        
        state = State.None;
        nextState = State.Idle;
        stateTime = 0f;
        forward = transform.forward;
        right = transform.right;
    }

    private void Update()
    {
        // 0. Check global state
        stateTime += Time.deltaTime;
        CheckLanded();

        // 1. Chage state & Check state
        if (nextState == State.None) 
        {
            switch (state) 
            {
                case State.Idle:
                    if (landed) 
                    {
                        if (Input.GetKey(KeyCode.Space)) 
                        {
                            nextState = State.Jump;
                        }
                    }
                    break;
                case State.Jump:
                    if (landed) 
                    {
                        nextState = State.Idle;
                    }
                    break;
            }
        }
        
        // 2. Initialize state
        if (nextState != State.None) 
        {
            state = nextState;
            nextState = State.None;
            switch (state) 
            {
                case State.Jump:
                    var vel = rigid.velocity;
                    vel.y = jumpAmount;
                    rigid.velocity = vel;
                    break;
            }
            stateTime = 0f;
        }
        
        // 3. Global & state update
    }

    private void FixedUpdate()
    {
        UpdateInput();
    }

    private void CheckLanded() {
        // 발 위치에 작은 구를 하나 생성한 후, 그 구가 땅에 닿는지 검사한다.
        // Ground 3 layers : 1 << 3
        var center = col.bounds.center;
        var origin = new Vector3(center.x, center.y - ((col.height - 1f) / 2 + 0.15f), center.z);
        landed = Physics.CheckSphere(origin, 0.45f, 1 << 3, QueryTriggerInteraction.Ignore);
    }
    
    private void UpdateInput() {
        var direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) direction += forward;  // Forward
        if (Input.GetKey(KeyCode.A)) direction += -right;   // Left
        if (Input.GetKey(KeyCode.S)) direction += -forward; // Back
        if (Input.GetKey(KeyCode.D)) direction += right;    // Right
        direction.Normalize();
        transform.Translate( moveSpeed * Time.deltaTime * direction); // Move
    }

    private void OnCollisionEnter(Collision collision) {
        Vector3[] coords = new Vector3[5]{
            new Vector3(0.0f, 0.0f, 4.5f),
            new Vector3(4.04f, 0.0f, 3.74f),
            new Vector3(-4.3f, 0.79f, -6.5f),
            new Vector3(-5.5f, 0.79f, -9.3f),
            new Vector3(10.0f, 0.79f, -7.4f)
        };

        //Debug.Log("ㅇㅇ??");
        //Debug.Log(collision.gameObject.GetComponent<AppleData>());

        if (collision.gameObject.name == "Apple(Clone)") {
            for (int i = 0; i < coords.Length; i++) {
                if (collision.gameObject.transform.position == coords[i]) {
                    int speed = ItemManager.instance.AppleDatas[i].Speed;
                    int jump = ItemManager.instance.AppleDatas[i].Jump;
                    if (speed == 0) {
                        jumpAmount = jump;
                    }
                    if (jump == 0) {
                        moveSpeed = speed;
                    }
                    Destroy(collision.gameObject);
                }
            }
        }
    }    
}