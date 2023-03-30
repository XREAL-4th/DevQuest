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

    //FSM(finite state machine)에 대한 더 자세한 내용은 세션 3회차에서 배울 것입니다!
    public enum State 
    {
        None,
        Idle,
        Jump
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;
    public bool landed = false;
    
    private float stateTime;

    public static Camera cam; // 메인카메라
    private static WaitForSeconds waitForSecondsInstance = new WaitForSeconds(5f);

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        cam = Camera.main;
        
        state = State.None;
        nextState = State.Idle;
        stateTime = 0f;
        moveSpeed = 2f;
    }

    private void Update()
    {
        //0. 글로벌 상황 판단
        stateTime += Time.deltaTime;
        CheckLanded();
        UpdateInput();
        //insert code here...

        // print("checked!");

        //1. 스테이트 전환 상황 판단
        if (nextState == State.None) 
        {
            switch (state)
            {
                case State.Idle:
                    if (landed) 
                    {
                        if (Input.GetKey(KeyCode.Space)) 
                        {
                            // print("jump!");
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
                case State.Jump:
                    var vel = rigid.velocity;
                    vel.y = jumpAmount;
                    rigid.velocity = vel;
                    break;
                //insert code here...
            }
            stateTime = 0f;
        }
        
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
        
        ActionControl.TryAction(transform);
        PickUpSpeed();
    }

    void PickUpSpeed() {
        if (GameManager.pickUpSpeed) {
            moveSpeed += 3f;
            GameManager.pickUpSpeed = false;
            Debug.Log("스피드가 3 높아졌습니다!");
        }
    }

    private void CheckLanded() {
        //발 위치에 작은 구를 하나 생성한 후, 그 구가 땅에 닿는지 검사한다.
        //1 << 3은 Ground의 레이어가 3이기 때문, << 는 비트 연산자
        var center = col.bounds.center;
        var origin = new Vector3(center.x, center.y - ((col.height - 1f) / 2 + 0.15f), center.z);
        landed = Physics.CheckSphere(origin, 0.45f, 1 << 3, QueryTriggerInteraction.Ignore);
        // print(landed);
        landed = true; //???
    }
    
    private void UpdateInput()
    {
        var direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W)) direction += Vector3.forward; //Forward
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left; //Left
        if (Input.GetKey(KeyCode.S)) direction += Vector3.back; //Back
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right; //Right
        
        direction.Normalize(); //대각선 이동(Ex. W + A)시에도 동일한 이동속도를 위해 direction을 Normalize
        // print(moveSpeed * Time.deltaTime * direction);
        transform.Translate( moveSpeed * Time.deltaTime * direction); //Move
    }
}
