using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFire : MonoBehaviour
{
    


    //수류탄 발사 위치 지정
    public GameObject firePosition;
    //수류탄 오브젝트 변수
    public GameObject bombFactory;
    //투척 파워
    public float throwPower = 15f;
    //수류탄 공격력
    public int bombPower = 15;

    //총알 이펙트 오브젝트
    public GameObject bulletEffect;
    //총알 이펙트 파티클 시스템
    ParticleSystem ps;
    //총알 공격력
    public int weaponPower = 5;
    
    //딜레이 판정 변수
    public bool isDelay;
    //딜레이 시간 변수
    public float delayTime = 5f;
    float timer = 0f;

    
    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 오른쪽 버튼 입력
        if (Input.GetMouseButtonDown(1))
        {
            
            if (!isDelay)
            {
                isDelay = true;
                GameObject bomb = Instantiate(bombFactory);
                bomb.transform.position = firePosition.transform.position;
                Rigidbody rb = bomb.GetComponent<Rigidbody>();
                //카메라의 정면 방향으로 무기에 물리적 힘을 가함
                rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

            

            
            //코루틴 함수 실행
            StartCoroutine(CountAttackDelay());
        }
        else
        {
            Debug.Log("Delay");
        }
        
        
        }
        
        if (isDelay)
        {
            timer += Time.deltaTime;
            if (timer >= delayTime)
            {
                timer = 0f;
                isDelay = false;
            }
        }
        



        //마우스 왼쪽 버튼 입력
        if (Input.GetMouseButtonDown(0))
        {
            //레이 생성하고 발사될 위치와 방향 설정
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //레이가 부딪힌 대상의 정보 저장
            RaycastHit hitInfo = new RaycastHit();

            //만일 부딪힌 물체 있으면 피격 이펙트 표시
            if (Physics.Raycast(ray, out hitInfo))
            {


                //만일 부딪힌 대상 레이어 Enemy이면 Damage 함수 실행
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyAttack eATK = hitInfo.transform.GetComponent<EnemyAttack>();
                    eATK.HitEnemy(weaponPower);
                    bulletEffect.transform.position = hitInfo.point;
                    ps.Play();
                    
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;
                    //피격 이펙트의 forward 방향을 레이가 부딪힌 지점의 수직으로 발생. 충돌 지점의 방향과 일치
                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                    
                    
                }
            }
        }
    }
    
    IEnumerator CountAttackDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;

    }
}
