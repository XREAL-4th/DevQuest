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
    [SerializeField] private GameObject center; //physics sphere의 중심점

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float avoidRange;
    //[SerializeField] private float rectangleRange;

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


    //UI 
    public Text damage; //text
    public GameObject damageUI; //UI GameObject
    public GameObject damagePos; 

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

        if (hp <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.Score();
            print("적이 하나 파괴");
        } //hp가 0이면 enemy 없애고 없앤적의수+1


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
                    //Avoid();
                    StartCoroutine(avoidLoop());
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


    IEnumerator avoidLoop()
    {
        animator.SetBool("stun", true);

        for (int i = 0; i < 4; i++)
        {
            

            /*
            else if (Physics.CheckBox(transform.position, new Vector3(1, 1, 1)))
            {
                break;
            }
            */


            transform.position = transform.position + new Vector3(0, 0, 0.5f) * 1;
            yield return new WaitForSeconds(0.5f);


            if (Physics.CheckSphere(center.transform.position, avoidRange, 1 << 6, QueryTriggerInteraction.Ignore))
            {
                if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    break;
                }
            }

            else
            {
                break;
            }

        }
        


        while (true)
        {
            //enemyPosition += 1;
            //print(enemyPosition);

            
            for (int a = 0; a < 8; a++)
            {
                print("실행중1");
                transform.position = transform.position + new Vector3(0, 0, -0.5f) * 1;
                yield return new WaitForSeconds(0.5f);


                if (Physics.CheckSphere(center.transform.position, avoidRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        break;
                    }
                }

                else
                {
                    break;
                }
            }

            

            for (int b = 0; b <8; b++)
            {
                print("실행중2");
                transform.position = transform.position + new Vector3(0, 0, 0.5f) * 1;
                yield return new WaitForSeconds(0.5f);


                if (Physics.CheckSphere(center.transform.position, avoidRange, 1 << 6, QueryTriggerInteraction.Ignore))
                {
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 6, QueryTriggerInteraction.Ignore))
                    {
                        break;
                    }
                }

                else
                {
                    break;
                }
            }

            break;



            //yield return new WaitForSeconds(0.5f);
            //yield return null;
        }
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
        //Gizmos.DrawCube(center.transform.position, new Vector3(1, 1, 1));

    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            print("총알과 닿았다");

            hp -= GameManager.instance.playerAttack; //플레이어가 준 공격력만큼 hp가 - 됨
            print("체력:" + hp);


            //UI
            damage.text = "-" + GameManager.instance.playerAttack.ToString();
            DamageUI();

        }
    }

    public void DamageUI()
    {
        //UI부분
        //Instantiate(damageUI, this.gameObject.transform.position, Quaternion.identity);
        //GameObject temp = Instantiate(damageUI, new Vector3(0,0,0), Quaternion.identity);

        // GameObject temp = Instantiate(damageUI, new Vector3(0,0,0), new Quaternion(0,180,0,0));
        //temp.transform.SetSiblingIndex(7);
        //damageUI.transform.SetParent(damagePos.transform);


        //
        //GameObject temp = Instantiate(damageUI,new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        
        
        //damage.text = "-" + GameManager.instance.playerAttack.ToString();

        GameObject temp = Instantiate(damageUI);
        temp.transform.SetParent(damagePos.transform); //damagePos를 부모로 설정해서 이 밑으로 생성된 프리팹이 이동

        //temp.transform.localPosition(0, 0, 0);

        //temp.transform.position = new Vector3(0, 0, 0);
        //temp.transform.rotation = new Quaternion(0, 180, 0, 0);

        temp.transform.localPosition = new Vector3(0, 0, 0);
        temp.transform.localScale = new Vector3(2, 2, 2); //1,1,1 하니까 작은거 같아서 키움
        temp.transform.localEulerAngles = new Vector3(0, 180, 0);
        //그냥 불러왔더니 이상한 포지션에 이상한 스케일로 불러와서 이쪽에서 원하는 값으로 설정

        //temp.transform.Rotate(0, 180, 0);


        //GameObject go = Instantiate(A, new Vector3(0, 0, 0), uaternion.identity) as GameObject;
        //go.transform.parent = GameObject.Find("Stage Scroll").transform;


        //temp.transform.SetParent(this.transform);
        //temp.transform.SetParent(GameObject.Find("Canvas").transform);

        //temp.transform.parent = this.transform;



        temp.GetComponent<Rigidbody>().AddForce(transform.up * 8);
        //UI 가 위로 올라감 

        Destroy(temp, 1.5f); //1.5초후 파괴

        //Instantiate(damageUI, transform.position, Quaternion.identity);
    }



}
