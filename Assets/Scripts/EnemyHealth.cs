using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 10;
    [SerializeField] private int currentHitPoints = 0;
    [SerializeField] public GameObject hitFx;

    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    // Bullet과 Enemy간의 충돌이 일어날 때마다 HitPoint 1씩 감소
    // 질문할 부분 : 충돌 1번당 HP 1 감소 -> 총 10번 충돌하면 파괴되는 것을 의도했는데 몇대 안맞고 하늘나라로 가버려요 ㅠㅠ
    // 추측하기로는 collision이 의도처럼 1번이 아니라 접촉시 여러번 일어나서 그런 것 같은데, 어떤 방식으로 수정하면 좋을 지 궁금합니다.
    // 제출 이후 Raycast 방식으로도 구현해 볼 예정입니다.
    private void OnCollisionEnter(Collision collision)
    {
        ProcessHit();
        Instantiate(hitFx, transform.position, Quaternion.identity);
    }

    private void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints < 1)
        {
            Destroy(gameObject);
        }
    }
}
