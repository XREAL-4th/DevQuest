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
    [SerializeField] private GameObject center; //physics sphere의 중심점

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float avoidRange;

    public enum State 
    {
        None,
        Idle,
        Attack,
        Avoid //player가 가까우면 왔다갔다 하면서 공격을 피하는 state
    }
    
    [Header("Debug")]
    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone;
    private bool avoidDone;

    public int hp=50; //HP

    public float enemyPosition = 0;
    //public GameObject rightTarget;
    //public GameObject leftTarget;


    public float initPositionZ;
    //public float initPositionX;
    public float distnace=5;
    public float turningPoint;

    public bool turnSwitch;
    public float moveSpeed=1;


    private void Start()
    { 
        state = State.None;
        nextState = State.Idle;

        hp = 50;

        initPositionZ = transform.position.z;
        turningPoint = initPositionZ - distnace;
        
        //hp = 50; //HP = 50
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
                        nextState = State.Attack;
                    }

                    else if(Physics.CheckSphere(center.transform.position, avoidRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        nextState = State.Avoid;
                    }


                    break;
                case State.Attack:
                    if (attackDone)
                    {
                        nextState = State.Idle;
                        attackDone = false;
                    }
                    break;
                //insert code here...

                case State.Avoid:
                    if (Physics.CheckSphere(center.transform.position, avoidRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                        {
                            nextState = State.Attack;
                            animator.SetBool("stun", false);
                            //avoidDone = false; 
                        } //else if 로 빼면 안된다. 지금 sphere가 겹쳐져있어서 else if로 빼면 avoid를 제외하고 attack 일 때니까.. 겹쳐있으니까 안에 넣어줘야 함
                    }


                    else
                    {
                        nextState = State.Idle;
                        animator.SetBool("stun", false);
                        //avoidDone = false; 
                        print("반경 벗어남");
                    }

                    break;
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
                case State.Avoid:
                    Avoid();
                    break;

            }
        }
        
        //3. 글로벌 & 스테이트 업데이트
        //insert code here...
    }
    
    private void Attack() //현재 공격은 애니메이션만 작동합니다.
    {
        print("Attack()실행 중");
        animator.SetTrigger("attack");
    }

    private void Avoid()
    {
        print("Avoid() 실행 중");
        animator.SetBool("stun", true);

        print(enemyPosition);

        //transform.position = transform.position + new Vector3(0, 0, 1) * 1;


        //transform.position = transform.position + new Vector3(0, 0, -1) * 1;








        /*여기부터
         
        if (enemyPosition >= 0 && enemyPosition <= 3)
        {
            transform.position = transform.position + new Vector3(0, 0, 1) * 1; //현재위치, 방향 * 속도
            enemyPosition += 1;

            if (enemyPosition == 3)
            {
                enemyPosition = -1;
            }
        }

        else if (enemyPosition < 0 && enemyPosition >= -4)
        {
            transform.position = transform.position + new Vector3(0, 0, -1) * 1; //현재위치, 방향 * 속도
            enemyPosition -= 1;

            if (enemyPosition == -4)
            {
                enemyPosition = 0;
            }
        }
        여기*/




        /*

        float currentPos = transform.position.z;

        if (currentPos >= initPositionZ)
        {
            turnSwitch = false;
        }

        else if (currentPos <= turningPoint)
        {
            turnSwitch = true;
        }



        if (turnSwitch)
        {
            transform.position = transform.position + new Vector3(0, 0, 1) * moveSpeed;
        }
        else
        {
            transform.position = transform.position + new Vector3(0, 0, -1) * moveSpeed;
        }

        */



        //transform.position = Vector3.Lerp(transform.position, rightTarget.transform.position, 0.5f); //rightTarget 위치로 0.5 속도로 enemy의 position 이동
        //transform.position = Vector3.Lerp(transform.position, leftTarget.transform.position, 0.5f);

        //Moves the GameObject from it's current position to destination over time
        //transform.position = Vector3.Lerp(transform.position, rightTarget.transform.position, Time.deltaTime);
        //transform.position = transform.position + new Vector3(0, 0, 1) * 1 ;

        /*

        if(enemyPosition == 0)
        {
            transform.position = transform.position + new Vector3(0, 0, 1) * 1 * Time.deltaTime; //현재위치, 방향 * 속도
            enemyPosition += 1;
        }
        else if(enemyPosition== 3)
        {
            transform.position = transform.position + new Vector3(0, 0, -1) * 1 * Time.deltaTime; //현재위치, 방향 * 속도
            enemyPosition -= 0.3f;
        }
        */




        //print(enemyPosition);

        /*
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, 19) * 1, 0.5f);
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, -19) * 1, 0.5f);
        }
        */








        //float rightMax = 3.0f;
        //float leftMax = 2.0f;

        //transform.position = transform.position + new Vector3(0, 0, 1) * 1 * Time.deltaTime; //현재위치, 방향 * 속도
        //적이 왼쪽오른쪽 왔다갔다 한다.

        //avoidDone = true;

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
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawSphere(transform.position, attackRange);
        Gizmos.DrawSphere(center.transform.position, avoidRange);

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            print("총알과 닿았다");

            hp -= GameManager.instance.playerAttack; //플레이어가 준 공격력만큼 hp가 - 됨
            print("체력:" + hp);

            
            if (hp <= 0)
            {
                Destroy(this.gameObject);
                GameManager.instance.Score();
            }

        }
    }

}
