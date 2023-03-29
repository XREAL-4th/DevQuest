using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHitPoints = 10;
    [SerializeField] public int currentHitPoints = 0;
    [SerializeField] public GameObject hitFx;
    [SerializeField] public GameObject bombhitFx;

    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    // Bullet과 Enemy간의 충돌이 일어날 때마다 HitPoint 1씩 감소
    // 질문할 부분 : 충돌 1번당 HP 1 감소 -> 총 10번 충돌하면 파괴되는 것을 의도했는데 몇대 안맞고 하늘나라로 가버려요 ㅠㅠ
    // 추측하기로는 collision이 의도처럼 1번이 아니라 접촉시 여러번 일어나서 그런 것 같은데, 어떤 방식으로 수정하면 좋을 지 궁금합니다.
    // 제출 이후 Raycast 방식으로도 구현해 볼 예정입니다.
    private void OnCollisionEnter(Collision target)
    {
        ProcessHit(target);
        Debug.Log("target : "+ target.collider.gameObject);
        Debug.Log("currentHP : "+ currentHitPoints);
    }

    public void ProcessHit(Collision targetmat)
    {

        if(targetmat.collider.gameObject.tag == "Bullet"){
            Instantiate(hitFx, transform.position, Quaternion.identity);
            currentHitPoints -=1;
        }

        else if(targetmat.collider.gameObject.tag == "Bomb"){
            Instantiate(bombhitFx, transform.position, Quaternion.identity);
            currentHitPoints -=5;
        }


        if(currentHitPoints < 1)
        {
            Destroy(gameObject);
            GameManager.instance.enemiesCount--;
        }
    }
}
