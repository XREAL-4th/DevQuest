using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //총알 이펙트 오브젝트
    public GameObject bulletEffect;
    //총알 이펙트 파티클 시스템
    ParticleSystem ps;
    //공격력
    public int weaponPower = 5;

    // Start is called before the first frame update
    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
